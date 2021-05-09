using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerName", menuName = "Player/PlayerType")]
public class PlayerStats : ScriptableObject
{
    public string Name;
    public float MaxHp;
    public float Hp;

    [Header("Stats")]
    public int Constitution; //MAX HP
    public int Toughness; //damage reduction
    public int ConsumableResource; //TO DO-> RENDERLO SCRIPTABLE OBJECT CON LA LOGICA INTRINSECA DI COME SI GUADAGNA (POTREBBE VARIARE IN BASE AL PERSONAGGIO)
    public int SpecialStat; //TO DO -> RENDERLO SCRIPTABLE OBJECT (ESEMPIO, STR PER LO SPADACCINO, INT PER IL MAGO ECC CON REALITVE EVENTUALI LOGFIHE INTRINSECHE)
    //INSERIRE ANCHE LE RESISTENZE MAGICHE?FISICHE? VALUTARE
    public int Luck; //Incremento critici? incremento drop? (se critici inserirlo specifico per un tipo di player?)
}
