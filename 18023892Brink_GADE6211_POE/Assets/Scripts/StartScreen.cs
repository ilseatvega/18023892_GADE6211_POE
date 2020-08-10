using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//added to control scene
using UnityEngine.SceneManagement;
//so that i can use UI
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    //buttons
    public Button play;
    public Button leaderboard;
    public Button exit;

    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(Play);
        leaderboard.onClick.AddListener(Leaderboard);
        exit.onClick.AddListener(Exit);

        void Play()
        {
            //load fieldlevel
            SceneManager.LoadScene(sceneName: "FieldLevel");
            //set timescale back to 1
            Time.timeScale = 1;
        }

        void Leaderboard()
        {
            //load leaderboard
            SceneManager.LoadScene(sceneName: "Leaderboard");
        }

        void Exit()
        {
            //quit application
            Application.Quit();
        }

    }
}
