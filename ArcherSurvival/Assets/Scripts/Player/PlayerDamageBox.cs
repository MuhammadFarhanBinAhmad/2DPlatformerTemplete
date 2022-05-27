using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageBox : MonoBehaviour
{
    public float Damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<EnemiesHealth>() != null)
        {
            other.GetComponent<EnemiesHealth>().TakeDamage(Damage);
        }
    }
}
