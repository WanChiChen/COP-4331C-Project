using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) // If object is player, generate new level
        {
            SceneManager.LoadScene("SampleScene");  // Load new level
        }
    }
}
