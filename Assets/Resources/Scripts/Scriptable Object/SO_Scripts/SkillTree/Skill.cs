using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using System.Reflection;


public enum SkillType
{
    Boost,
    Behaviour,
    Hybrid

}


//Generic skill
//A skill can cast different effects depending on its time
//A boost skill can boost referenced player stats
//A behaviour skill can add behaviours to referenced player, by adding new components
//An Hybrid skill can do both

[CreateAssetMenu(fileName = "Skill", menuName = "Skill Tree/Skill")]

public class Skill : ScriptableObject
{
    [Header("Head")]

    public string Name;
    public SkillType SkillType;
    public string Description;
    //public SkillEffect Effect;


    
    [Header("Boosts")]
    public int AttackBoost = 0;
    public int ThoughnessBoost = 0;
    public int ConstitutionBoost = 0;


    [Header("Behaviours")]
    public string[] Behaviours;

    public SkillNode Owner { get; protected set; }

    public void Cast()
    {
        switch (SkillType)
        {
            case SkillType.Boost:
                Boost(Owner.Player);
                break;
            case SkillType.Behaviour:
                Behave(Owner.Player);
                break;
            case SkillType.Hybrid:
                Boost(Owner.Player);
                Behave(Owner.Player);
                break;
        }
    }


    void Boost(Player player)
    {
        //boost stats
    }

    void Behave(Player player)
    {
        string ns = GetType().Namespace;

        for (int i = 0; i < Behaviours.Length; i++)
        {

            Type t = Type.GetType(ns+"."+ Behaviours[i]);
            player.gameObject.AddComponent(t);
            
        }

    }

    

    public void SetOwner(SkillNode node)
    {
        Owner = node;

    }


}
