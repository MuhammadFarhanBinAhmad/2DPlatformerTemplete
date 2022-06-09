using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    PlayerAnim scp_PlayerAnim;
    PlayerMovement scp_PlayerMovement;
    [SerializeField]PlayerDamageBox scp_PlayerDamageBox;
    PlayerGroundCheck scp_GroundCheck;

    [Header("StartingWeapons")]
    [SerializeField] PlayerWeapon_SO player_StarterSword;
    [SerializeField] PlayerWeapon_SO player_StarterAxe;
    [SerializeField] PlayerWeapon_SO player_StarterBow;

    /// <NOTE>
    /// Need to manually input weapon stats in the beginning
    /// </NOTE>
    [Header("ArrowStats")]
    [SerializeField] Transform go_ArrowSpawnPos;
    [SerializeField] GameObject go_Arrow;

    [Header("FireRate")]
    [SerializeField] float stats_BowFireRate;
    [SerializeField] float stats_LightAttackRate;
    [SerializeField] float stats_HeavyAttackRate;

    [SerializeField]int stats_AttackCount;

    [Header("AttackTimer")]
    [SerializeField]float stats_LightMeleeTimeBeforeReset;
    [SerializeField] float stats_HeavyMeleeTimeBeforeReset;
    float stats_AttackTimeReset;
    [SerializeField]internal bool stats_UsingMeleeAttack;

    [Header("Damage")]
    [SerializeField] float stats_StartingLightMeleeDamage;
    [SerializeField] float stats_StartingHeavyMeleeDamage;
    [SerializeField] float stats_StartingBowDamage;
    [SerializeField] float stats_StartingBowFireRate;
    [SerializeField] float stats_StartingArrowSpeed;
    [SerializeField] float stats_LightMeleeDamage;
    [SerializeField] float stats_HeavyMeleeDamage;
    [SerializeField] float stats_BowDamage;
    [SerializeField] float stats_ArrowSpeed;

    float next_Time_LightAttack;
    float next_Time_HeavyAttack;
    float next_Time_ArrowAttack;


    // Update is called once per frame
    private void Start()
    {
        scp_PlayerAnim = FindObjectOfType<PlayerAnim>();
        scp_PlayerMovement = FindObjectOfType<PlayerMovement>();
        scp_GroundCheck = FindObjectOfType<PlayerGroundCheck>();
    }
    void Update()
    {
        if (Input.GetAxis("Horizontal") == 0 && scp_GroundCheck.m_IsGrounded)
        {
            if (Input.GetButtonDown("ArrowAttack") && Time.time >= next_Time_ArrowAttack && !stats_UsingMeleeAttack)
            {
                next_Time_ArrowAttack = Time.time + 1f / stats_BowFireRate;
                ShootBowAttack();
            }
            if (Input.GetButtonDown("LightAttack") && Time.time >= next_Time_LightAttack && stats_AttackCount <3)
            {
                next_Time_LightAttack = Time.time + 1f / stats_LightAttackRate;
                LightMeleeAttack();
            }
            if (Input.GetButtonDown("HeavyAttack") && Time.time >= next_Time_HeavyAttack && stats_AttackCount < 3)
            {
                next_Time_HeavyAttack = Time.time + 1f / stats_HeavyAttackRate;
                HeavyMeleeAttack();
            }
        }
        if (stats_AttackTimeReset > 0)
        {
            StartMeleeTimer();
        }
        if (stats_AttackTimeReset <= 0)
        {
            ResetMeleeCounter();
        }
    }
    //Projectile
    void ShootBowAttack()
    {
        GameObject a = Instantiate(go_Arrow, go_ArrowSpawnPos.transform.position, transform.rotation);
        a.GetComponent<Projectile>().go_ProjectileDamage = stats_BowDamage;
        a.GetComponent<Projectile>().go_ProjectileSpeed = stats_ArrowSpeed;
        scp_PlayerAnim.ArrowAttackAnim();
    }
    //SwordAttack
    void LightMeleeAttack()
    {
        scp_PlayerDamageBox.Damage = stats_LightMeleeDamage;
        stats_UsingMeleeAttack = true;
        stats_AttackCount++;
        scp_PlayerAnim.LightMeleeAttackAnim(stats_AttackCount);
        stats_AttackTimeReset = stats_LightMeleeTimeBeforeReset;
    }
    //AxeAttack
    void HeavyMeleeAttack()
    {
        scp_PlayerDamageBox.Damage = stats_HeavyMeleeDamage;
        stats_UsingMeleeAttack = true;
        stats_AttackCount++;
        scp_PlayerAnim.HeavyMeleeAttackAnim(stats_AttackCount);
        stats_AttackTimeReset = stats_HeavyMeleeTimeBeforeReset;
    }
    //Timer to reset AttackCount
    void StartMeleeTimer()
    {
        stats_AttackTimeReset -= Time.deltaTime;
    }
    void ResetMeleeCounter()
    {
        stats_AttackTimeReset = 0;
        stats_AttackCount = 0;
        stats_UsingMeleeAttack = false;
    }
    /// <summary>
    /// Update...Stats = For when an equipment current eqipped affects that object
    /// Change...Stats = For when a weapon is change
    /// Reset..Stats = To reset all stats of that current weapon type
    /// </summary>
    internal void UpdateSwordStats(bool Multiply, bool Divide, float valueto)
    {
        if (Multiply)
        {
            stats_LightMeleeDamage *= valueto;
        }
        if (Divide)
        {
            stats_LightMeleeDamage /= valueto;
        }
    }
    internal void UpdateAxeStats(bool Multiply, bool Divide, float valueto)
    {
        if (Multiply)
        {
            stats_HeavyMeleeDamage *= valueto;
        }
        if (Divide)
        {
            stats_HeavyMeleeDamage /= valueto;
        }
    }
    internal void UpdateBowDamageStats(bool Multiply, bool Divide, float valueto)
    {
        if (Multiply)
        {
            stats_BowDamage *= valueto;
        }
        if (Divide)
        {
            stats_BowDamage /= valueto;
        }
    }
    internal void UpdateBowFireRateStats(bool Multiply, bool Divide, float valueto)
    {
        if (Multiply)
        {
            stats_BowFireRate *= valueto;
        }
        if (Divide)
        {
            stats_BowFireRate /= valueto;
        }
    }
    internal void UpdateArrowSpeedStats(bool Multiply, bool Divide, float valueto)
    {
        if (Multiply)
        {
            stats_ArrowSpeed *= valueto;
        }
        if (Divide)
        {
            stats_ArrowSpeed /= valueto;
        }
    }
    internal void ChangeSword(PlayerWeapon_SO PWSO)
    {
        stats_StartingLightMeleeDamage = PWSO.weapon_Damage;
        stats_LightMeleeDamage = stats_StartingLightMeleeDamage;
    }
    internal void ChangeAxe(PlayerWeapon_SO PWSO)
    {
        stats_StartingHeavyMeleeDamage = PWSO.weapon_Damage;
        stats_HeavyMeleeDamage = stats_StartingHeavyMeleeDamage;
    }
    internal void ChangeBow(PlayerWeapon_SO PWSO)
    {
        stats_StartingBowDamage = PWSO.weapon_Damage;
        stats_StartingBowFireRate = PWSO.weapon_FireRate;
        stats_StartingArrowSpeed = PWSO.weapon_ProjectileSpeed;
        stats_BowDamage = stats_StartingBowDamage;
        stats_BowFireRate = stats_StartingBowFireRate;
        stats_ArrowSpeed = stats_StartingArrowSpeed;
    }
    internal void ResetSwordStats()
    {
        stats_LightMeleeDamage = stats_StartingLightMeleeDamage;
    }
    internal void ResetAxeStats()
    {
        stats_HeavyMeleeDamage = stats_StartingHeavyMeleeDamage;
    }
    internal void ResetBowAndArrowStats()
    {
        stats_BowDamage = stats_StartingBowDamage;
        stats_BowFireRate = stats_StartingBowFireRate;
        stats_ArrowSpeed = stats_StartingArrowSpeed;

    }
}
