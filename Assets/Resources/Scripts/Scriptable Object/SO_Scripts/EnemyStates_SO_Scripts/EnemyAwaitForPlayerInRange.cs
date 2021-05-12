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

    private float Range;
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

        switch (rangeToCheck)
        {
            case RangeToCheck.Chase:
                Range = Owner.enemyStats.DistForEnterChase;
                break;
            case RangeToCheck.Attack:
                Range = Owner.enemyStats.DistForEnterAttack;
                break;
            case RangeToCheck.Wake:
                Range = Owner.enemyStats.WakeDistance;
                break;
        }
    }
}

public enum RangeToCheck {Chase,Attack,Wake }
