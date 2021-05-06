using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    public void PerformAttack(AttackType attack)
    {
        anim.SetTrigger(attack.AttackTypeName);
    }
}
