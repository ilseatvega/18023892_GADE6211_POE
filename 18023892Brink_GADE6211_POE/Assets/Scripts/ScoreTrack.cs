using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTrack : MonoBehaviour
{
    private int score;
    public GameObject scoretext;

    // Start is called before the first frame update
    void Start()
    {
        scoretext.GetComponent<Text>().text = "0";
        score = 0;
    }

    public void Update()
    {
    }
    public void AddScore()
    {
        score++;
        scoretext.GetComponent<Text>().text = score.ToString("F0");

        //Debug.Log(score);
    }

   
}
