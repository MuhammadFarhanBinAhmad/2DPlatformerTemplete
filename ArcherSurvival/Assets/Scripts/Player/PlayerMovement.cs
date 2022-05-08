using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D p_Rigidbody2D;
    PlayerAnim scp_PlayerAnim;
    PlayerAttack scp_PlayerAttack;

    //Movement
    [SerializeField] internal float m_PlayerSpeed;
    [SerializeField] float m_PlayerJumpForce;
    [SerializeField] internal bool m_IsGrounded;
    [SerializeField] float m_RollMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        p_Rigidbody2D = GetComponent<Rigidbody2D>();
        scp_PlayerAnim = FindObjectOfType<PlayerAnim>();
        scp_PlayerAttack = FindObjectOfType<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!scp_PlayerAttack.pa_UsingMeleeAttack)
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
        transform.position += new Vector3(m_HorizontalMovement, 0, 0) * m_PlayerSpeed * Time.fixedDeltaTime;
    }

    void DodgeRoll()
    {
        if (Input.GetButtonDown("DodgeRoll") && Input.GetAxis("Horizontal") !=0 && m_IsGrounded)
        {
            print("Roll_01");
            scp_PlayerAnim.DodgeRollAnim();
            InvokeRepeating("Rolling",0,0.1f);
            StartCoroutine("CancelRoll");
            
        }
    }
    void Rolling()
    {
        print("Roll_02");
        float m_HorizontalMovement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(m_HorizontalMovement, 0, 0) * (m_PlayerSpeed* m_RollMultiplier) * Time.fixedDeltaTime;
    }
    IEnumerator CancelRoll()
    {
        yield return new WaitForSeconds(.5f);
        CancelInvoke();
    }
    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(p_Rigidbody2D.velocity.y) < 0.1f)
        {
            p_Rigidbody2D.AddForce(new Vector2(0, m_PlayerJumpForce), ForceMode2D.Impulse);
            m_IsGrounded = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            m_IsGrounded = true;
        }
    }
}
