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

        switch (rangeToCheck)
        {
            case RangeToCheck.Chase:
                EnterRange = Owner.enemyStats.DistForEnterChase;
                ExitRange = Owner.enemyStats.DistForExitChase;
                break;
            case RangeToCheck.Attack:
                EnterRange = Owner.enemyStats.DistForEnterAttack;
                ExitRange = Owner.enemyStats.DistForExitAttack;
                break;
            case RangeToCheck.Wake:
                EnterRange = Owner.enemyStats.AwakeDistance;
                ExitRange = Owner.enemyStats.SleepDistance;
                break;
        }
    }
}

public enum RangeToCheck {Chase,Attack,Wake }
