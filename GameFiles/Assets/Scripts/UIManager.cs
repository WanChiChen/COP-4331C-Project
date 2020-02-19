using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private AssetBundle sceneAssetBundle;
    private string[] scenePath;

    //intialize object
    void Start()
    {
        sceneAssetBundle = AssetBundle.LoadFromFile("Assets/Scenes");
        scenePath = sceneAssetBundle.GetAllScenePaths();

    }

    //Load an input scene
    public void LoadGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(scenePath[0]);
    }
}
