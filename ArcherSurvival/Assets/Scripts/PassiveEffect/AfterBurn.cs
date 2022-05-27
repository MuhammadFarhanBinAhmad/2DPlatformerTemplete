using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterBurn : MonoBehaviour
{
    [SerializeField] internal float stats_DamageRate;
    [SerializeField] internal float stats_DamageAmount;
    [SerializeField] internal float stats_Timer;

    EnemiesHealth scp_EnemiesHealth;

    private void Start()
    {
        InvokeRepeating("FireDamage", 0, stats_DamageRate);
        StartCoroutine("Destroy");
        scp_EnemiesHealth = GetComponent<EnemiesHealth>();
    }
    void FireDamage()
    {
        scp_EnemiesHealth.TakeDamage(stats_DamageAmount);
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(stats_Timer);
        Destroy(this);
    }
}
