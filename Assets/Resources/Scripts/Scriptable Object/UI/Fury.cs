using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Fury",menuName = "Stats/Fury")]
public class Fury : Stats
{
    public Stats Toughness;
    public Stats Strenght;

   

    public override void Logic()
    {
        if (Value == 100)
        {
            Toughness.Value -= 50;
            Strenght.Value += 100;
        }
    }


}
