using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayHighScores : MonoBehaviour
{
    public Text[] highscoreTexts;
    Highscores highscoreManager;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < highscoreTexts.Length; i++)
        {
            highscoreTexts[i].text = i+1 + ". Fetching...";
        }

        highscoreManager = GetComponent<Highscores>();
        StartCoroutine(RefreshHighscores());
    }

    public void OnHighscoresDownloaded(Highscore[] highscoreList)
    {
        for (int i = 0; i < highscoreTexts.Length; i++)
        {
            highscoreTexts[i].text = i+1 + ". ";
            if(highscoreList.Length > i)
            {
                highscoreTexts[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
            }
        }
    }

    IEnumerator RefreshHighscores()
    {
        while(true)
        {
            highscoreManager.DownloadHighscores();
            yield return new WaitForSeconds(30);
        }
    }
}
 