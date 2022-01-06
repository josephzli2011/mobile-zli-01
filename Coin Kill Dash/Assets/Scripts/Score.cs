using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    public int scoreNumber = 0;
    public float point1delay = 0.01f;
    float nextTime;
    // Start is called before the first frame update
    void Start()
    {
        nextTime = Time.time + point1delay;
        scoreNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextTime)
        {
            nextTime += point1delay;
            scoreNumber++;
            score.text = scoreNumber + "";
            PlayerPrefs.SetInt("PrevScore", scoreNumber);
        }
    }
}
