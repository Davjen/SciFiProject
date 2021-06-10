using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackPosition", menuName = "IA/AttackPosition")]
public class Positioning : State
{
    Transform target;

    public override void OnExitState()
    {
        return;
    }

    public override void StateUpdate()
    {
        Vector3 dest;
        Vector3 sinistra, destra;
        destra = new Vector3(target.position.x + Owner.enemyStats.attackPositionDistanceX, target.position.y, 0);
        sinistra = new Vector3(target.position.x - Owner.enemyStats.attackPositionDistanceX, target.position.y, 0);
        if ((Vector3.Distance(Owner.transform.position, destra) < Vector3.Distance(Owner.transform.position, sinistra)))
        {
            dest = destra;
        }
        else
        {
            dest = sinistra;
        }
        Owner.agent.SetDestination(dest);
        Owner.dir = Owner.transform.position.x - Owner.agent.steeringTarget.x;

        if (Vector3.Distance(Owner.transform.position,dest)< 0.1f)
        {
            Debug.Log("Posizionato");
            anim.SetBool("OnAttackPosition", true);
        }

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
