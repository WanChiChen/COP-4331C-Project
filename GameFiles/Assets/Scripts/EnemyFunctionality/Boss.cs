using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : EnemyAttack
{
    public GameObject Blocker;
    protected Vector2 distance;
    protected Vector3 playerPos;
    protected Vector3 playerDirection;
    protected Quaternion playerRotation;
    public float detect;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        distance = player.transform.position - this.transform.position;
        StartCoroutine(SpawnPush()); 
    }

    // Update is called once per frame
    void Update()
    {
        distance = player.transform.position - this.transform.position;
        playerPos = player.transform.position;
        playerDirection = player.transform.forward;
        playerRotation = player.transform.rotation;
    }

    IEnumerator SpawnPush()
    {
        if (distance.sqrMagnitude <= detect)
        {
            Vector3 spawnPos = playerPos + playerDirection * 4;
            Instantiate(Blocker, spawnPos, Quaternion.identity);
        }
        yield return new WaitForSeconds(5);
        StartCoroutine(SpawnPush());
    }
}
