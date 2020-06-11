using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//added to control scene
using UnityEngine.SceneManagement;
//so that i can use Text
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //player
    private GameObject player;
    //environment manager
    private GameObject envMan;
    //bool to determine whether or not the object has been scored
    private bool scored;

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
        //player is equal to the player object(using tag to find it)
        player = GameObject.FindGameObjectWithTag("Player");
        //using manager tag to find env manager
        envMan = GameObject.FindGameObjectWithTag("Manager");
        //setting scored to false - player has not scored
        scored = false;

        //getting the text component and making it 0
        scoretext.GetComponent<Text>().text = "-1";
        //setting score to 0
        score = -1;

        //getting the text component and making it 0
        coinScore.GetComponent<Text>().text = "Coins: 0";
        //coins is 0
        coins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if r key is pressed (restart)
        if (Input.GetKeyDown(KeyCode.R))
        {
            //timescale back to 1
            Time.timeScale = 1;
            //reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //if this obstacle's z pos is smaller than or = to than the player's z pos ( behind or next to them) and they havent scored yet
        if (this.transform.position.z <= player.transform.position.z && scored == false)
        {
            //call addscore method and track score
            AddScore();
            //they have now scored so set this to true
            //otherwise it will keep adding a score for the same obstacle until it is destroyed
            scored = true;
        }

        //if player is dead
        if (player.GetComponent<PlayerDeath>().isAlive == false)
        {
            //get final score
            FinalScore();
        }
    }

    //method that adds up the score
    public void AddScore()
    {
        //score increments
        score++;
        //having the text on the canvas reflect the score count
        scoretext.GetComponent<Text>().text = score.ToString("F0");

        Debug.Log(score);
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
