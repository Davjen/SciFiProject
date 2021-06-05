using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConsumableResource : ScriptableObject
{
    public float Value;
    public float MaxValue;
    public string ResourceName;

    public bool SpecialEffectActivated;

    public void SetValue(float amount)
    {
        Value = Mathf.Clamp(amount, 0, 100);
    }
    /// <summary>
    /// Decrease Resource and tell you if it was possible or u would go below 0(not enough resource to perform attack)
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public bool DecreaseResource(float amount)
    {
        
        Value -= amount;
        SpecialEffectActivated = false;
        if (Value < 0)
        {
            Value += amount;
            return false;
        }
        return true;
    }

    public virtual void IncreaseResource(float amount)
    {
        Value += amount;
        if(Value >= MaxValue)
        {
            Value = MaxValue; 
            ActivateSpecialEffect();
        }
    }

    public abstract void ActivateSpecialEffect();
    public abstract void DeactivateSpecialEffect();

    public bool DropResource()
    {
        if (Value >= 0)
        {
            Value = 0;
            SpecialEffectActivated = false;
        }
        return Value == 0;
    }
}
