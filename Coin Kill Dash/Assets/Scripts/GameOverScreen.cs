using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
    public GameObject newHighscoreGO;
    public Text score;
    public Text coinsAdded;
    public Text totalCoins;
    public string menuSceneName = "MainMenu";
    public GameObject usernameSetScreen;
    public Button usernameSetDoneButton;
    public InputField usernameField;
    bool loginDone;
    public Text usernameSetErrorText;
    public Highscores highScoresRef;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("PrevScore", 0) > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("PrevScore", 0));
            newHighscoreGO.SetActive(true);
        }
        int coinsAddedN = 0;
        coinsAddedN = (int)(int.Parse(score.text) / 100);
        coinsAdded.text =  "+" + coinsAddedN + " COINS";
        totalCoins.text = "TOTAL COINS: " + (coinsAddedN + PlayerPrefs.GetInt("Money", 0));
        PlayerPrefs.SetInt("Money", coinsAddedN + PlayerPrefs.GetInt("Money", 0));
        if (PlayerPrefs.HasKey("Username"))
        {
            usernameSetScreen.SetActive(false);
            Highscores.AddNewHighscore(PlayerPrefs.GetString("Username"), PlayerPrefs.GetInt("HighScore", 0));
        } else
        {
            usernameSetScreen.SetActive(true);
            StartCoroutine(WaitForUsernameCreate());
        }
    }

    IEnumerator WaitForUsernameCreate()
    {
        loginDone = false;
        while(!loginDone)
        {
            yield return null;
        }
        PlayerPrefs.SetString("Username", usernameField.text);
        Highscores.AddNewHighscore(PlayerPrefs.GetString("Username"), PlayerPrefs.GetInt("HighScore", 0));
        usernameSetScreen.SetActive(false);
    }

    public void Done()
    {
        string[] usernames = new string[highScoresRef.highscoreList.Length];
        for (int i = 0; i < highScoresRef.highscoreList.Length; i++)
        {
            usernames[i] = highScoresRef.highscoreList[i].username;
        }
        if (usernameField.text.Length == 0)
        {
            usernameSetErrorText.gameObject.SetActive(true);
            usernameSetErrorText.text = "ENTER A USERNAME (you didn\'t)";
        }
        else if (usernames.Contains(usernameField.text))
        {
            usernameSetErrorText.gameObject.SetActive(true);
            usernameSetErrorText.text = "USERNAME ALREADY TAKEN";
        } else
        {
            print("Username success! (Ya-hoo)");
            loginDone = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Menu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
