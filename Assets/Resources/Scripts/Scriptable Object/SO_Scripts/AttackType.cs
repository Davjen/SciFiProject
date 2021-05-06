using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="AttackType",menuName ="Attack/AttackType")]
public class AttackType : ScriptableObject
{
    public string AttackTypeName;
    public float Range;
    public string StrongAgainst;
    public string WeakAgainst;
}


