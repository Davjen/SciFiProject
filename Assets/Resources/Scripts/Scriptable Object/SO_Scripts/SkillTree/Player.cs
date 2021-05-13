using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SkillTree Tree;

    int counter=0;

    private void Start()
    {
        
        Tree.Init(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Tree.Branches[1].Skills[counter].UnlockSkill();

            counter++;

        }
    }

}