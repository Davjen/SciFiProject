using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//single Skill Node
//Manages generic single skill 
//Manages skill events by UI interactions

[CreateAssetMenu(fileName = "Skill Node", menuName = "Skill Tree/Skill Node")]
public class SkillNode : ScriptableObject
{

    public Skill Skill;

    public SkillNode[] NextSkills;


    public List<SkillNode> PrevSkills { get; protected set; }

    public bool Available { get; protected set; }
    public SkillBranch Owner { get; protected set; }
    public Player Player { get; protected set; }


    public bool Unlockable { get { return CheckIfUnlockable(); } }

    public void Init()
    {
        PrevSkills = new List<SkillNode>();

        Player = Owner.Player;

        Skill.SetOwner(this);

        if (NextSkills != null)
        {

            for (int i = 0; i < NextSkills.Length; i++)
            {
                NextSkills[i].SetPrevSkill(this);
            }


        }

    }

    //private void OnEnable()
    //{
    //    SkillsEventSystem.OnSkillUnlock.AddListener(OnSkillUnlock);
    //}

    //private void OnDisable()
    //{
    //    SkillsEventSystem.OnSkillUnlock.RemoveListener(OnSkillUnlock);

    //}

    public void SetPrevSkill(SkillNode node)
    {
        if (!PrevSkills.Contains(node))
            PrevSkills.Add(node);
    }

    public void OnSkillUnlock(SkillNode node, int level)
    {
        if (node.Owner == Owner)
        {
            if (node == this)
            {
                UnlockSkillNode();

            }

        }

    }

    //WARNING: doesn't unlock skill
    public void SetAvailable(bool b)
    {
        Available = b;
    }

    public void SetNodeOwner(SkillBranch branch)
    {
        Owner = branch;
    }

    public bool UnlockSkillNode()
    {
        bool result = false;

        if (!Available)
        {
            if (Unlockable)
            {
                SetAvailable(true);
                UnlockSkill();
                result = true;
            }
        }

        return result;
    }

    public bool CheckIfUnlockable()
    {
        bool result= false;
        int availableCount = 0;


        for (int i = 0; i < PrevSkills.Count; i++)
        {
            if (PrevSkills[i] != null)
            {
                if (PrevSkills[i].Available)
                    availableCount++;
            }
        }

        if (availableCount == PrevSkills.Count)
            result = true;

        return result;
    }


    public SkillNode GetNextLockedSkillNode()
    {
        for (int i = 0; i < NextSkills.Length; i++)
        {
            if (NextSkills[i] != null)
            {
                if (!NextSkills[i].Available)
                {
                    return NextSkills[i];
                }
            }
        }

        return null;
    }

    public bool UnlockNextSkillNode()
    {
        bool result = false;

        SkillNode node = GetNextLockedSkillNode();

        if (node == null)
            return result;

        if (node.Unlockable)
        {

            node.SetAvailable(true);
            node.UnlockSkill();
            result = true;

        }

        return result;
    }

    public bool UnlockNextSkillNode(SkillNode node)
    {
        bool result = false;

        if (SkillTree.Contains(node, NextSkills))
        {

            if (node.Unlockable)
            {

                node.SetAvailable(true);
                node.UnlockSkill();
                result = true;

            }
        }

        return result;
    }

    //WARNING: to set private
    public void UnlockSkill()
    {
        Skill.Cast();
    }

}
