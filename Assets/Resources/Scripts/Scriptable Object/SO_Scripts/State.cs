using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class State : ScriptableObject
{
    protected EnemyController Owner;
    protected Animator anim;
    public string Name;
    public bool PauseMode;
    public virtual void OnEnterState(EnemyController owner)
    {
        Owner = owner;
        anim = owner.GetComponent<Animator>();
    }
    public virtual void AnimatorSetParam(Transition transition)
    {
        switch (transition.paramType)
        {
            case ParamType.Trigger:
                anim.SetTrigger(transition.name);
                break;
            case ParamType.Bool:
                anim.SetBool(transition.name, transition.boolVal);
                break;
            case ParamType.Float:
                anim.SetFloat(transition.name, transition.floatVal);
                break;
            case ParamType.Int:
                anim.SetInteger(transition.name, transition.intVal);
                break;
        }
    }
    public abstract void OnExitState();
    public abstract void StateUpdate();

}

[Serializable]
public struct Transition
{
    public string name;
    public ParamType paramType;
    public bool boolVal;
    public float floatVal;
    public int intVal;

}
public enum ParamType { Trigger,Bool,Float,Int}

