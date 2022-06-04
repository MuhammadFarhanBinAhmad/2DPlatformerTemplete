using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] PlayerWeapon_SO so_PlayerWeaponStats;

    [SerializeField] Sprite ui_WeaponImageSprite;

    private void Start()
    {
        ui_WeaponImageSprite = so_PlayerWeaponStats.weapon_Sprite;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerAttack>() !=null)
        {
            if (so_PlayerWeaponStats.is_Sword)
            {
                other.GetComponent<PlayerAttack>().ChangeSword(so_PlayerWeaponStats);//update light damage value
                FindObjectOfType<PlayerHealth_EquipmentUI>().UpdateSwordIcon(ui_WeaponImageSprite);//update weapon Icon
            }
            if (so_PlayerWeaponStats.is_Axe)
            {
                other.GetComponent<PlayerAttack>().ChangeAxe(so_PlayerWeaponStats);//update heavy damage value
                FindObjectOfType<PlayerHealth_EquipmentUI>().UpdateAxeIcon(ui_WeaponImageSprite);
            }
            if (so_PlayerWeaponStats.is_Bow)
            {
                other.GetComponent<PlayerAttack>().ChangeBow(so_PlayerWeaponStats);//update projectile damage value
                FindObjectOfType<PlayerHealth_EquipmentUI>().UpdateBowIcon(ui_WeaponImageSprite);
            }
            Destroy(gameObject);
        }
    }
}
