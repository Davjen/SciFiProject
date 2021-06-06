using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectiveShield : Component
{

    //TO DO -->SPOSTARE TUTTO SU SCRIPTABLE OBJECT
    Animator anim;
    public string AnimationName;
    public int ConsumableResourceCost;

 
    PlayerController owner;
    // Start is called before the first frame update
    void Start()
    {
        owner = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame


    public void PerformShield(string skillName)
    {

        //Sulla base del tipo di attacco pu� essere completamente protettiva o parzialmente.
        if (!CheckIfAlreadyPlaying())
        {
            //if(enough consumable resource)
            anim.SetTrigger(skillName);
            //TO DO->CONSUME CONSUMABLE RESOURCE
        }

    }
    bool CheckIfAlreadyPlaying()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        return info.IsName(AnimationName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        IreflectDamage bulletToReflect = collision.GetComponent<IreflectDamage>();

        if (bulletToReflect !=null && CheckIfAlreadyPlaying() && owner.PlayerResource.Value>= ConsumableResourceCost)
        {
            owner.PlayerResource.DecreaseResource(ConsumableResourceCost);
            bulletToReflect.ReflectDamage();          
        }
    }
}
