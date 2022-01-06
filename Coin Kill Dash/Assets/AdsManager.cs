using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    string placement = "Rewarded_Android";

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
         if(showResult == ShowResult.Finished)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) + CoinAdSystem.amt);
        } else
        {

        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize("4545736", true);
        
    }

    public void ShowAd(string p)
    {
        Advertisement.Show(p);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
