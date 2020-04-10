using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Luminosity.IO;

public class SceneControl : MonoBehaviour
{
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
}
