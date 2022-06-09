using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "PlayerStats", menuName = "Weapon", order = 1)]
public class PlayerWeapon_SO : ScriptableObject
{
    [Header("WeaponType")]
    public bool is_Sword, is_Axe, is_Bow;
    public int weapon_Damage;
    [Header("For Projectile only")]
    public int weapon_ProjectileSpeed;//For projectile only
    public float weapon_FireRate;
    [Header("For UI only")]
    public Sprite ui_WeaponSprite;
    public string ui_WeaponName;

}
