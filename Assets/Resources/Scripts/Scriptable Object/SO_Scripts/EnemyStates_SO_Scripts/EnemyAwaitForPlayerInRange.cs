using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AwaitForRange", menuName = "IA/AwaitForRange")]
public class EnemyAwaitForPlayerInRange : State
{
    public float Range = 3;
    public bool checkIfEnterOnRadius = true;

    [Header("triggers")]
    public Transition OnPlayerInRange;


    public override void OnExitState()
    {
        return;
    }

    public override void StateUpdate()
    {
        if (checkIfEnterOnRadius)
        {
            if (Vector3.Distance(player.transform.position, Owner.transform.position) <= Range)
            {
                AnimatorSetParam(OnPlayerInRange);
            }
        }else
        {
            if (Vector3.Distance(player.transform.position, Owner.transform.position) >= Range)
            {
                AnimatorSetParam(OnPlayerInRange);
            }
        }

    }

    public override void OnEnterState(EnemyController owner)
    {
        base.OnEnterState(owner);
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
