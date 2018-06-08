using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.UI;

public class GoogleManager : MonoBehaviour
{

    string androidLeaderboard = "CgkI2qa2164bEAIQAQ";
    string iosLeaderboard = "Replace This";
    static string leaderboard;

    // Use this for initialization
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            //PlayGamesPlatform.Activate();
            leaderboard = androidLeaderboard;

        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            leaderboard = iosLeaderboard;
        }
        else
        {
            leaderboard = iosLeaderboard;
        }

        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        LogIn();
    }

    public void LogIn()
    {
        if (!Social.localUser.authenticated)
        {
            Debug.Log("3");
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    Debug.Log("login success");
                    Debug.Log(Social.localUser.id);
                    Debug.Log(Social.localUser.userName);
                }
                else
                {
                    Debug.Log("login fail");
                }

            });
        }

    }

    public static void ReportScore(int highscore)
    {
        Social.ReportScore(highscore, leaderboard, success => { if (success) { Debug.Log("score reported"); } else { Debug.Log("score report failed"); } });
    }

    public void LogOut()
    {
        Debug.Log("LogOut");
        ((PlayGamesPlatform)Social.Active).SignOut();
    }


}