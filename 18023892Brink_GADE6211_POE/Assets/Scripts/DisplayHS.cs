using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHS : MonoBehaviour
{
    public Text[] hsText;
    Leaderboard hsManager;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < hsText.Length; i++)
        {
            hsText[i].text = i+ 1 + ". Fetching...";
        }

        hsManager = GetComponent<Leaderboard>();

        StartCoroutine(RefreshHS());
    }
    
    public void onHSDownloaded(Leaderboard.HS[] highscoreslist)
    {
        for (int i = 0; i < hsText.Length; i++)
        {
            hsText[i].text = i + 1 + ". ";
            if (highscoreslist.Length > i)
            {
                hsText[i].text += highscoreslist[i].username + " - " + highscoreslist[i].score;
            }
        }
    }
    IEnumerator RefreshHS()
    {
        while (true)
        {
            hsManager.DownloadHS();
            yield return new WaitForSeconds(30f);
        }
    }
}
