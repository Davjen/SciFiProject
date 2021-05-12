using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZapperAttackState", menuName = "IA/Zapper/AttackState")]
public class ZapperAttackState : State
{
    private float direction = 0;
    public override void OnExitState()
    {
        return;
    }

    public override void StateUpdate()
    {
        direction = -Mathf.Sign(Owner.transform.position.x - player.transform.position.x);
        Owner.moveScr.FlipSprite(direction);

    }
}
