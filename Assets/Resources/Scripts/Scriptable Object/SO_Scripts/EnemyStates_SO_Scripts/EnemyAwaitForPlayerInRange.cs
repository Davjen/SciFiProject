using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AwaitForRange", menuName = "IA/AwaitForRange")]
public class EnemyAwaitForPlayerInRange : State
{
    public bool checkIfEnterOnRadius = true;
    public RangeToCheck rangeToCheck;

    [Header("triggers")]
    public Transition OnPlayerInRange;

    private float EnterRange;
    private float ExitRange;
    public override void OnExitState()
    {
        return;
    }

    public override void StateUpdate()
    {
        if (checkIfEnterOnRadius)
        {
            if (Vector3.Distance(player.transform.position, Owner.transform.position) <= EnterRange)
            {
                AnimatorSetParam(OnPlayerInRange);
            }
        }else
        {
            if (Vector3.Distance(player.transform.position, Owner.transform.position) >= ExitRange)
            {
                AnimatorSetParam(OnPlayerInRange);
            }
        }

    }

    public override void OnEnterState(EnemyController owner)
    {
        base.OnEnterState(owner);
        player = GameObject.FindGameObjectWithTag("Player");

        EnterRange = owner.enemyStats.Ranges[rangeToCheck].EnterValue;
        ExitRange = owner.enemyStats.Ranges[rangeToCheck].ExitValue;
    }
}

public enum RangeToCheck {Chase,Attack,Wake }
