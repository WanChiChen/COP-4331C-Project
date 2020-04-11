using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomSystem : MonoBehaviour
{
    // List of generated rooms
    public List<GameObject> rooms = new List<GameObject>();

    // List for calculating average distances
    public List<float> distances = new List<float>();

    // Array of room spawners
    public GameObject[] roomSpawners;

    // Rooms with South opening
    public GameObject[] southRooms;

    // Rooms with North opening
    public GameObject[] northRooms;

    // Rooms with East opening
    public GameObject[] eastRooms;

    // Rooms with West opening
    public GameObject[] westRooms;

    // Level exit object
    public GameObject levelExiter;

    // Empty room for plugging up holes
    public GameObject emptyRoom;

    // Flag to check if the level layout is finished generating
    public bool layoutFinished;

    // Flag to check if enitre level generation is finished
    public bool genFinished;

    // Array of enemies
    public GameObject[] enemies;

    // Player object
    private GameObject player;

    // Neural Network
    private NeuralNetwork network;

    // Enemy configurations
    public int[] enemyConfigs = {1, 2, 3, 4, 5, 6, 7, 8};

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        network = GameObject.FindGameObjectWithTag("Network").GetComponent<NeuralNetwork>();
    }

    private void LateUpdate()
    {
        // Check if level generation is finished, if it is then we dont need to do the rest of the update
        if(genFinished)
        {
            return;
        }

        // If level layout done, we want to put the exit in the last room
        if(layoutFinished)
        {
            Instantiate(levelExiter, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
            genFinished = true;
            Debug.Log("GameLevel: " + Variables.GameLevel);
            Debug.Log("Level Size: " + rooms.Count);
            ValidateSize();
            SpawnEnemies();
            InvokeRepeating("CalculateDPS", 1F, 1F);
            InvokeRepeating("AddAverageDistance", 2F, 2F);
            InvokeRepeating("CalculateAverageDistance", 30F, 30F);
        }

        roomSpawners = GameObject.FindGameObjectsWithTag("roomSpawner"); // Update array with all room spawners

        // Go through each spawner, checking to see if it has spawned a room yet
        foreach(GameObject spawner in roomSpawners)
        {
            if(!spawner.GetComponent<RoomSpawner>().spawnedFlag) // If not spawned yet, level is still generating, check again next frame
            {
                return;
            }
        }

        // If program makes it here, level is done generating
        layoutFinished = true;
    }

    // Record the damage done by the player the previous second
    private void CalculateDPS()
    {
        if(Variables.CurrentDPS > Variables.HighestDPS)
        {
            Variables.HighestDPS = Variables.CurrentDPS;
            Debug.Log("HighestDPS: " + Variables.HighestDPS);
        }

        Variables.CurrentDPS = 0;
    }

    // Calculate average distance from nearest enemy
    private void AddAverageDistance()
    {
        try
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            float distance = Vector3.Distance(player.GetComponent<Transform>().position, enemies[0].GetComponent<Transform>().position);

            foreach (GameObject enemy in enemies)
            {
                if (Vector3.Distance(player.GetComponent<Transform>().position, enemy.GetComponent<Transform>().position) > distance)
                {
                    distance = Vector3.Distance(player.GetComponent<Transform>().position, enemy.GetComponent<Transform>().position);
                }
            }

            distances.Add(distance);

            if (distances.Count > 100)
            {
                distances.RemoveAt(0);
            }
        }
        catch (System.Exception e)
        {
        }
    }

    // Calculates average distances recorded
    private void CalculateAverageDistance()
    {
        float sum = 0;

        foreach(float dist in distances)
        {
            sum += dist;
        }

        Variables.AverageDistance = sum / distances.Count;
        Debug.Log("AverageDistance: " + Variables.AverageDistance);
    }

    // Spawn enemies within the rooms
    private void SpawnEnemies()
    {
        List<int> enemyConfigsPriority = new List<int>();
        List<int> used = new List<int>();
        List<AINode> outputCopy = new List<AINode>();
        AINode tempNode;
        int index = 0;

        foreach(AINode node in network.outputLayer)
        {
            outputCopy.Add(node);
        }

        foreach(AINode node in outputCopy)
        {
            Debug.Log("Output: " + node.GetOutput());
        }

        Debug.Log("OutputCopyCount: " + outputCopy.Count);

        for (int i = 0; i < outputCopy.Count; i++)
        {
            tempNode = outputCopy[0];

            for (int j = 0; j < outputCopy.Count; j++)
            {
                if((outputCopy[j].GetOutput() >= tempNode.GetOutput()) && !IsUsed(j, used))
                {
                    tempNode = outputCopy[j];
                    index = j;
                }
            }

            enemyConfigsPriority.Add(enemyConfigs[index]);
            Debug.Log("count: " + enemyConfigsPriority.Count);
            used.Add(index);
        }

        foreach (int val in used)
        {
            Debug.Log("used: " + val);
        }

        foreach (int val in enemyConfigsPriority)
        {
            Debug.Log("val: " + val);
        }
    }

    private bool IsUsed(int num, List<int> used)
    {
        foreach(int n in used)
        {
            if(num == n)
            {
                return true;
            }
        }

        return false;
    }

    // Create a prioritized list of enemy spawns


    // Checks to make sure the level generated is an apporpriate size for the current level
    private void ValidateSize()
    {
        if(Variables.GameLevel < 5)
        {
            // If too small or too big, load new level
            if(rooms.Count < 7 || rooms.Count > 15)
            {
                SceneManager.LoadScene("SampleScene");  // Load new level
            }
        }

        else if(Variables.GameLevel < 20)
        {
            // If too small or too big, load new level
            if (rooms.Count < 11 || rooms.Count > 28)
            {
                SceneManager.LoadScene("SampleScene");  // Load new level
            }
        }

        else
        {
            // If too small or too big, load new level
            if (rooms.Count < 17 || rooms.Count > 100)
            {
                SceneManager.LoadScene("SampleScene");  // Load new level
            }
        }
    }
}
