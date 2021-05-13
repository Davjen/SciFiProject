using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour
{

    EnemyController enemy;
    Enemy_SO enemyStats;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInParent<EnemyController>();
        enemyStats = enemy.enemyStats;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemyStats.attackToPerform.PerformAttack(collision.GetComponent<PlayerController>());
        }
    }
}
