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
    //scoretext gameobj - the text parented to the canvas that displays the coin count
    public GameObject coinScore;
    //deathcanvas
    public GameObject DeathCanvas;
    //uicanvas
    public GameObject UICanvas;
    //scoretext gameobj - the text parented to the canvas that displays the fianl score
    public GameObject endScoreText;

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

    //finalscore on death canvas
    public void FinalScore()
    {   
        //having the text on the canvas reflect the final score
        endScoreText.GetComponent<Text>().text = "Score: " + score;
    }

    public void Death()
    {
        //canvas of ui is false
        UICanvas.SetActive(false);
        //death canvas is true
        DeathCanvas.SetActive(true);
        //time stops
        Time.timeScale = 0;

        //when r is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            //reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
