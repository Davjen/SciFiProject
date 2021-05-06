using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy_SO enemyStats;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }
    public void TakeDamage(float damage)
    {
        if (enemyStats.HP <= damage)
        {
            Die();
        }
        else
        {
            enemyStats.HP -= damage;
            animator.SetTrigger("Damage");
        }
    }
    void Die()
    {
        enemyStats.isDead = true;
        enemyStats.HP = 0;
        animator.SetTrigger("Die");
    }

}
