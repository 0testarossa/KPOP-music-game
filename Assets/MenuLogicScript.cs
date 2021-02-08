using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLogicScript : MonoBehaviour
{
    Button startButton;
    Button exitButton;
    // Start is called before the first frame update
    void Start()
    {
        startButton = GameObject.Find("Canvas/StartButton").GetComponent<Button>();
        exitButton = GameObject.Find("Canvas/ExitButton").GetComponent<Button>();
        startButton.onClick.AddListener(delegate { onStartButtonClick(); });
        exitButton.onClick.AddListener(delegate { onExitButtonClick(); });
    }

    void onStartButtonClick()
    {
        Scene sceneLoaded = SceneManager.GetActiveScene();
        SceneManager.LoadScene(sceneLoaded.buildIndex + 1);
    }

    void onExitButtonClick()
    {
        Application.Quit();
    }


}
