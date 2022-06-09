using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] PlayerWeapon_SO so_PlayerWeaponStats;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = so_PlayerWeaponStats.ui_WeaponSprite;

    }
    void UnlockSword()
    {
        PlayerInventory PI = FindObjectOfType<PlayerInventory>();
        for (int i = 0; i <= PI.list_PlayerSword.Count - 1; i++)
        {
            if (PI.list_PlayerSword[i].PlayerSword == so_PlayerWeaponStats)
            {
                PI.list_PlayerSword[i].isUnlocked = true;
                break;
            }
        }
    }
    void UnlockAxe()
    {
        PlayerInventory PI = FindObjectOfType<PlayerInventory>();
        for (int i = 0; i <= PI.list_PlayerAxe.Count - 1; i++)
        {
            if (PI.list_PlayerAxe[i].PlayerAxe == so_PlayerWeaponStats)
            {
                PI.list_PlayerAxe[i].isUnlocked = true;
                break;
            }
        }
    }
    void UnlockBow()
    {
        PlayerInventory PI = FindObjectOfType<PlayerInventory>();
        for (int i = 0; i <= PI.list_PlayerBow.Count - 1; i++)
        {
            if (PI.list_PlayerBow[i].PlayerBow == so_PlayerWeaponStats)
            {
                PI.list_PlayerBow[i].isUnlocked = true;
                break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerAttack>() !=null)
        {
            if (so_PlayerWeaponStats.is_Sword)
            {
                FindObjectOfType<PlayerWeaponManager>().CheckSwordEquip(so_PlayerWeaponStats);//Change weapon equip
                FindObjectOfType<PlayerHealth_EquipmentUI>().UpdateSwordIcon(so_PlayerWeaponStats.ui_WeaponSprite);//change weapon Icon
                //change weapon name and icon in inventory screen
                PlayerInventoryUI PUUI = FindObjectOfType<PlayerInventoryUI>();
                PUUI.ui_SwordImage.sprite = so_PlayerWeaponStats.ui_WeaponSprite;
                PUUI.ui_SwordName.text = so_PlayerWeaponStats.ui_WeaponName;
                UnlockSword();
            }
            if (so_PlayerWeaponStats.is_Axe)
            {
                FindObjectOfType<PlayerWeaponManager>().CheckAxeEquip(so_PlayerWeaponStats);
                FindObjectOfType<PlayerHealth_EquipmentUI>().UpdateAxeIcon(so_PlayerWeaponStats.ui_WeaponSprite);
                PlayerInventoryUI PUUI = FindObjectOfType<PlayerInventoryUI>();
                PUUI.ui_AxeImage.sprite = so_PlayerWeaponStats.ui_WeaponSprite;
                PUUI.ui_AxeName.text = so_PlayerWeaponStats.ui_WeaponName;
                UnlockAxe();
            }
            if (so_PlayerWeaponStats.is_Bow)
            {
                FindObjectOfType<PlayerWeaponManager>().CheckBowEquip(so_PlayerWeaponStats);
                FindObjectOfType<PlayerHealth_EquipmentUI>().UpdateBowIcon(so_PlayerWeaponStats.ui_WeaponSprite);
                PlayerInventoryUI PUUI = FindObjectOfType<PlayerInventoryUI>();
                PUUI.ui_BowImage.sprite = so_PlayerWeaponStats.ui_WeaponSprite;
                PUUI.ui_BowName.text = so_PlayerWeaponStats.ui_WeaponName;
                UnlockBow();
            }
            Destroy(gameObject);
        }
    }
}
