using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PatrolState", menuName = "IA/PatrolState")]
public class PatrolState : States
{
    public override void OnExitState()
    {
        throw new System.NotImplementedException();
    }

    public override void StateUpdate()
    {
        throw new System.NotImplementedException();
    }
    public override void OnEnterState(EnemyController owner)
    {
        base.OnEnterState(owner);
    }
}
