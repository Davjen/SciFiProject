using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZapperAttackState", menuName = "IA/Zapper/AttackState")]
public class ZapperAttackState : State
{
    public EnemyAttack_SO attackToPerform;
    private float direction = 0;
    public override void OnExitState()
    {
        return;
    }

    public override void StateUpdate()
    {


    }
    public override void OnEnterState(EnemyController owner)
    {
        base.OnEnterState(owner);
        owner.enemyStats.attackToPerform = attackToPerform;
        owner.agent.isStopped = true;
    }
}
