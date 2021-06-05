using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Enemy_SO enemyStats;
    public GameObject weapon;

    [HideInInspector] public Movement moveScr;
    [HideInInspector] public NavMeshAgent agent;
    Animator animator;
    Material mat;

    // Start is called before the first frame update
    void Start()
    {
        moveScr = GetComponent<Movement>();
        animator = GetComponent<Animator>();
        mat = GetComponent<SpriteRenderer>().material;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        //AwakeAnim();
    }

    void Update()
    {
        float dir = transform.position.x - agent.steeringTarget.x;
        Debug.Log(-dir);
        moveScr.FlipSprite(-dir);
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
        if (enemyStats.isDead) return;

        if (enemyStats.HP <= damage)
        {
            Die();
        }
        else
        {
            enemyStats.HP -= damage;
            mat.SetFloat("Damaged", 1);
            Invoke("TurnOffDamage", 0.1f);
        }
    }
    private void TurnOffDamage()
    {
        mat.SetFloat("Damaged", 0);
    }
    void Die()
    {
        enemyStats.isDead = true;
        enemyStats.HP = 0;
        animator.SetTrigger("Die");
        GetComponent<Collider2D>().enabled = false;
        weapon.SetActive(false);
    }



}
