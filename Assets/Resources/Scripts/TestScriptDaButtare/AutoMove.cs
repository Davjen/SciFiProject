using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour,IreflectDamage
{

    GameObject owner;
    public GameObject Owner { get => gameObject; set => owner=value; } //TEST SCRITTO MALE

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += new Vector3(-5*Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning("mi sembra una porcata");
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            player.TakeDamage(5);
        }
    }

    public void ReflectDamage()
    {
        Debug.LogWarning("OH MIO DIO HO RIFLESSO DANNO");
        Destroy(gameObject);
    }
}
