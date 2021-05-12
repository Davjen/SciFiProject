using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectiveShield : MonoBehaviour
{
    Animator anim;
    public string AnimationName;

    public PlayerStats player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame


    public void PerformShield(string skillName)
    {
        //TO DO -> Consumo statistica consumabile
        //Sulla base del tipo di attacco può essere completamente protettiva o parzialmente.
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

        //consuma la risorsa
        //collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("aTTACKmoDE");
        //I proiettili avranno interfaccia
        if (collision.tag == "Bullet")
        {  
            Destroy(collision.gameObject);
        }
    }
}
