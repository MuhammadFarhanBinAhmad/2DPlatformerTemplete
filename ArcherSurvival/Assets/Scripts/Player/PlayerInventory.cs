using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] internal ScriptableObject_PlayerPassiveEquipment SO_CurrentPlayerPassiveEquipmentEqipped;

    PlayerHealth scp_PlayerHealth;
    PlayerMovement scp_PlayerMovement;
    PlayerAttack scp_PlayerAttack;
    PlayerUI scp_PlayerUI;

    private void Start()
    {
        scp_PlayerHealth = GetComponent<PlayerHealth>();
        scp_PlayerMovement = GetComponent<PlayerMovement>();
        scp_PlayerAttack = GetComponent<PlayerAttack>();

    }
    //Remove all effects
    void ResetStats()
    {
        if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_PlayerHealth)
        {
            scp_PlayerHealth.ResetHealthAmount();
        }
        if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_PlayerSpeed)
        {
            scp_PlayerMovement.ResetMovementStats();
        }
        if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_SwordDamage)
        {

        }
        if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_AxeDamage)
        {

        }
        if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_ArrowDamage)
        {

        }
        if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_ArrowFireRate)
        {

        }
        if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_ArrowSpecialAbility)
        {

        }
        SO_CurrentPlayerPassiveEquipmentEqipped = null;
    }
    void ChangeStats()
    {
        //Handle all equipment effects
        if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_PlayerHealth)
        {
            scp_PlayerHealth.UpdateHealthAmount(
                SO_CurrentPlayerPassiveEquipmentEqipped.playerstats_ToMultiplyHealth,
                SO_CurrentPlayerPassiveEquipmentEqipped.playerstats_ToDivideHealth,
                SO_CurrentPlayerPassiveEquipmentEqipped.playerstats_HealthMultiplier_Divider);
            print("AffectHealth");

        }
        if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_PlayerSpeed)
        {
            scp_PlayerMovement.UpdateMovementStats(
                SO_CurrentPlayerPassiveEquipmentEqipped.playerstats_ToMultiplySpeed,
                SO_CurrentPlayerPassiveEquipmentEqipped.playerstats_ToDivideSpeed,
                SO_CurrentPlayerPassiveEquipmentEqipped.playerstats_SpeedMultiplier_Divider);
            print("AffectSpeed");
        }
        if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_SwordDamage)
        {
            scp_PlayerAttack.UpdateSwordStats(
                SO_CurrentPlayerPassiveEquipmentEqipped.sword_ToMultiplySwordDamage, 
                SO_CurrentPlayerPassiveEquipmentEqipped.sword_ToDivideSwordDamage, 
                SO_CurrentPlayerPassiveEquipmentEqipped.sword_DamageMultiplier_Divider);
        }
        if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_AxeDamage)
        {
            scp_PlayerAttack.UpdateAxeStats(
                SO_CurrentPlayerPassiveEquipmentEqipped.axe_ToMultiplyAxeDamage,
                SO_CurrentPlayerPassiveEquipmentEqipped.axe_ToDivideAxeDamage,
                SO_CurrentPlayerPassiveEquipmentEqipped.axe_DamageMultiplier_Divider);
        }
        if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_ArrowStats)
        {
            if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_ArrowDamage)
            {
                scp_PlayerAttack.UpdateBowDamageStats(
                SO_CurrentPlayerPassiveEquipmentEqipped.sword_ToMultiplySwordDamage,
                SO_CurrentPlayerPassiveEquipmentEqipped.sword_ToDivideSwordDamage,
                SO_CurrentPlayerPassiveEquipmentEqipped.sword_DamageMultiplier_Divider);
            }


        }
        if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_ArrowFireRate)
        {

        }
        if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_ArrowSpecialAbility)
        {

        }
    }
    internal void CheckEquipmentEquip(ScriptableObject_PlayerPassiveEquipment SOCPPEE)
    {
        //replace old equipment with new equipment
        if (SO_CurrentPlayerPassiveEquipmentEqipped != null)
        {
            ResetStats();
            SO_CurrentPlayerPassiveEquipmentEqipped = SOCPPEE;
            ChangeStats();
            //reset all stats
            print("Replace");
            return;
        }
        //If equipment slot is empty
        if (SO_CurrentPlayerPassiveEquipmentEqipped == null)
        {
            SO_CurrentPlayerPassiveEquipmentEqipped = SOCPPEE;
            ChangeStats();
            print("Addnew");
            return;
        }
    }
}
