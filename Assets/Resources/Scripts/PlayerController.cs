using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Movement movement;
    public float Speed;
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>(); 

    }

    // Update is called once per frame
    void Update()
    {
        movement.PerformMove(Speed, SetInput().x);
        if(Input.GetKeyDown(KeyCode.Space)){
            GetComponent<Animator>().SetTrigger("Attack");
        }
    }

    Vector2 SetInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        return new Vector2(x, y);
    }
}
