using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class Movement : MonoBehaviour
{
     Animator anim;
     SpriteRenderer sr;
     Rigidbody2D rb;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void PerformMove(float speed, float xDirection, float yDirection =0)
    {
        FlipSprite(xDirection);
        anim.SetFloat("Speed", Mathf.Abs(xDirection));
        float yMove = yDirection!=0 ? yDirection*speed : rb.velocity.y;
        rb.velocity = new Vector2(xDirection * speed, yMove);
    }

    void FlipSprite(float direction)
    {
        if (direction > 0)
        {
            sr.flipX = false;
        }else if (direction < 0)
        {
            sr.flipX = true;
        }
    }
}
