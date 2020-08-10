using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    const string privateCode = "jAbbo1S6fk6dwUO7_Z7NTQ8mrbV64STU-TdMXZg5I_NA";
    const string publicCode = "5f3147a6eb371809c4bd863c";
    const string webURL = "http://dreamlo.com/lb/";

    public HS[] highscoreslist;
    static Leaderboard instance;
    DisplayHS hsDisplay;

    private void Awake()
    {
        //AddNewHS("name", 6);
        instance = this;
        hsDisplay = GetComponent<DisplayHS>();
    }

    public static void AddNewHS(string username, int score)
    {
        instance.StartCoroutine(instance.uploadNewHS(username, score));
    }

    IEnumerator uploadNewHS(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            //Debug.Log("Succcess");
            DownloadHS();
        }
        else
        {
            //Debug.Log("Error " + www.error);
        }
    }


    public void DownloadHS()
    {
        StartCoroutine(DownloadHSData());
    }

    IEnumerator DownloadHSData()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/" );
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            //Debug.Log(www.text);
            formatHS(www.text);
            hsDisplay.onHSDownloaded(highscoreslist);
        }
        else
        {
            //Debug.Log("Error Downloading" + www.error);
        }
    }

    void formatHS(string TextStream)
    {
        string[] entries = TextStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoreslist = new HS[entries.Length];
        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoreslist[i] = new HS(username, score);
            //Debug.Log(highscoreslist[i].username + ": " + highscoreslist[i].score);
        }
    }

    public struct HS
    {
        public string username;
        public int score;

        public HS(string _username, int _score)
        {
            username = _username;
            score = _score;
        }
    }
}
