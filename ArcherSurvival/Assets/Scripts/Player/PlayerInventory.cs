using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Equipment
{
    public string name;
    public PlayerPassiveEquipment_SO PlayerPassiveEquipment;
    public PlayerPassiveEquipment_SO NullItem;//When equipment is not unlocked
    public bool isUnlocked;
}
[System.Serializable]
public class Sword
{
    public string name;
    public PlayerWeapon_SO PlayerSword;
    public PlayerWeapon_SO NullItem;//When equipment is not unlocked
    public bool isUnlocked;
}
[System.Serializable]
public class Axe
{
    public string name;
    public PlayerWeapon_SO PlayerAxe;
    public PlayerWeapon_SO NullItem;//When equipment is not unlocked
    public bool isUnlocked;
}
[System.Serializable]
public class Bow
{
    public string name;
    public PlayerWeapon_SO PlayerBow;
    public PlayerWeapon_SO NullItem;//When equipment is not unlocked
    public bool isUnlocked;
}
public class PlayerInventory : MonoBehaviour
{
    public List<Equipment> list_PlayerPassiveEquipment;
    public List<Sword> list_PlayerSword;
    public List<Axe> list_PlayerAxe;
    public List<Bow> list_PlayerBow;

}
