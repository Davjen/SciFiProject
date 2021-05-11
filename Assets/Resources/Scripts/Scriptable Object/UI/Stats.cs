using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Stats",menuName ="Stats/GeneralStats")]
public class Stats : ScriptableObject
{
    public string Name;
    public float Value;

    //In questo modo 
    public GameEvent onStatsIncrease;

    public virtual void Logic() {}

    public void ModifyStat(float value)
    {
        Value += value;
        onStatsIncrease.Raise();
    }
}

