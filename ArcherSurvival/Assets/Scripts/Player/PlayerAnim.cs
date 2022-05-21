using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    PlayerMovement scp_PlayerMovement;
    PlayerGroundCheck scp_PlayerGroundCheck;

    [SerializeField] Animator anim_PlayerAnimator;
    bool m_IsMoving;
    bool m_IsRolling;
    // Start is called before the first frame update
    void Start()
    {
        scp_PlayerMovement = FindObjectOfType<PlayerMovement>();
        scp_PlayerGroundCheck = FindObjectOfType<PlayerGroundCheck>();
        anim_PlayerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RunningAnimation();
        JumpingAnimation();
        DodgeRollAnim();
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
        anim_PlayerAnimator.SetBool("Grounded", scp_PlayerGroundCheck.m_IsGrounded);
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
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, transform.up, 1);

        if (Input.GetButton("DodgeRoll") && Input.GetAxis("Horizontal") != 0 && scp_PlayerGroundCheck.m_IsGrounded)
        {
            m_IsRolling = true;
            anim_PlayerAnimator.SetBool("DodgeRoll", m_IsRolling);
        }
        else
        {
            if (hit.collider == null)
            {
                m_IsRolling = false;
                anim_PlayerAnimator.SetBool("DodgeRoll", m_IsRolling);
            }    
        }
    }
    internal void StunAnimation()
    {
        anim_PlayerAnimator.SetTrigger("Stun");
    }
}
