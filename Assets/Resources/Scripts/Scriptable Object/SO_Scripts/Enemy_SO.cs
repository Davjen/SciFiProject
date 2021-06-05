using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [Header("IA_PATROL")]
    public float PatrolMaxDist = 4;
    public float DistForEnterChase;
    public float DistForExitChase;
    public float DistForEnterAttack;
    public float DistForExitAttack;
    public float AwakeDistance;
    public float SleepDistance;
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
    }
}
