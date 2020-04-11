using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : EnemyAttack
{
    public float range;
    public float cooldown;
    public float dmg;
    public float projectileForce;
    public GameObject EnemyBullet;
    private Vector2 distance;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        distance = player.transform.position - this.transform.position;
        StartCoroutine(ShootPlayer());
    }

    void Update()
    {
        distance = player.transform.position - this.transform.position;
    }

    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(cooldown);
        if (distance.sqrMagnitude <= range)
        {
           
            GameObject projectile = Instantiate(EnemyBullet, transform.position, Quaternion.identity);
            Vector2 myPos = transform.position;
            Vector2 playerPos = player.position;
            Vector2 direction = (playerPos - myPos).normalized;
            projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            projectile.GetComponent<EnemyProjectile>().damage = dmg;
            
        }
        if (player != null)
        {
            StartCoroutine(ShootPlayer());
        }
    }
}
