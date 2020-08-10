using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public Button back;
    // Start is called before the first frame update
    void Start()
    {
        back.onClick.AddListener(Back);
    }
    void Back()
    {
        //quit to main menu
        SceneManager.LoadScene(sceneName: "Start");
    }
}
