using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    PlayerProgressTracker progress;

    // Player object
    private GameObject player;

    // Boss object
    public GameObject boss;

    private bool spawned = false;

    private void Awake()
    {
        progress = GameObject.Find("PlayerProgressTracker").GetComponent<PlayerProgressTracker>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(GetPlayerDistance() <= 8f && !spawned)
        {
            GameObject thisBoss = Instantiate(boss, transform.position + new Vector3(0, -1, 0), Quaternion.identity);
            spawned = true;
        }
    }

    private float GetPlayerDistance()
    {
        return Vector3.Distance(player.GetComponent<Transform>().position, transform.position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) // If object is player, generate new level
        {
            progress.updateProgress();
            Variables.GameLevel = Variables.GameLevel + 1;
            SceneManager.LoadScene("SampleScene");  // Load new level
            progress.enteredPortal = true;
        }
    }
}
