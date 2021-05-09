using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy_SO enemyStats;

    Animator animator;
    [HideInInspector] public Movement moveScr;

    // Start is called before the first frame update
    void Start()
    {
        moveScr = GetComponent<Movement>();
        animator = GetComponent<Animator>();
        //AwakeAnim();

    }

    void Update()
    {
        if (!enemyStats.isDead)
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    TakeDamage(10);
            //}
            //if (Input.GetKeyDown(KeyCode.Q))
            //{
            //    animator.SetTrigger("Awake");
            //}
            //if (Input.GetKeyDown(KeyCode.T))
            //{
            //    Attack();
            //}
            //moveScr.PerformMove(enemyStats.Speed, SetInput().x);
        }
        else
        {
            //moveScr.PerformMove(0, 0);
        }

    }
    public Vector2 SetInput()
    {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


        return new Vector2(x, y);
    }
    public void AwakeAnim()
    {
        animator.SetTrigger("Awake");
    }
    public void Attack()
    {
        animator.SetTrigger("Attack");
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("entrato");
            TakeDamage(10);
        }
    }

}
