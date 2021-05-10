using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PatrolState", menuName = "IA/PatrolState")]
public class PatrolState : State
{
    public float maxDist = 5;
    public float Xoffset, Yoffset;
    public float DownMaxDist = 0.8f;
    public float FrontMaxDist = 0.3f;
    public float BoxWidth = 0.2f;
    public float timeForCheckStuck = 1.5f;

    [Header("Debug Ray Size")]
    public bool DebugMode;
    public LayerMask PatrolMask;


    [Header("States to execute")]
    public string OnPatrolPause;
    public string OnPlayerOnRange;

    Vector2 startRayPos;
    SpriteRenderer spriteRenderer;
    Collider2D collider;
    Vector3 lastPos;
    float direction = 1;
    
    public override void OnExitState()
    {
        direction = 0;
        Owner.moveScr.PerformMove(Owner.enemyStats.Speed, direction);
    }

    public override void OnEnterState(EnemyController owner)
    {
        direction = 1;
        base.OnEnterState(owner);
        spriteRenderer = Owner.GetComponent<SpriteRenderer>();
        collider = Owner.GetComponent<Collider2D>();
        lastPos = new Vector3(float.MaxValue,float.MaxValue);
    }
    public bool BoxCast()
    {
        Vector2 Owner2Dpos = new Vector2(Owner.transform.position.x, Owner.transform.position.y);
        Vector2 boxCastSize = new Vector2(BoxWidth, collider.bounds.size.y - 0.2f);
        Vector2 boxCastOffsetPos = new Vector2(collider.bounds.size.x * 0.5f + boxCastSize.x * 0.5f + 0.1f, collider.bounds.size.y * 0.5f);
        if (spriteRenderer.flipX)
        {
            boxCastOffsetPos = new Vector2(-boxCastOffsetPos.x, boxCastOffsetPos.y);
            return Physics2D.OverlapBox(Owner2Dpos + boxCastOffsetPos, boxCastSize, 0f, PatrolMask);
        }
        else
        {
            boxCastOffsetPos = new Vector2(boxCastOffsetPos.x, boxCastOffsetPos.y);


            return Physics2D.OverlapBox(Owner2Dpos + boxCastOffsetPos, boxCastSize, 0f, PatrolMask);

        }

    }
    

    public override void StateUpdate()
    {

        SetStartRaycast();
        Vector2 Owner2Dpos = new Vector2(Owner.transform.position.x, Owner.transform.position.y);
        bool DownHit = Physics2D.Raycast(startRayPos, Vector2.down, DownMaxDist);
        Debug.DrawLine(startRayPos , startRayPos + Vector2.down * 1, Color.red);

        if (BoxCast() || !DownHit)
        {
            CheckDistanceFromLastPoint();
            lastPos = Owner.transform.position;

            direction = -direction;
        }
        Owner.moveScr.PerformMove(Owner.enemyStats.Speed, direction);

    }

    void CheckDistanceFromLastPoint()  //valutare se far cascare i nemici dalle piattaforme e farli ritornare a muovere se si bloccano
    {
        if (Vector3.Distance(Owner.transform.position,lastPos) < 1f)
        {
            direction = 0;
            anim.SetTrigger("Idle");
            Debug.Log(Owner.transform.name + " è bloccato");
        }
    }
    void SetStartRaycast()
    {
        if (spriteRenderer.flipX)
        {
            startRayPos = new Vector2(Owner.transform.position.x - Xoffset, Owner.transform.position.y - Yoffset);
        }
        else
        {
            startRayPos = new Vector2(Owner.transform.position.x + Xoffset, Owner.transform.position.y - Yoffset);
        }
    }
}
