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
        //checks distace from player, when close begins to move towards.
        //Debug.Log((target.transform.position - this.transform.position).sqrMagnitude);
        if ((player.transform.position - this.transform.position).sqrMagnitude < detectDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
