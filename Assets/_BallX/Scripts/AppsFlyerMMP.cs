using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppsFlyerMMP : MonoBehaviour
{

    void Start()
    {
        // For detailed logging
        //AppsFlyer.setIsDebug (true);
        AppsFlyer.setAppsFlyerKey("aTYJZVwsYCTz8BbnbrDbxL");
#if UNITY_IOS
        //Mandatory - set your AppsFlyer’s Developer key.
        
        //Mandatory - set your apple app ID
        //NOTE: You should enter the number only and not the "ID" prefix
        AppsFlyer.setAppID ("YOUR_APP_ID_HERE");
        AppsFlyer.trackAppLaunch ();
#elif UNITY_ANDROID
        //Mandatory - set your Android package name
        AppsFlyer.setAppID("com.belizard.ballz");
        //Mandatory - set your AppsFlyer’s Developer key.
        AppsFlyer.init("aTYJZVwsYCTz8BbnbrDbxL");

        //AppsFlyer.setCustomerUserID("659231");

        //For getting the conversion data in Android, you need to this listener.
        //AppsFlyer.loadConversionData("AppsFlyerTrackerCallbacks");

#endif
    }

    public static void Score(int batch)
    {

        Dictionary<string, string> score = new Dictionary<string, string>();
        score.Add("score", batch.ToString());
        AppsFlyer.trackRichEvent("score", score);

    }

    public static void BestScore()
    {

        Dictionary<string, string> score = new Dictionary<string, string>();
        score.Add("best_score", "1");
        AppsFlyer.trackRichEvent("best_score", score);

    }

    public static void ContinuePlaying()
    {
        Dictionary<string, string> save = new Dictionary<string, string>();
        save.Add("continue_playing", "1");
        AppsFlyer.trackRichEvent("continue_playing", save);
    }

    public static void AtomCollected()
    {

        Dictionary<string, string> score = new Dictionary<string, string>();
        score.Add("atom_collected", "1");
        AppsFlyer.trackRichEvent("atom_collected", score);

    }

    public static void WatchVideo()
    {

        Dictionary<string, string> video = new Dictionary<string, string>();
        video.Add("atom_video_watched", "1");
        AppsFlyer.trackRichEvent("atom_video_watched", video);

    }

    public static void BallUnlocked()
    {

        Dictionary<string, string> ball = new Dictionary<string, string>();
        ball.Add("ball_unlocked", "1");
        AppsFlyer.trackRichEvent("ball_unlocked", ball);

    }

}
