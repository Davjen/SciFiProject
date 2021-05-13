using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerName", menuName = "Player/PlayerType")]
public class PlayerStats : ScriptableObject
{
    public string Name;
    public Stats MaxHp;
    public float Hp;
    public bool IsDead;
    public Stats BaseHP;

    public float constitution;

    public Stats SpecialStats;

    [Header("Stats")]
    public Stats[] PlayerStatistics;

    public Dictionary<string, Stats> Stats = new Dictionary<string, Stats>();

    //public float Constitution
    //{
    //    get => constitution;
    //    set
    //    {
    //        constitution += value;
    //        SetHP();

    //    }
    //}

    public float Luck
    {
        set
        {

        }
    }
    //public  Constitution; //MAX HP
    //public int Toughness; //damage reduction
    //public int ConsumableResource; //TO DO-> RENDERLO SCRIPTABLE OBJECT CON LA LOGICA INTRINSECA DI COME SI GUADAGNA (POTREBBE VARIARE IN BASE AL PERSONAGGIO)
    //public int SpecialStat; //TO DO -> RENDERLO SCRIPTABLE OBJECT (ESEMPIO, STR PER LO SPADACCINO, INT PER IL MAGO ECC CON REALITVE EVENTUALI LOGFIHE INTRINSECHE)
    ////INSERIRE ANCHE LE RESISTENZE MAGICHE?FISICHE? VALUTARE
    //public int Luck; //Incremento critici? incremento drop? (se critici inserirlo specifico per un tipo di player?)

    private void OnEnable()
    {
        if (Stats.Count != 0)
            Stats.Clear();

        for (int i = 0; i < PlayerStatistics.Length; i++)
        {
            Stats.Add(PlayerStatistics[i].Name, PlayerStatistics[i]);
        }
    }

    public Stats GetStats(string statsName)
    {
        return Stats[statsName];
    }

    public void ModifyStat(Stats stat, int amount = 1)
    {
        stat.ModifyStat(amount);
    }

    public void SetHP()
    {
        Stats["Constitution"].Logic();
        Hp = MaxHp.Value;
    }


}
