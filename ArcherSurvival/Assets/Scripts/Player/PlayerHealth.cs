using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    PlayerAnim scp_PlayerAnim;
    PlayerUI scp_PlayerUI;

    public int s_PlayerHealth;

    internal Rigidbody2D p_Rigidbody2D;

    internal bool s_isStun;
    [SerializeField] int s_PushbackForce;

    public float t_StunTime;

    private void Start()
    {
        p_Rigidbody2D = GetComponent<Rigidbody2D>();
        scp_PlayerAnim = FindObjectOfType<PlayerAnim>();
        scp_PlayerUI = FindObjectOfType<PlayerUI>();
    }
    internal void TakeDamage(int dmg)
    {
        p_Rigidbody2D.velocity = -transform.right * s_PushbackForce;//pushback player
        scp_PlayerAnim.StunAnimation();
        StartCoroutine("StunPeriod");
        s_isStun = true;
        s_PlayerHealth -= dmg;
        scp_PlayerUI.UpdateHealthBar();

    }

    IEnumerator StunPeriod()
    {
        yield return new WaitForSeconds(t_StunTime);
        s_isStun = false;
    }
}
