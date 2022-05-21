using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D p_Rigidbody2D;
    PlayerAnim scp_PlayerAnim;
    PlayerAttack scp_PlayerAttack;
    PlayerHealth scp_PlayerHealth;
    PlayerGroundCheck scp_PlayerGroundCheck;

    //Movement
    [SerializeField] internal float m_PlayerSpeed;
    [SerializeField] float m_PlayerJumpForce;
    [SerializeField] float m_RollMultiplier;
    [SerializeField] bool m_IsRolling;
    [SerializeField] float m_JumpTimeCounter;
    [SerializeField] float m_JumpTime;
    //Effect
    [SerializeField] GameObject vfx_JumpSmoke;
    // Start is called before the first frame update
    void Start()
    {
        p_Rigidbody2D = GetComponent<Rigidbody2D>();
        scp_PlayerAnim = FindObjectOfType<PlayerAnim>();
        scp_PlayerAttack = GetComponent<PlayerAttack>();
        scp_PlayerHealth = GetComponent<PlayerHealth>();
        scp_PlayerGroundCheck = FindObjectOfType<PlayerGroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!scp_PlayerAttack.pa_UsingMeleeAttack && !scp_PlayerHealth.s_isStun)
        {
            Running();
            Jumping();
            DodgeRoll();
        }
    }
    void Running()
    {
        float m_HorizontalMovement = Input.GetAxis("Horizontal");
        if (m_HorizontalMovement >= .1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (m_HorizontalMovement <= -.1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        //movement
        transform.position += new Vector3(m_HorizontalMovement, 0, 0) * m_PlayerSpeed * Time.fixedDeltaTime;
    }

    void DodgeRoll()
    {
        float m_HorizontalMovement = Input.GetAxis("Horizontal");
        if (Input.GetButton("DodgeRoll") && Input.GetAxis("Horizontal") !=0 && scp_PlayerGroundCheck.m_IsGrounded)
        {
            transform.position += new Vector3(m_HorizontalMovement, 0, 0) * m_PlayerSpeed * m_RollMultiplier * Time.fixedDeltaTime;
        }
    }
    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && scp_PlayerGroundCheck.m_IsGrounded)
        {
            m_JumpTimeCounter = m_JumpTime;
            p_Rigidbody2D.velocity = Vector2.up * m_PlayerJumpForce;
            vfx_JumpSmoke.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Space) && !scp_PlayerGroundCheck.m_IsGrounded)
        {
            if (m_JumpTimeCounter >0)
            {
                p_Rigidbody2D.velocity = Vector2.up * m_PlayerJumpForce;
                m_JumpTimeCounter -= Time.deltaTime;
            }
        }
    }
}
