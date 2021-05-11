using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("COMPONENTS")]
    AttackScript attackScript;
    Movement movement;
    Teleport teleport;
    ReflectiveShield shield;
    public float Speed;
    public AttackType NormalAttack, SpecialAttack, SpecialAttack2;

    public PlayerStats player;
    public float testTimerCHarge = 0.7f;
    bool canMove = true;

    float timer = 0.7f;
    Vector2 position2Spawn;

    //DA RIMUOVERE
    public GameObject debugger;


    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        attackScript = GetComponent<AttackScript>();
        teleport = GetComponent<Teleport>();
        shield = GetComponent<ReflectiveShield>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Q))
        {
            //to do->defence move
            shield.PerformShield("pippo");
        }



        if (Input.GetKey(KeyCode.Space))
        {
            testTimerCHarge -= Time.deltaTime;
            Debug.Log("ciao");
            if (testTimerCHarge <= 0)
            {
                attackScript.PerformAttack("SpecialAttack");
                Debug.Log("entro");
                testTimerCHarge = .7f;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("entroupo");
            if (testTimerCHarge <= .6f)
            {
                attackScript.PerformAttack("NormalAttack");
                testTimerCHarge = .7f;
            }
        }

        if (canMove)
        {
            movement.PerformMove(Speed, SetInput().x);
        }

        if (Input.GetMouseButtonDown(1))
        {
            teleport.PerformTeleport(out position2Spawn);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
        movement.PerformMove(0, SetInput().x);
        canMove = false;
    }

    public void EnableMovement()
    {
        canMove = true;
    }
}
