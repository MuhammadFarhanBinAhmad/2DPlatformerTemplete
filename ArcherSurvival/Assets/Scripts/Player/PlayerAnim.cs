using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    PlayerMovement scp_PlayerMovement;

    [SerializeField] Animator anim_PlayerAnimator;
    bool m_IsMoving;
    // Start is called before the first frame update
    void Start()
    {
        scp_PlayerMovement = FindObjectOfType<PlayerMovement>();
        anim_PlayerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RunningAnimation();
        JumpingAnimation();
    }
    void RunningAnimation()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            m_IsMoving = true;
            anim_PlayerAnimator.SetBool("Moving", m_IsMoving);
        }
        if (Input.GetAxis("Horizontal") == 0 && m_IsMoving == true)
        {
            m_IsMoving = false;
            anim_PlayerAnimator.SetBool("Moving", m_IsMoving);
        }
    }
    void JumpingAnimation()
    {
        anim_PlayerAnimator.SetBool("Grounded", scp_PlayerMovement.m_IsGrounded);
    }
    internal void ArrowAttackAnim()
    {
        anim_PlayerAnimator.SetTrigger("ArrowAttack");
    }
    internal void LightMeleeAttackAnim(int MA)
    {
        anim_PlayerAnimator.SetTrigger("LightMeleeAttack_" + MA);
    }
    internal void HeavyMeleeAttackAnim(int MA)
    {
        anim_PlayerAnimator.SetTrigger("HeavyMeleeAttack_" + MA);
    }
    internal void DodgeRollAnim()
    {
        anim_PlayerAnimator.SetTrigger("DodgeRoll");

    }
}
