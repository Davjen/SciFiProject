using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill Tree", menuName = "Skill Tree/Skill Tree")]

//entire skill tree
//collection of skill branches
//owned by a Player; all skills of the skill tree will affect the referenced Player
public class SkillTree : ScriptableObject
{
    public SkillBranch[] Branches;
    public Player Player { get; protected set; }

    public SkillBranch StartBranch { get; protected set; }



    public void Init(Player player)
    {
        Player = player;
        StartBranch = Branches[0];

        for (int i = 0; i < Branches.Length; i++)
        {
            Branches[i].SetBranchOwner(this);
            Branches[i].Init();
        }



    }

    public static bool Contains(SkillNode node, SkillNode[] skills)
    {
        if (node == null)
            return false;

        for (int i = 0; i < skills.Length; i++)
        {
            if (skills[i] == node)
                return true;

        }

        return false;
    }


}
