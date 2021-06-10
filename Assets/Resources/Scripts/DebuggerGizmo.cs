using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuggerGizmo : MonoBehaviour
{

    bool circle, quad;
    Vector2 circlePos, quadPos, quadSize;
    float circleSize;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void DrawCircle(Vector2 pos, float size)
    {
        circlePos = pos;
        circleSize = size;
        circle = true;
    }
    public void DrawQuad(Vector2 pos, Vector2 size)
    {
        quadPos = pos;
        quadSize = size;
        quad = true;
    }
    private void OnDrawGizmos()
    {
        if (quad)
        {
            Gizmos.DrawWireCube(new Vector3(quadPos.x, quadPos.y, 0), new Vector3(quadSize.x, quadSize.y, 0));
            quad = false;
        }
        if (quad)
        {
            Gizmos.DrawWireSphere(new Vector3(circlePos.x, circlePos.y, 0),circleSize);
            circle = false;
        }
    }
}
