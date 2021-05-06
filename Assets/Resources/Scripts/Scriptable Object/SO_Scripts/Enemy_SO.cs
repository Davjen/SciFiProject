using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy",menuName = "Enemy")]
public class Enemy_SO : ScriptableObject
{
    public float HP;
    public float Damage;
    public float xpToGain;
    public bool HaveTarget;
    public bool isDead;

    [Header("START PROP")]
    public float StartHP;


    public void Reset()
    {
        HP = StartHP;
    }
    private void OnEnable()
    {
        Reset();
    }
}
