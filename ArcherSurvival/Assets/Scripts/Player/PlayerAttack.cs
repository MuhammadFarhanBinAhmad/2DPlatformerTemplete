using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    PlayerAnim scp_PlayerAnim;
    PlayerMovement scp_PlayerMovement;
    [SerializeField]PlayerDamageBox pa_PlayerDamageBox;

    [SerializeField] Transform go_ArrowSpawnPos;
    [SerializeField] GameObject go_Arrow;

    [Header("FireRate")]
    [SerializeField] float pa_ArrowFireRate;
    [SerializeField] float pa_LightAttackRate;
    [SerializeField] float pa_HeavyAttackRate;

    [SerializeField]int pa_AttackCount;

    [Header("AttackTimer")]
    [SerializeField]float pa_LightMeleeTimeBeforeReset;
    [SerializeField] float pa_HeavyMeleeTimeBeforeReset;
    float pa_AttackTimeReset;
    [SerializeField]internal bool pa_UsingMeleeAttack;

    [Header("Damage")]
    [SerializeField] int pa_LightMeleeDamage;
    [SerializeField] int pa_HeavyMeleeDamage;

    float next_Time_LightAttack;
    float next_Time_HeavyAttack;
    float next_Time_ArrowAttack;


    // Update is called once per frame
    private void Start()
    {
        scp_PlayerAnim = FindObjectOfType<PlayerAnim>();
        scp_PlayerMovement = FindObjectOfType<PlayerMovement>();
    }
    void Update()
    {
        if (Input.GetAxis("Horizontal") == 0 && scp_PlayerMovement.m_IsGrounded)
        {
            if (Input.GetButtonDown("ArrowAttack") && Time.time >= next_Time_ArrowAttack && !pa_UsingMeleeAttack)
            {
                next_Time_ArrowAttack = Time.time + 1f / pa_ArrowFireRate;
                ShootArrowAttack();
            }
            if (Input.GetButtonDown("LightAttack") && Time.time >= next_Time_LightAttack && pa_AttackCount <3)
            {
                next_Time_LightAttack = Time.time + 1f / pa_LightAttackRate;
                LightMeleeAttack();
            }
            if (Input.GetButtonDown("HeavyAttack") && Time.time >= next_Time_HeavyAttack && pa_AttackCount < 3)
            {
                next_Time_HeavyAttack = Time.time + 1f / pa_HeavyAttackRate;
                HeavyMeleeAttack();
            }
        }
        if (pa_AttackTimeReset > 0)
        {
            StartMeleeTimer();
        }
        if (pa_AttackTimeReset <= 0)
        {
            ResetMeleeCounter();
        }
    }
    void ShootArrowAttack()
    {
        GameObject a = Instantiate(go_Arrow, go_ArrowSpawnPos.transform.position, transform.rotation);
        scp_PlayerAnim.ArrowAttackAnim();
    }
    void LightMeleeAttack()
    {
        pa_PlayerDamageBox.Damage = pa_LightMeleeDamage;
        pa_UsingMeleeAttack = true;
        pa_AttackCount++;
        scp_PlayerAnim.LightMeleeAttackAnim(pa_AttackCount);
        pa_AttackTimeReset = pa_LightMeleeTimeBeforeReset;
    }
    void HeavyMeleeAttack()
    {
        pa_PlayerDamageBox.Damage = pa_HeavyMeleeDamage;
        pa_UsingMeleeAttack = true;
        pa_AttackCount++;
        scp_PlayerAnim.HeavyMeleeAttackAnim(pa_AttackCount);
        pa_AttackTimeReset = pa_HeavyMeleeTimeBeforeReset;
    }
    void StartMeleeTimer()
    {
        pa_AttackTimeReset -= Time.deltaTime;
    }
    void ResetMeleeCounter()
    {
        pa_AttackTimeReset = 0;
        pa_AttackCount = 0;
        pa_UsingMeleeAttack = false;
    }
}
