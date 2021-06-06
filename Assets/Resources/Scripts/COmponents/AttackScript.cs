using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    Animator anim;
    public string notInterruptableSkill = "SpecialAttack";
    public float ConsumableResourceIncrease=5;
    PlayerController owner;

    string performingAttackName;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        owner = GetComponent<PlayerController>();
    }

    private void Update()
    {
        
    }
    public void SetLogic()
    {

    }


    public void PerformAttack(string AttackType)
    {
        if (!CheckIfAlreadyPlaying(AttackType))
        {
            performingAttackName = AttackType;
            anim.SetTrigger(AttackType);
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy") && CheckIfAlreadyPlaying(performingAttackName))
        {
            Debug.Log("colpito");
            owner.Player.consumableResource.IncreaseResource(ConsumableResourceIncrease);
        }
    }




}
