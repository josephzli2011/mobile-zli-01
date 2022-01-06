using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        GetComponent<TMP_Text>().text = "" + PlayerPrefs.GetInt("Money", 0);
    }
}
