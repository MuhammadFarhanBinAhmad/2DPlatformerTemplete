using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerInventoryUI : MonoBehaviour
{

    PlayerInventory scp_PlayerInventory;
    PlayerEquipmentManager scp_PlayerEquipmentManager;
    PlayerHealth_EquipmentUI scp_PlayerHealth_EquipmentUI;

    public int current_WeaponTag;
    public Image ui_EquipmentImage;
    public TextMeshProUGUI ui_EquipmentName;


    private void Start()
    {
        scp_PlayerInventory = FindObjectOfType<PlayerInventory>();
        scp_PlayerEquipmentManager = FindObjectOfType<PlayerEquipmentManager>();
        scp_PlayerHealth_EquipmentUI = FindObjectOfType<PlayerHealth_EquipmentUI>();

    }

    public void ChangeEquipment(int Add_Minus)
    {
        current_WeaponTag += Add_Minus;
        if(current_WeaponTag > scp_PlayerInventory.list_PlayerPassiveEquipment.Count-1)
        {
            current_WeaponTag = 0;
        }
        if (current_WeaponTag < 0)
        {
            current_WeaponTag = scp_PlayerInventory.list_PlayerPassiveEquipment.Count - 1;
        }
        //unlocked equipment
        if (scp_PlayerInventory.list_PlayerPassiveEquipment[current_WeaponTag].isUnlocked)
        {
            scp_PlayerEquipmentManager.CheckEquipmentEquip(scp_PlayerInventory.list_PlayerPassiveEquipment[current_WeaponTag].PlayerPassiveEquipment);
            scp_PlayerHealth_EquipmentUI.UpdateEquipmentIcon(scp_PlayerInventory.list_PlayerPassiveEquipment[current_WeaponTag].PlayerPassiveEquipment.ui_EquipmentIcon);//Change equipment icon
            ui_EquipmentImage.sprite = scp_PlayerInventory.list_PlayerPassiveEquipment[current_WeaponTag].PlayerPassiveEquipment.ui_EquipmentIcon;
            ui_EquipmentName.text = scp_PlayerInventory.list_PlayerPassiveEquipment[current_WeaponTag].PlayerPassiveEquipment.ui_EquipmentName;
            print("hit_01");
        }
        //locked equipment
        if (!scp_PlayerInventory.list_PlayerPassiveEquipment[current_WeaponTag].isUnlocked)
        {
            scp_PlayerEquipmentManager.CheckEquipmentEquip(scp_PlayerInventory.list_PlayerPassiveEquipment[current_WeaponTag].NullItem);
            scp_PlayerHealth_EquipmentUI.UpdateEquipmentIcon(scp_PlayerInventory.list_PlayerPassiveEquipment[current_WeaponTag].NullItem.ui_EquipmentIcon);//Change equipment icon
            ui_EquipmentImage.sprite = scp_PlayerInventory.list_PlayerPassiveEquipment[current_WeaponTag].NullItem.ui_EquipmentIcon;
            ui_EquipmentName.text = scp_PlayerInventory.list_PlayerPassiveEquipment[current_WeaponTag].NullItem.ui_EquipmentName;
            print("hit_02");
        }
    }
}
