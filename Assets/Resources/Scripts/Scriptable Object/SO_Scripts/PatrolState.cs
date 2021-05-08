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

    [Header("Debug Ray Size")]
    public bool DebugMode;
    public LayerMask PatrolMask;
    public DebuggerGizmo gizmo;


    [Header("States to execute")]
    public State ShootState;
    public State ChaseState;

    Vector2 startRayPos;
    SpriteRenderer spriteRenderer;
    Collider2D collider;
    Vector3 lastPos;
    float direction = 1;
    float time;
    
    public override void OnExitState()
    {
        throw new System.NotImplementedException();
    }

    public override void OnEnterState(EnemyController owner)
    {
        time = 1;
        direction = 1;
        base.OnEnterState(owner);
        spriteRenderer = Owner.GetComponent<SpriteRenderer>();
        if (DebugMode) gizmo = Owner.Brain.CreateDebugger();
        collider = Owner.GetComponent<Collider2D>();
        lastPos = Owner.transform.position;
    }
    public bool BoxCast()
    {
        Debug.Log("BoxCast");
        Vector2 Owner2Dpos = new Vector2(Owner.transform.position.x, Owner.transform.position.y);
        Vector2 boxCastSize = new Vector2(BoxWidth, collider.bounds.size.y - 0.2f);
        Vector2 boxCastOffsetPos = new Vector2(collider.bounds.size.x * 0.5f + boxCastSize.x * 0.5f + 0.1f, collider.bounds.size.y * 0.5f);
        if (spriteRenderer.flipX)
        {
            boxCastOffsetPos = new Vector2(-boxCastOffsetPos.x, boxCastOffsetPos.y);
            gizmo.DrawQuad(Owner2Dpos + boxCastOffsetPos, boxCastSize);
            return Physics2D.OverlapBox(Owner2Dpos + boxCastOffsetPos, boxCastSize, 0f, PatrolMask);
        }
        else
        {
            boxCastOffsetPos = new Vector2(boxCastOffsetPos.x, boxCastOffsetPos.y);

            gizmo.DrawQuad(Owner2Dpos + boxCastOffsetPos, boxCastSize);

            return Physics2D.OverlapBox(Owner2Dpos + boxCastOffsetPos, boxCastSize, 0f, PatrolMask);

        }

    }
    

    public override void StateUpdate()
    {

        SetStartRaycast();
        Vector2 Owner2Dpos = new Vector2(Owner.transform.position.x, Owner.transform.position.y);
        bool DownHit = Physics2D.Raycast(startRayPos, Vector2.down, DownMaxDist);
        Debug.DrawLine(startRayPos , startRayPos + Vector2.down * 1, Color.red);

        if (BoxCast() || !DownHit || CheckDistanceFromLastPoint())
        {
            lastPos = Owner.transform.position;
            direction = -direction;
        }
        Owner.moveScr.PerformMove(Owner.enemyStats.Speed, direction);

    }

    bool CheckDistanceFromLastPoint()  //valutare se far cascare i nemici dalle piattaforme e farli ritornare a muovere se si bloccano
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            if (Vector3.Distance(Owner.transform.position,lastPos)< 0.5)
            {
                direction = 0;
            }
            else
            {
                time = 1;
            }
        }
        if (Vector3.Distance(Owner.transform.position, lastPos) >= maxDist)
        {
            return true;
        }
        else return false;
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
