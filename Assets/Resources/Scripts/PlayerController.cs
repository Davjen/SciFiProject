using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    AttackScript attackScript;
    public Movement movement;
    public float Speed;
    public AttackType NormalAttack, SpecialAttack, SpecialAttack2;

    public PlayerStats player;
    public float testTimerCHarge = 0.7f;
    bool canMove = true;

    //DA RIMUOVERE
    public GameObject debugger;


    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        attackScript = GetComponent<AttackScript>();
    }

    // Update is called once per frame
    void Update()
    {

        //TEST MOUSE SPAWN-->DA SPOSTARE SU TP
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.LogWarning("perchè spawna giusto ma non si vede l'oggetto?");
           GameObject go= Instantiate(debugger);
            go.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetKey(KeyCode.C))
        {
            testTimerCHarge -= Time.deltaTime;
            if (testTimerCHarge <= 0)
            {
                attackScript.PerformAttack("SpecialAttack");
                testTimerCHarge = .7f;
            }
        }
        else
        {
            testTimerCHarge = .7f;
        }
            
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attackScript.PerformAttack("NormalAttack");
        }
        if (canMove)
        {
            movement.PerformMove(Speed, SetInput().x);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //eventuale guadagno di fury per il supercolpo?
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
