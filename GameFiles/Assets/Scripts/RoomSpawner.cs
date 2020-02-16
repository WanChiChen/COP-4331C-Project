using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField, Tooltip("Required opening direction for the room (NSEW)")]
    public char roomOpening;

    // Organized selection of rooms
    private RoomSystem roomPalette;

    // Random value
    private int rand;

    // Flag to check if room has already been spawned
    private bool spawnedFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        // assign RoomSystem object
        roomPalette = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomSystem>();

        // Invoke function on a delay to make sure spawning occurs properly
        Invoke("SpawnRoom", 0.1f);
    }

    // Update is called once per frame
    void SpawnRoom()
    {
        if(!spawnedFlag)
        {
            // If we require a room with a North opening, choose from selection of North doors
            if (roomOpening == 'N')
            {
                rand = Random.Range(0, roomPalette.northRooms.Length);
                Instantiate(roomPalette.northRooms[rand], transform.position, Quaternion.identity);
            }

            // If we require a room with a South opening, choose from selection of South doors
            if (roomOpening == 'S')
            {
                rand = Random.Range(0, roomPalette.southRooms.Length);
                Instantiate(roomPalette.southRooms[rand], transform.position, Quaternion.identity);
            }

            // If we require a room with a East opening, choose from selection of East doors
            if (roomOpening == 'E')
            {
                rand = Random.Range(0, roomPalette.eastRooms.Length);
                Instantiate(roomPalette.eastRooms[rand], transform.position, Quaternion.identity);
            }

            // If we require a room with a West opening, choose from selection of West doors
            if (roomOpening == 'W')
            {
                rand = Random.Range(0, roomPalette.westRooms.Length);
                Instantiate(roomPalette.westRooms[rand], transform.position, Quaternion.identity);
            }

            // Raise flag now that we have spawned a room
            spawnedFlag = true;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If a room has already been generated here, dont spawn another one
        if(other.CompareTag("roomSpawner"))
        {
            // ensure object isn't null
            try
            {
                // In this case, we will have open doors to the rest of the scene, so we place an empty room to block the path
                if (!other.GetComponent<RoomSpawner>().spawnedFlag && !spawnedFlag)
                {
                    Instantiate(roomPalette.emptyRoom, transform.position, Quaternion.identity);
                    spawnedFlag = true;
                }
            }

            catch (System.Exception e)
            {
            }

            spawnedFlag = true;
        }
    }
}
