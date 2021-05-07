using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]

public class EnemyLinearPatrol : MonoBehaviour
{
    public float maxDist = 5;
    public Transform raycastStart;
    public float controlDistance;
    public float DownMaxDist = 0.8f;

    SpriteRenderer sr;
    Vector2 startRay2D;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        SetStartRaycast();
        RaycastHit2D hit = Physics2D.Raycast(startRay2D, Vector2.down,DownMaxDist);
        Debug.DrawLine(raycastStart.position, raycastStart.position + Vector3.down * DownMaxDist,Color.red);
        Debug.Log(hit.collider.name);
    }
    void SetStartRaycast()
    {
        if (sr.flipX)
        {
            raycastStart.position = new Vector3(transform.position.x - controlDistance, raycastStart.position.y, raycastStart.position.z);
        }
        else
        {
            raycastStart.position = new Vector3(transform.position.x + controlDistance, raycastStart.position.y, raycastStart.position.z);

        }
        startRay2D = new Vector2(raycastStart.position.x, raycastStart.position.y);
    }
}
