using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class Movement : MonoBehaviour
{
     Animator anim;

     Rigidbody2D rb;
    private bool turnLeft=true;
    private bool turnRight;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void PerformMove(float speed, Vector2 direction)
    {
        FlipSprite(direction.x);
        float dir =direction.x !=0 ? Mathf.Abs(direction.x) : Mathf.Abs(direction.y);
        anim.SetFloat("Speed", dir );
        float yMove = direction.y!=0 ? direction.y*speed : rb.velocity.y;
        rb.velocity = new Vector2(direction.x * speed, yMove);
    }

    public void PerformMove(float speed,  float xDirection,float yDirection=0)
    {
        FlipSprite(xDirection);

        anim.SetFloat("Speed", Mathf.Abs(xDirection));
        float yMove = yDirection != 0 ? yDirection * speed : rb.velocity.y;
        rb.velocity = new Vector2(xDirection * speed, yMove);
    }

    public void FlipSprite(float direction)
    {
        
        if (direction > 0)
        {
            if (!turnLeft)
            {
                turnLeft = true;
                turnRight = false;
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

            }
        }
        else if (direction < 0)
        {
            if (!turnRight)
            {
                turnLeft = false;
                turnRight = true;
                transform.localScale = new Vector2(-transform.localScale.x, +transform.localScale.y);

            }
        }
    }
}
