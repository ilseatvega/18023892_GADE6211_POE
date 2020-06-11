using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//added to control scene
using UnityEngine.SceneManagement;
//so that i can use Text
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //for the multiplier visual indicator that pops up when the collar is picked up
    public GameObject multiplierUI;
    //for the invincible visual indicator that pops up when the berry is picked up
    public GameObject berryUI;
    //int that keeps track of the score
    private int score;
    //multiplier to be used on the multiplier item 
    private int multiplier =1;
    //scoretext gameobj - the text parented to the canvas that displays the score
    public GameObject scoretext;
    //int that keeps track of the coins
    public int coins;
    //scoretext gameobj - the text parented to the canvas that displays the coin count
    public GameObject coinScore;
    //deathcanvas
    public GameObject DeathCanvas;
    //uicanvas
    public GameObject UICanvas;
    //scoretext gameobj - the text parented to the canvas that displays the fianl score
    public GameObject endScoreText;
    //multiplier get set that can either get multiplers value or set it to a value
    public int Multiplier { get { return multiplier; } set { multiplier = value; } }

    // Start is called before the first frame update
    void Start()
    {
        //getting the text component and making it 0
        scoretext.GetComponent<Text>().text = "0";
        //setting score to 0
        score = 0;

        //getting the text component and making it 0
        coinScore.GetComponent<Text>().text = " 0";
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
    }

    //method that adds up the score
    public void AddScore()
    {
        //score increments
        score++;
        //having the text on the canvas reflect the score count
        scoretext.GetComponent<Text>().text = score.ToString("F0");
    }
    //method that adds the coins
    public void AddCoins()
    {
        //coins increment
        coins += 1 * multiplier;
        //having the text on the canvas reflect the coin count
        coinScore.GetComponent<Text>().text = "" + coins;
    }
    //coroutine to set the coin multiplier back to 1
    public IEnumerator ResetCoin()
    {
        //wait 10 seconds
        yield return new WaitForSecondsRealtime(10);
        //set multiplier to 1
        multiplier = 1;
    }
    //coroutine to activate and deactive pickup UI
    public IEnumerator BerryActive()
    {
        //set image active
        berryUI.SetActive(true);

        //wait 10 seconds
        yield return new WaitForSecondsRealtime(10);

        //set ui to not active
        berryUI.SetActive(false);
    }
    //coroutine to activate and deactive pickup UI
    public IEnumerator MultActive()
    {
        //set image active
        multiplierUI.SetActive(true);

        //wait 10 seconds
        yield return new WaitForSecondsRealtime(10);

        //set ui to not active
        multiplierUI.SetActive(false);
    }
    //finalscore on death canvas
    public void FinalScore()
    {
        //having the text on the canvas reflect the final score
        endScoreText.GetComponent<Text>().text = "Score: " + score;
    }
    //death screen
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
