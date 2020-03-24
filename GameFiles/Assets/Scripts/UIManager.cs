using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luminosity.IO;


public class UIManager : MonoBehaviour
{

    GameObject[] pauseObjects;

    //intialize object
    void Start()
    {

    }

    private void Awake()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();
    }

    private void Update()
    {
        if (InputManager.GetButtonDown("Pause"))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }
    }
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject obj in pauseObjects)
        {
            obj.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject obj in pauseObjects)
        {
            obj.SetActive(false);
        }
    }

}
