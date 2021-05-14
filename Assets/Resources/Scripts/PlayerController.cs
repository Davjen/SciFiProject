using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("COMPONENTS")]
    public AttackScript attackScript;
    public Movement movement;
    public Teleport teleport;
    public ReflectiveShield shield;

    [Space]
    public float Speed;
    public float ConsumableResourceCost;
    public PlayerStats player;
    public float testTimerCHarge = 0.7f;
    bool canMove = true;

    Vector2 position2Spawn;

    //DA RIMUOVERE



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SpecialAttack();
        Attack();
        Move();
        TeleportOnClick();
    }

    private void SpecialAttack()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (player.consumableResource.DecreaseResource(ConsumableResourceCost))
                shield.PerformShield("SpecialAttack2");

        }
    }

    private void TeleportOnClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            teleport.PerformSimpleTeleport(out position2Spawn);
        }
    }

    private void Move()
    {
        if (canMove)
        {
            movement.PerformMove(Speed, SetInput());
        }
    }

    private void Attack()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            testTimerCHarge -= Time.deltaTime;
            Debug.Log("ciao");
            if (testTimerCHarge <= 0)
            {
                attackScript.PerformNormalAttack("SpecialAttack");
                Debug.Log("entro");
                testTimerCHarge = .7f;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("entroupo");
            if (testTimerCHarge <= .6f)
            {
                attackScript.PerformNormalAttack("NormalAttack");
                testTimerCHarge = .7f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        player.consumableResource.IncreaseResource(100);
        //eventuale guadagno di fury per il supercolpo?
    }

    public void Teleport()
    {
        transform.position = position2Spawn;
    }
    Vector2 SetInput()
    {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        return new Vector2(x, y);
    }

    public void SwitchPlayer(PlayerStats player2Switch)
    {
        //-->chiamare animazione scomparsa sul vecchio
        player = player2Switch;
        //chiamare animazione comparsa sul nuovo
    }

    float CheckHpStatus()
    {
        return player.Hp;
    }

    public void DisableMovement()
    {
        movement.PerformMove(0, SetInput());
        canMove = false;
    }

    public void EnableMovement()
    {
        canMove = true;
    }

    public void TakeDamage(float damage)
    {
        if (player.IsDead) return;

        if (player.Hp <= damage)
        {
            //player morto
            player.IsDead = true;

        }
        else
        {
            player.Hp -= damage;
        }
    }
}
