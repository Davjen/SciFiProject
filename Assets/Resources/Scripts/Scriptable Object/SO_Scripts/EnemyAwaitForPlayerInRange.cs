using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AwaitForRange", menuName = "IA/AwaitForRange")]
public class EnemyAwaitForPlayerInRange : State
{
    public float Range = 3;

    [Header("triggers")]
    public Transition OnPlayerInRange;

    GameObject player;

    public override void OnExitState()
    {
        throw new System.NotImplementedException();
    }

    public override void StateUpdate()
    {
        if (Vector3.Distance(player.transform.position,Owner.transform.position)<=Range)
        {
            anim.avatar = null;
        }
    }

    public override void OnEnterState(EnemyController owner)
    {
        base.OnEnterState(owner);
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
