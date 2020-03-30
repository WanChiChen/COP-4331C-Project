using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{

    public float cooldown;
    public float dmg;
    public float projectileForce;
    public Transform Player;
    public GameObject EnemyBullet;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootPlayer());
    }

    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(cooldown);
        if (Player != null)
        {
            GameObject projectile = Instantiate(EnemyBullet, transform.position, Quaternion.identity);
            Vector2 myPos = transform.position;
            Vector2 playerPos = Player.position;
            Vector2 direction = (playerPos - myPos).normalized;
            projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            projectile.GetComponent<EnemyProjectile>().damage = dmg;
            StartCoroutine(ShootPlayer());
        }
    }
}
