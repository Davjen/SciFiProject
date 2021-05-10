using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChaseState", menuName = "IA/ChaseState")]
public class ChaseTarget : State
{
    
    Transform target;

    public override void OnExitState()
    {
        return;
    }

    public override void StateUpdate()
    {

        float direction = Mathf.Sign(Owner.transform.position.x - target.position.x);
        Owner.moveScr.PerformMove(Owner.enemyStats.Speed, -direction);
    }
    public override void OnEnterState(EnemyController owner)
    {
        base.OnEnterState(owner);
        target = player.transform;
    }

}
