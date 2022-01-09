using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscores : MonoBehaviour
{
    const string privateCode = "wstG_RjVA0e-fzxdt24TngdpUaSnvJAUu_L5dMb4KbYg";
    const string publicCode = "61d844438f40bb3d7803a213";
    const string webUrl = "http://dreamlo.com/lb/";


    public Highscore[] highscoreList;
    public DisplayHighScores highscoresDisplay;

    static Highscores instance;
    private void Awake()
    {
        highscoresDisplay = GetComponent<DisplayHighScores>();
        instance = this;
    }

    public static void AddNewHighscore(string username, int score)
    {
        instance.StartCoroutine(instance.UploadNewHighscore(username, score));
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webUrl + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if(string.IsNullOrEmpty(www.error))
        {
            print("Upload Successful");
            DownloadHighscores();
        } else
        {
            print("Error uploading" + www.error);
        }
    }

    IEnumerator DownloadHighscoresFromDatabase()
    {
        WWW www = new WWW(webUrl + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighsores(www.text);
            highscoresDisplay.OnHighscoresDownloaded(highscoreList);
        }
        else
        {
            print("Error downloading" + www.error);
        }
    }

    public void DownloadHighscores()
    {
        StartCoroutine(DownloadHighscoresFromDatabase());
    }

    void FormatHighsores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        highscoreList = new Highscore[entries.Length];

        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string usename = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoreList[i] = new Highscore(usename, score);
            print(highscoreList[i].username + ": " + highscoreList[i].score);
        }
    }
}


public struct Highscore
{
    public string username;
    public int score;

    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}