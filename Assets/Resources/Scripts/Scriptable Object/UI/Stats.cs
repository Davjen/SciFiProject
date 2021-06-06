using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsName
{
    MaxHp,Strenght,Toughness,CritChance,Intelligence,Experience
}
[CreateAssetMenu(fileName ="Stats",menuName ="Stats/GeneralStats")]

public class Stats : ScriptableObject
{
    public StatsName Name;
    public float Value;

//per UI Refresh
    public GameEvent onStatsIncrease;

    public void ModifyStat(float value)
    {
        Value += value;
        //onStatsIncrease.Raise();
    }
}

