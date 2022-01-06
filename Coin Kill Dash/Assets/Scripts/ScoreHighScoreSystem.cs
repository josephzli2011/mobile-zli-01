using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreHighScoreSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("PrevScore", 0) + "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
