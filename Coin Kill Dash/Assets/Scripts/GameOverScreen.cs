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
