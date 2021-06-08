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
        Vector3 dest;
        if ( (Vector3.Distance(Owner.transform.position, (target.position + new Vector3(Owner.enemyStats.Ranges[RangeToCheck.Attack].EnterValue - 0.1f, 0, 0)))) <= (Vector3.Distance(Owner.transform.position, (target.position - new Vector3(Owner.enemyStats.Ranges[RangeToCheck.Attack].EnterValue - 0.1f, 0, 0)))))
        {
            dest = (target.position + new Vector3(Owner.enemyStats.Ranges[RangeToCheck.Attack].EnterValue - 0.2f, 0, 0));
        }
        else
        {
            dest = (target.position - new Vector3(Owner.enemyStats.Ranges[RangeToCheck.Attack].EnterValue - 0.2f, 0, 0));
        }
        Owner.agent.SetDestination(dest);

        //float direction = Mathf.Sign(Owner.transform.position.x - target.position.x);
        //Owner.moveScr.PerformMove(Owner.enemyStats.Speed, -direction);
    }
    public override void OnEnterState(EnemyController owner)
    {
        base.OnEnterState(owner);
        target = player.transform;
        owner.agent.isStopped = false;
    }

}
