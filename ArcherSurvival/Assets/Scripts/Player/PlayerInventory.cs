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
public class PlayerInventory : MonoBehaviour
{
    public List<Equipment> list_PlayerPassiveEquipment;
}
