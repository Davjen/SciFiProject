using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectiveShield : MonoBehaviour
{
    Animator anim;
    public string AnimationName;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PerformShield(string skillName)
    {
        //TO DO -> Consumo statistica consumabile
        //Sulla base del tipo di attacco può essere completamente protettiva o parzialmente.
        if (!CheckIfAlreadyPlaying())
            anim.SetTrigger(skillName);
    }
    bool CheckIfAlreadyPlaying()//RISCRIVERE GENERALE PER TUTTI
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        return info.IsName(AnimationName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //consuma la risorsa
        collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("aTTACKmoDE");
    }
}
