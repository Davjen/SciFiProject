using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill Branch", menuName = "Skill Tree/Skill Branch")]

//single skills branch
//manages multiple skill nodes, each with its own skill
public class SkillBranch : ScriptableObject
{
    public string BranchName;
    public int BranchIndex=0;

    public SkillNode[] Skills;

    public SkillTree Owner { get; protected set; }
    public Player Player { get; protected set; }


    SkillNode StartSkill;


    public void Init()
    {
        Player = Owner.Player;

        if (this == Owner.StartBranch)
        {
            StartSkill = Skills[0];
            StartSkill.SetAvailable(true);
        }


        for (int i = 0; i < Skills.Length; i++)
        {
            Skills[i].SetNodeOwner(this);
            Skills[i].Init();

        }

    }

    public void SetBranchOwner(SkillTree tree)
    {
        Owner = tree;
    }

    //WARNING: doesn't unlock skill
    public void SetSkillNodeAvailable(SkillNode node, bool b)
    {
        if (SkillTree.Contains(node, Skills))
            node.SetAvailable(b);

    }


    public bool UnlockNextSkillNode(SkillNode node)
    {
        bool result = false;

        if (SkillTree.Contains(node,Skills))
        {
            if (node.UnlockNextSkillNode())
                result = true;

        }
            return result;
    }

  

    

}
