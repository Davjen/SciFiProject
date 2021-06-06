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


    //TO DO-> TUTTI FIGLI DI CLASSE ASTRATTA CON ABSTRACT UPDATE.


    [Space]
    public float Speed;
    public float ConsumableResourceCost;
    public PlayerStats Player;
    public float testTimerCHarge = 0.7f; 
    bool canMove = true;


    public ConsumableResource PlayerResource { get => Player.consumableResource;}

    Vector2 position2Spawn;

    



    // Start is called before the first frame update
    void Start()
    {
        Player.ResetHP();
        Player.SetInitialConsumable(0);
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Player.consumableResource.DecreaseResource(ConsumableResourceCost))
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
           
            if (testTimerCHarge <= 0)
            {
                attackScript.PerformAttack("SpecialAttack");
                
                testTimerCHarge = .7f;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            
            if (testTimerCHarge <= .6f)
            {
                attackScript.PerformAttack("NormalAttack");
                testTimerCHarge = .7f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //SE DEVO INSERIRE QUALCHE LOGICA PARTICOLARE QUI DENTRO E NON VOGLIO CHE VENGA TRIGGHERATO DAGLI ATTACCHI CHE ESEGUO DEVO METTERE UN RB ALL'OGGETTO RAY
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
        Player = player2Switch;
        //chiamare animazione comparsa sul nuovo
    }

    float CheckHpStatus()
    {
        return Player.Hp;
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
        if (Player.IsDead) return;

        if (Player.Hp <= damage)
        {
            //player morto
            Player.IsDead = true;

        }
        else
        {
            Player.Hp -= damage;
        }
    }
}
