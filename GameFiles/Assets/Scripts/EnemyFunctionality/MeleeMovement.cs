using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeMovement : EnemyMovement
{
    

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 distance = player.transform.position - this.transform.position;
        //checks distace from player, when close begins to move towards.
        Debug.Log(distance.sqrMagnitude);
        if (distance.sqrMagnitude < runAwayParam)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -1 * speed);
        }
        if (distance.sqrMagnitude < detectDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        //once hit move a set amount of units away then repeat
    }
}
