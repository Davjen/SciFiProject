using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZapperAttack", menuName = "Enemy/EnemyAttack/ZapperAttack")]
public class ZapperAttack : EnemyAttack_SO
{
    public override void PerformAttack(PlayerController player)
    {
        player.TakeDamage(damage);
    }
}
