using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Brain",menuName ="IA/Brain")]
public class Brain : ScriptableObject
{
    public EnemyController controller;
    public List<State> states = new List<State>();

    [Header("Debug")]
    public GameObject debugGizmo;

    DebuggerGizmo gizmo;

    public void ResetBrain()
    {
        states.Clear();
    }
    public DebuggerGizmo CreateDebugger()
    {
        GameObject go = Instantiate(debugGizmo);
        gizmo = go.GetComponent<DebuggerGizmo>();
        return gizmo;
    }

    public void ExecuteStates()
    {
        foreach (State state in states)
        {
            state.StateUpdate();
        }
    }
    public void AddState(State state)
    {
        state.OnEnterState(controller);
        states.Add(state);
    }
    public void RemoveState(State state)
    {
        state.OnExitState();
        states.Remove(state);
    }
}
