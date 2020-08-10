using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//added to control scene
using UnityEngine.SceneManagement;
//so that i can use Text
using UnityEngine.UI;
//for events
using UnityEngine.Events;
using System.IO;

public class GameManager : MonoBehaviour
{
    //fieldboss unity event
    public UnityEvent fieldBossEvent;
    public UnityEvent forestBossEvent;
    public UnityEvent icebossevent;

    //array to hold all audio sources
    private AudioSource[] allAudioSources;

    //buttons
    public Button play;
    public Button restartInGame;
    public Button pause;
    public Button restart;
    public Button exit;
    public Button muteAll;
    public Button pauseResume;
    public Button pauseRestart;
    public Button pauseExit;

    //scoretext gameobj - the text parented to the canvas that displays the score
    public GameObject LVLtext;
    //boss lvl score
    public int LVLscore;

    private GameObject player;
    //for the multiplier visual indicator that pops up when the collar is picked up
    public GameObject multiplierUI;
    public GameObject multiplier2;
    //for the invincible visual indicator that pops up when the berry is picked up
    public GameObject berryUI;
    //int that keeps track of the score
    public int score;
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
    //pause panel
    public GameObject PauseCanvas;
    //scoretext gameobj - the text parented to the canvas that displays the fianl score
    public GameObject endScoreText;
    //multiplier get set that can either get multiplers value or set it to a value
    public int Multiplier { get { return multiplier; } set { multiplier = value; } }

    // Start is called before the first frame update
    void Start()
    {
        //getting the text component and making it 0
        //LVLtext.GetComponent<Text>().text = "0";
        //LVLscore = 0;

        //player is equal to the player object(using tag to find it)
        player = GameObject.FindGameObjectWithTag("Player");

        //buttons
        play.onClick.AddListener(Play);
        pause.onClick.AddListener(Pause);
        restartInGame.onClick.AddListener(Restart);
        restart.onClick.AddListener(Restart);
        exit.onClick.AddListener(Exit);
        muteAll.onClick.AddListener(StopAudio);
        //pause buttons
        pauseResume.onClick.AddListener(PauseResume);
        pauseRestart.onClick.AddListener(PauseRestart);
        pauseExit.onClick.AddListener(PauseExit);

        //getting the text component and making it 0
        scoretext.GetComponent<Text>().text = "0";
        //setting score to 0
        score = 0;

        //getting the text component and making it 0
        coinScore.GetComponent<Text>().text = " 0";
        //coins is 0
        coins = 0;

        InvokeRepeating("callEnum", 3f, 3f);
    }

    void callEnum()
    {
        StartCoroutine(updateDisplay());
    }

    //play method for button
    void Play()
    {
        //unfreeze time
        Time.timeScale = 1;
    }
    //pause resume button method
    void PauseResume()
    {
        PauseCanvas.SetActive(false);
        //unfreeze time
        Time.timeScale = 1;
    }
    //pause method for button
    void Pause()
    {
        PauseCanvas.SetActive(true);
        //freeze time
        Time.timeScale = 0;
    }
    //exit method for button
    void Exit()
    {
        //quit to main menu
        SceneManager.LoadScene(sceneName: "Start");
    }
    //pause exit button method
    void PauseExit()
    {
        PauseCanvas.SetActive(false);
        //reset the boss score back to 0
        StreamWriter outputStream = new StreamWriter(Application.persistentDataPath + "\\BossScore.txt");
        outputStream.WriteLine("0");
        outputStream.Close();
        //quit to main menu
        SceneManager.LoadScene(sceneName: "Start");
    }
    //restart method for button
    void Restart()
    {
        //timescale back to 1
        Time.timeScale = 1;
        //reset the boss score back to 0
        StreamWriter outputStream = new StreamWriter(Application.persistentDataPath + "\\BossScore.txt");
        outputStream.WriteLine("0");
        outputStream.Close();
        //reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //pause restart button method
    void PauseRestart()
    {
        PauseCanvas.SetActive(false);
        //timescale back to 1
        Time.timeScale = 1;
        //reset the boss score back to 0
        StreamWriter outputStream = new StreamWriter(Application.persistentDataPath + "\\BossScore.txt");
        outputStream.WriteLine("0");
        outputStream.Close();
        //reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
            //if r key is pressed (restart)
            if (Input.GetKeyDown(KeyCode.R))
            {
                //timescale back to 1
                Time.timeScale = 1;
            //reset the boss score back to 0
            StreamWriter outputStream = new StreamWriter(Application.persistentDataPath + "\\BossScore.txt");
            outputStream.WriteLine("0");
            outputStream.Close();
            //reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            //if press escape
            if (Input.GetKeyDown("escape"))
            {
            //reset the boss score back to 0
            StreamWriter outputStream = new StreamWriter(Application.persistentDataPath + "\\BossScore.txt");
            outputStream.WriteLine("0");
            outputStream.Close();
            //quit to menu
            SceneManager.LoadScene(sceneName: "Start");
            }
    }

    private void FixedUpdate()
    {
        //if the score is 40, 41 or 42
        if (score == 40 ||score == 41 ||score == 42)
        {
            //invoke the boss event
            fieldBossEvent.Invoke();
        }

        //if the score is 50, 51 or 52
        if (score == 10 || score == 11 || score == 12)
        {
            //invoke the boss event
            forestBossEvent.Invoke();
        }
        
        //if the score is 60, 61 or 62
        if (score == 5 || score == 6 || score == 7)
        {
            //invoke the boss event
            icebossevent.Invoke();
        }
    }
    //method to stop all audio (death)
    void StopAudio()
    {
        //find all audio objects
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        //foreach loop to loop through and stop each one
        foreach (AudioSource audio in allAudioSources)
        {
            //stop audio
            audio.Stop();
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
        multiplier2.SetActive(true);

        //wait 10 seconds
        yield return new WaitForSecondsRealtime(10);

        //set ui to not active
        multiplierUI.SetActive(false);
        multiplier2.SetActive(false);
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
        //stop audio
        StopAudio();
        //reset the boss score back to 0
        StreamWriter outputStream = new StreamWriter(Application.persistentDataPath + "\\BossScore.txt");
        outputStream.WriteLine("0");
        outputStream.Close();

        //when r is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            //reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void updateLVLScore()
    {
        LVLscore = int.Parse(PersistentServices.getScore());
        Debug.Log(LVLscore);
        //having lvl score text reflect the lvl score
        LVLtext.GetComponent<Text>().text = LVLscore.ToString();
    }

    IEnumerator updateDisplay()
    {
        yield return new WaitForSeconds(.5f);
        updateLVLScore();
    }
}
