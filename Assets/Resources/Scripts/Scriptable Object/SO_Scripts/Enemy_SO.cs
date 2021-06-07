using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Enemy",menuName = "Enemy/Enemy")]
public class Enemy_SO : ScriptableObject
{
    public float HP;
    public float xpToGain;
    public float Speed;
    public bool HaveTarget;
    public bool isDead;

    public EnemyAttack_SO attackToPerform;

    [Header("START PROP")]
    public float StartHP;

    [Header("IA DISTANCE")]
    [SerializeField] private Range[] ranges; 
    public float PatrolMaxDist = 4;
    public float DistForEnterChase;
    public float DistForExitChase;
    public float DistForEnterAttack;
    public float DistForExitAttack;
    public float AwakeDistance;
    public float SleepDistance;
    public Dictionary<RangeToCheck, Range> Ranges = new Dictionary<RangeToCheck, Range>();
    [Range(0, 100)]
    //non implementato
    public float chanceToStartPatrol = 50f; //probabilità di iniziare subito il patrol senza aspettare che il player si avvicini  


    public void Reset()
    {
        HP = StartHP;
        isDead = false;
    }
    private void OnEnable()
    {
        Reset();
        Ranges.Clear();
        foreach (Range val in ranges)
        {
            Ranges.Add(val.type, val);
        }
    }
}

[Serializable]
public struct Range
{
    public RangeToCheck type;
    public float EnterValue;
    public float ExitValue;
}
