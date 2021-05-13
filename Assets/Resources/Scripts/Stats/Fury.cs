using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Fury",menuName ="ConsumableResources/Fury")]
public class Fury : ConsumableResource
{
    //public Stats StatsToIncrease;
    //public Stats StatsToDecrease;

    public PlayerStats owner;

    public override void ActivateSpecialEffect()
    {
        Debug.Log("testFury");
        //owner.ModifyStat(StatsToIncrease, 100);
        //owner.ModifyStat(StatsToDecrease, -100);
    }

}
