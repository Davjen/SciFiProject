using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimerState", menuName = "IA/TimerState")]
public class TimerState : State
{
    public float MinTime, MaxTime;

    float time;

    public override void OnExitState()
    {
        return;
    }

    public override void StateUpdate()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            anim.SetTrigger("Timer Complete");
        }
    }

    public override void OnEnterState(EnemyController owner)
    {
        base.OnEnterState(owner);
        float randomTime = Random.Range(MinTime, MaxTime);
        time = randomTime;
    }
}
