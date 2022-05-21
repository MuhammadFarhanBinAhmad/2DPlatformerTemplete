using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesAnim : MonoBehaviour
{
    internal Animator anim_EnemyAnimator;

    void Start()
    {
        anim_EnemyAnimator = GetComponent<Animator>();
    }

    internal void HitAnim()
    {
        anim_EnemyAnimator.SetTrigger("TakingDamage");
    }
    internal void RunningAnim(bool isRunning)
    {
        anim_EnemyAnimator.SetBool("StopRunning", isRunning);
    }
    internal void AttackAnim()
    {
        anim_EnemyAnimator.SetTrigger("Attacking");
    }
    //For FlyingEnemy
    internal void FallingAnim()
    {
        anim_EnemyAnimator.SetTrigger("Falling");
    }
    internal void DeathAnim()
    {
        anim_EnemyAnimator.SetTrigger("Die");
    }
}
