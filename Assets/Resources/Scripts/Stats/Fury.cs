using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Fury", menuName = "ConsumableResources/Fury")]
public class Fury : ConsumableResource
{
    public Stats StatsToIncrease;
    public Stats StatsToDecrease;

    public PlayerStats owner;


    public override void ActivateSpecialEffect()
    {
        Debug.Log(SpecialEffectActivated);
        if (!SpecialEffectActivated)
        {

            SpecialEffectActivated = true;
            owner.ModifyStat(StatsToIncrease.Name,100);
            owner.ModifyStat(StatsToDecrease.Name,-100);
            Debug.Log("incremento le statistiche");
        }
        //owner.ModifyStat(StatsToIncrease, 100);
        //owner.ModifyStat(StatsToDecrease, -100);
    }

    public override void DeactivateSpecialEffect()
    {
        if (SpecialEffectActivated)
        {
            owner.ModifyStat(StatsToIncrease.Name, -100);
            owner.ModifyStat(StatsToDecrease.Name, +100);
            SpecialEffectActivated = false;
            Debug.Log("decremento le statistiche al valore iniziale");
        }
    }

}
