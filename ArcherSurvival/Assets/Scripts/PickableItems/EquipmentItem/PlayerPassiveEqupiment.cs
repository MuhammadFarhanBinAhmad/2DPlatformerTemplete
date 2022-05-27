using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPassiveEqupiment : MonoBehaviour
{

    public ScriptableObject_PlayerPassiveEquipment SO_CurrentPlayerPassiveEquipmentEqipped;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInventory>().CheckEquipmentEquip(SO_CurrentPlayerPassiveEquipmentEqipped);
            FindObjectOfType<PlayerUI>().UpdateEquipmentIcon(SO_CurrentPlayerPassiveEquipmentEqipped.ui_EquipmentIcon);//Change equipment icon
            Destroy(gameObject);
        }
       
    }
}
