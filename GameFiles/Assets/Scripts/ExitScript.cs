using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    PlayerProgressTracker progress;

    private void Awake()
    {
        progress = GameObject.Find("PlayerProgressTracker").GetComponent<PlayerProgressTracker>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) // If object is player, generate new level
        {
            progress.updateProgress();
            Variables.GameLevel = Variables.GameLevel + 1;
            SceneManager.LoadScene(1);  // Load new level
        }
    }
}
