using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class AdsManager : MonoBehaviour
{
    



    public void ShowRewardedAd()
    {
        Debug.Log("Showing Ad");
        //check if ad is ready -rewardedVideo
        //show ad

        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions {resultCallback = HandleShowResult};

            Advertisement.Show("rewardedVideo", options);
        }
    }

    void HandleShowResult(ShowResult result)
    {

        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Award player gems");
                GameManager.Instance.Player.AddGems(100);
                UIManager.Instance.UpdateShopGemCount(GameManager.Instance.Player.diamonds);
                break;
            case ShowResult.Failed:
                Debug.Log("Failed - maybe ad not ready?");
                break;
            case ShowResult.Skipped:
                Debug.Log("Skipped Ad - no gems for you");
                break;
        }
    }

}
