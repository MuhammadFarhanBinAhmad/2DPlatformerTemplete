using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Equipment", order = 1)]
public class ScriptableObject_PlayerPassiveEquipment : ScriptableObject
{
    public Sprite ui_EquipmentIcon;
    public string ui_EquipmentName;

    public bool effect_PlayerHealth;
    public bool effect_PlayerSpeed;
    public bool effect_SwordDamage;
    public bool effect_AxeDamage;
    public bool effect_ArrowStats;
    public bool effect_ArrowSpecialAbility;
    //Note* Any afterburn effect will be a script on its own and be place in enemy
    //Note* Each effect will affect its respective ability when set to true
    //(eg. effect_PlayerHealth will activate playerstats_HealthMultiplier & playerstats_Divider)
    //Player  stats
    public bool playerstats_ToMultiplyHealth;
    public bool playerstats_ToDivideHealth;
    public float playerstats_HealthMultiplier_Divider;

    public bool playerstats_ToMultiplySpeed;
    public bool playerstats_ToDivideSpeed;
    public float playerstats_SpeedMultiplier_Divider;

    //Sword Stats
    public bool sword_ToMultiplySwordDamage;
    public bool sword_ToDivideSwordDamage;
    public float sword_DamageMultiplier_Divider;
    public bool effect_SwordAfterBurn;
    //Axe stats
    public bool axe_ToMultiplyAxeDamage;
    public bool axe_ToDivideAxeDamage;
    public float axe_DamageMultiplier_Divider;
    public bool effect_AxeAfterBurn;
    //Bow stats
    public bool effect_ArrowDamage;
    public bool bow_ToMultiplyBowDamage;
    public bool bow_ToDivideBowDamage;
    public float bow_DamageMultiplier_Divider;

    public bool effect_ArrowFireRate;
    public bool bow_ToMultiplyFirerate;
    public bool bow_ToDivideFirerate;
    public float bow_FirerateMultiplier_Divider;

    public bool effect_ArrowSpeed;
    public bool bow_ToMultiplyArrowSpeed;
    public bool bow_ToDivideArrowSpeed;
    public float bow_ArrowSpeedMultiplier_Divider;

    public bool effect_ArrowAfterBurn;
}
