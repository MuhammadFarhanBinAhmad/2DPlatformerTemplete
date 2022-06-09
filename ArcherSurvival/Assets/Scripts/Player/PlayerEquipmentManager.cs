using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentManager : MonoBehaviour
{
    [SerializeField] internal PlayerPassiveEquipment_SO SO_CurrentPlayerPassiveEquipmentEqipped;

    PlayerHealth scp_PlayerHealth;
    PlayerMovement scp_PlayerMovement;
    PlayerAttack scp_PlayerAttack;
    PlayerHealth_EquipmentUI scp_PlayerHealth_EquipmentUI;

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
            scp_PlayerAttack.ResetSwordStats();
        }
        if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_AxeDamage)
        {
            scp_PlayerAttack.ResetAxeStats();
        }
        if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_ArrowStats)
        {
            scp_PlayerAttack.ResetBowAndArrowStats();
        }
        if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_ArrowSpecialAbility)
        {

        }
        SO_CurrentPlayerPassiveEquipmentEqipped = null;
    }
    void ChangePassiveEquipment()
    {
        //Handle all equipment effects
        if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_PlayerHealth)
        {
            scp_PlayerHealth.UpdateHealthAmount(
                SO_CurrentPlayerPassiveEquipmentEqipped.playerstats_ToMultiplyHealth,
                SO_CurrentPlayerPassiveEquipmentEqipped.playerstats_ToDivideHealth,
                SO_CurrentPlayerPassiveEquipmentEqipped.playerstats_HealthMultiplier_Divider);

        }
        if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_PlayerSpeed)
        {
            scp_PlayerMovement.UpdateMovementStats(
                SO_CurrentPlayerPassiveEquipmentEqipped.playerstats_ToMultiplySpeed,
                SO_CurrentPlayerPassiveEquipmentEqipped.playerstats_ToDivideSpeed,
                SO_CurrentPlayerPassiveEquipmentEqipped.playerstats_SpeedMultiplier_Divider);
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
            if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_BowDamage)
            {
                scp_PlayerAttack.UpdateBowDamageStats(
                SO_CurrentPlayerPassiveEquipmentEqipped.bow_ToMultiplyBowDamage,
                SO_CurrentPlayerPassiveEquipmentEqipped.bow_ToDivideBowDamage,
                SO_CurrentPlayerPassiveEquipmentEqipped.bow_DamageMultiplier_Divider);
            }
            if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_BowFireRate)
            {
                scp_PlayerAttack.UpdateBowDamageStats(
                SO_CurrentPlayerPassiveEquipmentEqipped.bow_ToMultiplyBowFirerate,
                SO_CurrentPlayerPassiveEquipmentEqipped.bow_ToDivideBowFirerate,
                SO_CurrentPlayerPassiveEquipmentEqipped.bow_FirerateMultiplier_Divider);
            }
            if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_ArrowSpeed)
            {
                scp_PlayerAttack.UpdateBowDamageStats(
                SO_CurrentPlayerPassiveEquipmentEqipped.bow_ToMultiplyArrowSpeed,
                SO_CurrentPlayerPassiveEquipmentEqipped.bow_ToDivideArrowSpeed,
                SO_CurrentPlayerPassiveEquipmentEqipped.bow_ArrowSpeedMultiplier_Divider);
            }

        }
        if (SO_CurrentPlayerPassiveEquipmentEqipped.effect_ArrowSpecialAbility)
        {

        }
    }
    internal void CheckEquipmentEquip(PlayerPassiveEquipment_SO SOCPPEE)
    {
        //replace old equipment with new equipment
        if (SO_CurrentPlayerPassiveEquipmentEqipped != null)
        {
            ResetStats();
            SO_CurrentPlayerPassiveEquipmentEqipped = SOCPPEE;
            ChangePassiveEquipment();
            //reset all stats
            return;
        }
        //If equipment slot is empty
        if (SO_CurrentPlayerPassiveEquipmentEqipped == null)
        {
            SO_CurrentPlayerPassiveEquipmentEqipped = SOCPPEE;
            ChangePassiveEquipment();
            return;
        }
    }

}
