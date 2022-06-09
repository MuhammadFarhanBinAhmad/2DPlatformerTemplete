using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    [SerializeField] internal PlayerWeapon_SO SO_CurrentPlayerSwordEqipped;
    [SerializeField] internal PlayerWeapon_SO SO_CurrentPlayerAxeEqipped;
    [SerializeField] internal PlayerWeapon_SO SO_CurrentPlayerBowEqipped;

    PlayerAttack scp_PlayerAttack;

    private void Start()
    {
        scp_PlayerAttack = GetComponent<PlayerAttack>();
        //I dunno why cant call in PlayerInventoryUI but fuck it
        CheckSwordEquip(SO_CurrentPlayerSwordEqipped);
        CheckAxeEquip(SO_CurrentPlayerAxeEqipped);
        CheckBowEquip(SO_CurrentPlayerBowEqipped);
        FindObjectOfType<PlayerInventoryUI>().ChangeSword(0);
        FindObjectOfType<PlayerInventoryUI>().ChangeAxe(0);
        FindObjectOfType<PlayerInventoryUI>().ChangeBow(0);

    }
    internal void CheckSwordEquip(PlayerWeapon_SO Sword_SO)
    {
        //replace old equipment with new equipment
        if (Sword_SO.is_Sword)
        {
            SO_CurrentPlayerSwordEqipped = Sword_SO;
            ChangeWeapon();
            //reset all stats
            return;
        }
    }
    internal void CheckAxeEquip(PlayerWeapon_SO Axe_SO)
    {
        //replace old equipment with new equipment
        if (Axe_SO.is_Axe)
        {
            SO_CurrentPlayerSwordEqipped = Axe_SO;
            ChangeWeapon();
            //reset all stats
            return;
        }
    }
    internal void CheckBowEquip(PlayerWeapon_SO Bow_SO)
    {
        //replace old equipment with new equipment
        if (Bow_SO.is_Bow)
        {
            SO_CurrentPlayerSwordEqipped = Bow_SO;
            ChangeWeapon();
            //reset all stats
            return;
        }
    }
    //Remove all effects
    void ChangeWeapon()
    {
        //Handle all equipment effects

        if (SO_CurrentPlayerSwordEqipped.is_Sword)
        {
            scp_PlayerAttack.ChangeSword(SO_CurrentPlayerSwordEqipped);
        }
        if (SO_CurrentPlayerAxeEqipped.is_Axe)
        {
            scp_PlayerAttack.ChangeAxe(SO_CurrentPlayerAxeEqipped);

        }
        if (SO_CurrentPlayerBowEqipped.is_Bow)
        {
            scp_PlayerAttack.ChangeBow(SO_CurrentPlayerBowEqipped);


        }
    }

}
