using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IreflectDamage
{
    public GameObject Owner { get; set; }
    public void ReflectDamage();
}
