using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    Animator anim;

    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    public void PerformAttack(AttackType attack)
    {
        if (!CheckIfAlreadyPlaying(attack))
            anim.SetTrigger(attack.AttackTypeName);
    }


    bool CheckIfAlreadyPlaying(AttackType attack)
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        return info.IsName(attack.AttackTypeName);
    }





}
