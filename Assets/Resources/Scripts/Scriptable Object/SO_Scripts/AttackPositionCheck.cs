using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackPositionCheck", menuName = "IA/AttackPositionCheck")]
public class AttackPositionCheck : State
{
    private float direction = 0;
    public override void OnExitState()
    {
        return;
    }

    public override void StateUpdate()
    {

        if (Owner.moveScr.canFlip)
        {
            Owner.dir = Owner.transform.position.x - player.transform.position.x;
        }
        if (Mathf.Abs(Owner.transform.position.x - player.transform.position.x) > Owner.enemyStats.attackPositionDistanceX + 0.01f ||
            Mathf.Abs(Owner.transform.position.y - player.transform.position.y) > Owner.enemyStats.attackPositionDistanceY + 0.01f)
        {
            anim.SetBool("OnAttackPosition", false);
        }

    }
    public override void OnEnterState(EnemyController owner)
    {
        base.OnEnterState(owner);
    }
}
