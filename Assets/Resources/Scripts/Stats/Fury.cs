using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Fury", menuName = "ConsumableResources/Fury")]
public class Fury : ConsumableResource
{
    //public Stats StatsToIncrease;
    //public Stats StatsToDecrease;

    public PlayerStats owner;


    public override void ActivateSpecialEffect()
    {
        Debug.Log(SpecialEffectActivated);
        if (!SpecialEffectActivated)
        {

            SpecialEffectActivated = true;
            Debug.Log("Sto incrementando la statistica(DA IMPLEMENTARE)");
        }
        //owner.ModifyStat(StatsToIncrease, 100);
        //owner.ModifyStat(StatsToDecrease, -100);
    }

    public override void DeactivateSpecialEffect()
    {
        if (SpecialEffectActivated)
            Debug.Log("decremento le statistiche al valore iniziale");
    }

}
