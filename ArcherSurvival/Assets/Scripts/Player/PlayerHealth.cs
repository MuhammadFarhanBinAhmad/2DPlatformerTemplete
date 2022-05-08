using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int s_PlayerHealth;

    internal int TakeDamage(int dmg)
    {
        return s_PlayerHealth -= dmg;
    }
}
