using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "PatrolState", menuName = "IA/PatrolState")]
public class PatrolState : State
{
    public float RandomMinDist = 2;
    public float RandomMaxDist = 5;

    


    SpriteRenderer spriteRenderer;
    Collider2D collider;
    NavMeshAgent agent;
    NavMeshData nvData;

    Vector3 targetPoint;

    #region codice platform
    //[Header("RayCast Dimension")]
    //public float Xoffset, Yoffset;
    //public float BoxWidth = 0.2f;
    //public float DownMaxDist = 0.8f;
    //public float FrontMaxDist = 0.3f;

    //[Header("Debug Ray Size")]
    //public bool DebugMode;
    //public LayerMask PatrolMask;

    //Vector2 startRayPos;
    //Vector3 lastPos;
    //float direction = 1;
    //public float timeForCheckStuck = 1.5f; 
    #endregion

    public override void OnExitState()
    {
        //direction = 0;

        Debug.LogWarning("disabilitato movimento patrol");
    }

    public override void OnEnterState(EnemyController owner)
    {
        //direction = 1;
        //lastPos = owner.transform.position;

        base.OnEnterState(owner);
        spriteRenderer = Owner.GetComponent<SpriteRenderer>();
        collider = Owner.GetComponent<Collider2D>();
        agent = Owner.agent;
        agent.isStopped = false;

        float randomRange = Random.Range(RandomMinDist, RandomMaxDist);
        Vector3 randomPosition = Random.insideUnitCircle * randomRange;
        randomPosition = new Vector3(randomPosition.x, randomPosition.y, 0);
        NavMeshHit hit;

        NavMesh.SamplePosition(randomPosition, out hit, 5, NavMesh.AllAreas);
        targetPoint = hit.position;
        agent.SetDestination(targetPoint);
    }



    public override void StateUpdate()
    {
        if (PauseMode) return;

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            anim.SetTrigger("Reached Patrol Position");
        }

        #region codice platform

        //SetStartRaycast();
        //Vector2 Owner2Dpos = new Vector2(Owner.transform.position.x, Owner.transform.position.y);
        //bool DownHit = Physics2D.Raycast(startRayPos, Vector2.down, DownMaxDist);
        //Debug.DrawLine(startRayPos , startRayPos + Vector2.down * 1, Color.red);

        //if (BoxCast() || !DownHit || CheckMaxDistReached())
        //{
        //    CheckDistanceFromLastPoint();
        //    lastPos = Owner.transform.position;

        //    direction = -direction;
        //}
        //Owner.moveScr.PerformMove(Owner.enemyStats.Speed, direction); 
        #endregion

    }

    #region Vecchio codice per platform
    //public bool BoxCast()
    //{
    //    Vector2 Owner2Dpos = new Vector2(Owner.transform.position.x, Owner.transform.position.y);
    //    Vector2 boxCastSize = new Vector2(BoxWidth, collider.bounds.size.y - 0.2f);
    //    Vector2 boxCastOffsetPos = new Vector2(collider.bounds.size.x * 0.5f + boxCastSize.x * 0.5f + 0.1f, collider.bounds.size.y * 0.5f);
    //    if (spriteRenderer.flipX)
    //    {
    //        boxCastOffsetPos = new Vector2(-boxCastOffsetPos.x, boxCastOffsetPos.y);
    //        return Physics2D.OverlapBox(Owner2Dpos + boxCastOffsetPos, boxCastSize, 0f, PatrolMask);
    //    }
    //    else
    //    {
    //        boxCastOffsetPos = new Vector2(boxCastOffsetPos.x, boxCastOffsetPos.y);


    //        return Physics2D.OverlapBox(Owner2Dpos + boxCastOffsetPos, boxCastSize, 0f, PatrolMask);

    //    }

    //}

    //bool CheckMaxDistReached()
    //{
    //    if (Vector3.Distance(Owner.transform.position, lastPos) > Owner.enemyStats.PatrolMaxDist)
    //    {
    //        return true;
    //    }
    //    else return false;
    //}

    //void CheckDistanceFromLastPoint()  //valutare se far cascare i nemici dalle piattaforme e farli ritornare a muovere se si bloccano
    //{
    //    if (Vector3.Distance(Owner.transform.position, lastPos) < 1f)
    //    {
    //        direction = 0;
    //        anim.SetTrigger("Idle");
    //        Debug.Log(Owner.transform.name + " è bloccato");
    //    }
    //}
    //void SetStartRaycast()
    //{
    //    if (spriteRenderer.flipX)
    //    {
    //        startRayPos = new Vector2(Owner.transform.position.x - Xoffset, Owner.transform.position.y - Yoffset);
    //    }
    //    else
    //    {
    //        startRayPos = new Vector2(Owner.transform.position.x + Xoffset, Owner.transform.position.y - Yoffset);
    //    }
    //} 
    #endregion
}
