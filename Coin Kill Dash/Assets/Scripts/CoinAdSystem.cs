using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinAdSystem : MonoBehaviour
{
    public Text addMoneyTxt;
    [HideInInspector]public static int amt;
    float nextTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        amt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
            if (PlayerPrefs.GetInt("Money", 0) <= 200)
            {
                amt = 10;
            }
            else if (PlayerPrefs.GetInt("Money", 0) <= 500)
            {
                amt = 50;
            }
            else if (PlayerPrefs.GetInt("Money", 0) <= 1000)
            {
                amt = 100;
            }
            else if (PlayerPrefs.GetInt("Money", 0) <= 2500)
            {
                amt = 250;
            }
            else if (PlayerPrefs.GetInt("Money", 0) <= 5000)
            {
                amt = 400;
            }
            else if (PlayerPrefs.GetInt("Money", 0) <= 10000)
            {
                amt = 750;
            }
            else if (PlayerPrefs.GetInt("Money", 0) <= 30000)
            {
                amt = 1000;
            }
            else
            {
                amt = 2000;
            }
        addMoneyTxt.text = "+" + amt + " COINS";
        
    }

    public void WatchAd()
    {

    }
}
