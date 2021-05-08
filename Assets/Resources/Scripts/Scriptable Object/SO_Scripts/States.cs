using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class States : ScriptableObject
{
    EnemyController Owner;
    public string Name;
    public bool PauseMode;
    public virtual void OnEnterState(EnemyController owner)
    {
        Owner = owner;
    }
    public abstract void OnExitState();
    public abstract void StateUpdate();

}
