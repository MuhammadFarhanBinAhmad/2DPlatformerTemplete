using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageBox : MonoBehaviour
{

    public int Damage;

    public List<Animator> effect_Hit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerHealth>() != null)
        {
            int r = Random.Range(0, effect_Hit.Count - 1);
            other.GetComponent<PlayerHealth>().TakeDamage(Damage);
            effect_Hit[r].SetTrigger("Hit");
        }
    }
}
