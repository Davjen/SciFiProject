using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack_SO : ScriptableObject
{
    public float damage;
    public float chance;
    public PlayerController player;

    public abstract void PerformAttack(PlayerController player);
}
