using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string levelName = "SampleScene";
    public void Play()
    {
        SceneManager.LoadScene(levelName);
    }

    public void Shop()
    {

    }

    public void Exit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
