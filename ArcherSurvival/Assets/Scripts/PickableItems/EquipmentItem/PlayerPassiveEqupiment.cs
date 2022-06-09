using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPassiveEqupiment : MonoBehaviour
{

    public PlayerPassiveEquipment_SO SO_CurrentPlayerPassiveEquipmentEqipped;

    void UnlockEquipment()
    {
        PlayerInventory PI = FindObjectOfType<PlayerInventory>();
        for (int i = 0; i <= PI.list_PlayerPassiveEquipment.Count-1; i++)
        {
            if (PI.list_PlayerPassiveEquipment[i].PlayerPassiveEquipment == SO_CurrentPlayerPassiveEquipmentEqipped)
            {
                PI.list_PlayerPassiveEquipment[i].isUnlocked = true;
                break;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerEquipmentManager>().CheckEquipmentEquip(SO_CurrentPlayerPassiveEquipmentEqipped);
            FindObjectOfType<PlayerHealth_EquipmentUI>().UpdateEquipmentIcon(SO_CurrentPlayerPassiveEquipmentEqipped.ui_EquipmentIcon);//Change equipment icon
            UnlockEquipment();
            Destroy(gameObject);
        }
       
    }
}
