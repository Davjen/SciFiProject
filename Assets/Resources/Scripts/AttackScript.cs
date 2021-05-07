using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    Animator anim;
    bool timedAttack = false;
    bool attack = false;

    AttackType attackToPerform;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (attack)
        {
            PerformAttack(attackToPerform);
        }
    }
    public void PerformAttack(AttackType attack)
    {
        anim.SetTrigger(attack.AttackTypeName);
    }

    public void PerformAttackNow(AttackType attackk)
    {
        attack = true;
        attackToPerform = attackk;

    }

    public void PerformTimedAttack()
    {
        timedAttack = !timedAttack;
    }

    void TimedAttack() { }

}
