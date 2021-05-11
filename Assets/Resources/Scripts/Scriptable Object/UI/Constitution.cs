using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constitution : Stats
{
    public Stats MaxHP, BaseHp;
    public override void Logic()
    {
        MaxHP.Value = BaseHp.Value + Value;
    }
}
