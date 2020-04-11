using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Luminosity.IO;

public class SceneControl : MonoBehaviour
{
    public bool newGame = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        checkNewGame();
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGameScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
        checkNewGame();
    }

    public void SavePlayerPref()
    {
        InputManager.Save();
    }

    public void LoadPlayerPref()
    {
        InputManager.Load();
    }

    private void Awake()
    {
        LoadPlayerPref();
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            InputManager.SetControlScheme("Default", PlayerID.One);
        }
    }

    public void checkNewGame()
    {
        if(newGame == true)
        {
            PlayerProgressTracker progress = GameObject.Find("PlayerProgressTracker").GetComponent<PlayerProgressTracker>();
            progress.loadDefault();
            progress.updateProgress();
        }
    }
}
