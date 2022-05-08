using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesAttack : MonoBehaviour
{
    EnemiesAnim scp_EnemiesAnim;

    [SerializeField] internal float ea_AttackRate;

    float next_Time_Attack;

    void Start()
    {
        scp_EnemiesAnim = GetComponentInChildren<EnemiesAnim>();
    }
    internal void DetectPlayer()
    {
        if (Time.time >= next_Time_Attack)
        {
            next_Time_Attack = Time.time + 1 / ea_AttackRate;
            AttackingPlayer();
        }
    }
    void AttackingPlayer()
    {
        scp_EnemiesAnim.AttackAnim();
    }
}
