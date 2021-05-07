using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    AttackScript attackScript;
    Movement movement;
    public float Speed;
    public AttackType NormalAttack, SpecialAttack, SpecialAttack2;

    public float testTimerCHarge = 1.5f;
    bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        attackScript = GetComponent<AttackScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //TO DO->GESTIRE BENE LE ANIMAZIONI IN MODO CHE VENGANO ESEGUITE SOLO SE NON SONO GIà IN ESECUZIONE.

        //impedire la possibilità di muoversi mentre si fa l'attacco speciale.
        if (Input.GetKey(KeyCode.C))
        {
            testTimerCHarge -= Time.deltaTime;
            if (testTimerCHarge <= 0)
            {
                attackScript.PerformAttack(SpecialAttack);
                testTimerCHarge = 1.5f;
            }
        }
        else
        {
            testTimerCHarge = 1.5f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attackScript.PerformAttack(NormalAttack);
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
