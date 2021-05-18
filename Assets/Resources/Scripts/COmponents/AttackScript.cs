using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    Animator anim;
    public string notInterruptableSkill = "SpecialAttack";

    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }
    public void SetLogic()
    {

    }


    public void PerformNormalAttack(string AttackType)
    {
        if (!CheckIfAlreadyPlaying(AttackType))
            anim.SetTrigger(AttackType);
    }

    /// <summary>
    /// Check if is already playing the same animation or not interruptable skill.
    /// </summary>
    /// <param name="AttackType"></param>
    /// <returns></returns>
    bool CheckIfAlreadyPlaying(string AttackType)
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        return info.IsName(AttackType) || info.IsName(notInterruptableSkill);
    }





}
