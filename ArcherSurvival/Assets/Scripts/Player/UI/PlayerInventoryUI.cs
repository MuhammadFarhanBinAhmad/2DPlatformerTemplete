using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerInventoryUI : MonoBehaviour
{

    PlayerInventory scp_PlayerInventory;
    PlayerEquipmentManager scp_PlayerEquipmentManager;
    PlayerWeaponManager scp_PlayerWeaponManager;
    PlayerHealth_EquipmentUI scp_PlayerHealth_EquipmentUI;

    public int current_EquipmentTag;
    public int current_SwordTag;
    public int current_AxeTag;
    public int current_BowTag;

    public Image ui_EquipmentImage;
    public Image ui_SwordImage;
    public Image ui_AxeImage;
    public Image ui_BowImage;

    public TextMeshProUGUI ui_EquipmentName;
    public TextMeshProUGUI ui_SwordName;
    public TextMeshProUGUI ui_AxeName;
    public TextMeshProUGUI ui_BowName;


    private void Start()
    {
        scp_PlayerInventory = FindObjectOfType<PlayerInventory>();
        scp_PlayerEquipmentManager = FindObjectOfType<PlayerEquipmentManager>();
        scp_PlayerWeaponManager = FindObjectOfType<PlayerWeaponManager>();
        scp_PlayerHealth_EquipmentUI = FindObjectOfType<PlayerHealth_EquipmentUI>();

        //Set starter Items
        ChangeEquipment(0);

    }

    public void ChangeEquipment(int Add_Minus)
    {
        current_EquipmentTag += Add_Minus;
        if(current_EquipmentTag > scp_PlayerInventory.list_PlayerPassiveEquipment.Count-1)
        {
            current_EquipmentTag = 0;
        }
        if (current_EquipmentTag < 0)
        {
            current_EquipmentTag = scp_PlayerInventory.list_PlayerPassiveEquipment.Count - 1;
        }
        //unlocked equipment
        if (scp_PlayerInventory.list_PlayerPassiveEquipment[current_EquipmentTag].isUnlocked)
        {
            scp_PlayerEquipmentManager.CheckEquipmentEquip(scp_PlayerInventory.list_PlayerPassiveEquipment[current_EquipmentTag].PlayerPassiveEquipment);
            scp_PlayerHealth_EquipmentUI.UpdateEquipmentIcon(scp_PlayerInventory.list_PlayerPassiveEquipment[current_EquipmentTag].PlayerPassiveEquipment.ui_EquipmentIcon);//Change equipment icon
            ui_EquipmentImage.sprite = scp_PlayerInventory.list_PlayerPassiveEquipment[current_EquipmentTag].PlayerPassiveEquipment.ui_EquipmentIcon;
            ui_EquipmentName.text = scp_PlayerInventory.list_PlayerPassiveEquipment[current_EquipmentTag].PlayerPassiveEquipment.ui_EquipmentName;
        }
        //locked equipment
        if (!scp_PlayerInventory.list_PlayerPassiveEquipment[current_EquipmentTag].isUnlocked)
        {
            ChangeEquipment(Add_Minus);//go to next unlock equipment
        }
    }
    public void ChangeSword(int Add_Minus)
    {
        current_SwordTag += Add_Minus;
        if (current_SwordTag > scp_PlayerInventory.list_PlayerSword.Count - 1)
        {
            current_SwordTag = 0;
        }
        if (current_SwordTag < 0)
        {
            current_SwordTag = scp_PlayerInventory.list_PlayerSword.Count - 1;
        }
        //unlocked equipment
        if (scp_PlayerInventory.list_PlayerSword[current_SwordTag].isUnlocked)
        {
            scp_PlayerWeaponManager.CheckSwordEquip(scp_PlayerInventory.list_PlayerSword[current_SwordTag].PlayerSword);
            scp_PlayerHealth_EquipmentUI.UpdateSwordIcon(scp_PlayerInventory.list_PlayerSword[current_SwordTag].PlayerSword.ui_WeaponSprite);//Change equipment icon
            ui_SwordImage.sprite = scp_PlayerInventory.list_PlayerSword[current_SwordTag].PlayerSword.ui_WeaponSprite;
            ui_SwordName.text = scp_PlayerInventory.list_PlayerSword[current_SwordTag].PlayerSword.ui_WeaponName;
        }
        //locked equipment
        if (!scp_PlayerInventory.list_PlayerSword[current_SwordTag].isUnlocked)
        {
            ChangeSword(Add_Minus);//go to next unlock equipment
        }
    }
    public void ChangeAxe(int Add_Minus)
    {
        current_AxeTag += Add_Minus;
        if (current_AxeTag > scp_PlayerInventory.list_PlayerAxe.Count - 1)
        {
            current_AxeTag = 0;
        }
        if (current_AxeTag < 0)
        {
            current_AxeTag = scp_PlayerInventory.list_PlayerAxe.Count - 1;
        }
        //unlocked equipment
        if (scp_PlayerInventory.list_PlayerAxe[current_AxeTag].isUnlocked)
        {
            scp_PlayerWeaponManager.CheckAxeEquip(scp_PlayerInventory.list_PlayerAxe[current_AxeTag].PlayerAxe);
            scp_PlayerHealth_EquipmentUI.UpdateAxeIcon(scp_PlayerInventory.list_PlayerAxe[current_AxeTag].PlayerAxe.ui_WeaponSprite);//Change equipment icon
            ui_AxeImage.sprite = scp_PlayerInventory.list_PlayerAxe[current_AxeTag].PlayerAxe.ui_WeaponSprite;
            ui_AxeName.text = scp_PlayerInventory.list_PlayerAxe[current_AxeTag].PlayerAxe.ui_WeaponName;
        }
        //locked equipment
        if (!scp_PlayerInventory.list_PlayerAxe[current_AxeTag].isUnlocked)
        {
            ChangeAxe(Add_Minus);//go to next unlock equipment
        }
    }
    public void ChangeBow(int Add_Minus)
    {
        current_BowTag += Add_Minus;
        if (current_BowTag > scp_PlayerInventory.list_PlayerBow.Count - 1)
        {
            current_BowTag = 0;
        }
        if (current_BowTag < 0)
        {
            current_BowTag = scp_PlayerInventory.list_PlayerBow.Count - 1;
        }
        //unlocked equipment
        if (scp_PlayerInventory.list_PlayerBow[current_BowTag].isUnlocked)
        {
            scp_PlayerWeaponManager.CheckBowEquip(scp_PlayerInventory.list_PlayerBow[current_BowTag].PlayerBow);
            scp_PlayerHealth_EquipmentUI.UpdateBowIcon(scp_PlayerInventory.list_PlayerBow[current_BowTag].PlayerBow.ui_WeaponSprite);//Change equipment icon
            ui_BowImage.sprite = scp_PlayerInventory.list_PlayerBow[current_BowTag].PlayerBow.ui_WeaponSprite;
            ui_BowName.text = scp_PlayerInventory.list_PlayerBow[current_BowTag].PlayerBow.ui_WeaponName;
        }
        //locked equipment
        if (!scp_PlayerInventory.list_PlayerAxe[current_BowTag].isUnlocked)
        {
            ChangeBow(Add_Minus);//go to next unlock equipment
        }
    }
}
