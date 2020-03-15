using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//so that i can use Text
using UnityEngine.UI;
//added to control scene
using UnityEngine.SceneManagement;

public class ScoreTrack : MonoBehaviour
{
    //int that keeps track of the score
    private int score;
    //scoretext gameobj - the text parented to the canvas that displays the score
    public GameObject scoretext;
    //int that keeps track of the coins
    private int coins;
    //scoretext gameobj - the text parented to the canvas that displays the coin cout
    public GameObject coinScore;

    public GameObject DeathCanvas;

    public GameObject UICanvas;

    // Start is called before the first frame update
    void Start()
    {
        //getting the text component and making it 0
        scoretext.GetComponent<Text>().text = "0";
        //setting score to 0
        score = 0;

        //getting the text component and making it 0
        coinScore.GetComponent<Text>().text = "Coins: 0";
        //coins is 0
        coins = 0;
    }

    //method that adds up the score
    public void AddScore()
    {
        //score increments
        score++;
        //having the text on the canvas reflect the score count
        scoretext.GetComponent<Text>().text = score.ToString("F0");

        //Debug.Log(score);
    }
    //method that adds the coins
    public void AddCoins()
    {
        //coins increment
        coins++;
        //having the text on the canvas reflect the coin count
        coinScore.GetComponent<Text>().text = "Coins: " + coins;
    }

    public void Death()
    {
        UICanvas.SetActive(false);
        DeathCanvas.SetActive(true);
        Time.timeScale = 0;

        if (Input.GetKeyDown(KeyCode.R))
        {
            //reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
