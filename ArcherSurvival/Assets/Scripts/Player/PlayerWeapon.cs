using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] PlayerWeapon_SO so_PlayerWeaponStats;

    [SerializeField] internal float stats_Damage;
    [SerializeField] internal float stats_Speed;
    [SerializeField] Sprite ui_WeaponImageSprite;

    private void Start()
    {
        stats_Damage = so_PlayerWeaponStats.weapon_Damage;
        stats_Speed = so_PlayerWeaponStats.weapon_ProjectileSpeed;
        ui_WeaponImageSprite = so_PlayerWeaponStats.weapon_Sprite;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerAttack>() !=null)
        {
            if (so_PlayerWeaponStats.is_Sword)
            {
                other.GetComponent<PlayerAttack>().ChangeSword(stats_Damage);//update light damage value
                FindObjectOfType<PlayerUI>().UpdateSwordIcon(ui_WeaponImageSprite);//update weapon Icon
            }
            if (so_PlayerWeaponStats.is_Axe)
            {
                other.GetComponent<PlayerAttack>().ChangeAxe(stats_Damage);//update heavy damage value
                FindObjectOfType<PlayerUI>().UpdateAxeIcon(ui_WeaponImageSprite);
            }
            if (so_PlayerWeaponStats.is_Bow)
            {
                other.GetComponent<PlayerAttack>().ChangeBow(stats_Damage,stats_Speed);//update projectile damage value
                FindObjectOfType<PlayerUI>().UpdateBowIcon(ui_WeaponImageSprite);
            }
            Destroy(gameObject);
        }
    }
}
