using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    PlayerAnim scp_PlayerAnim;
    PlayerHealth_EquipmentUI scp_PlayerHealth_EquipmentUI;

    const float s_StartingPlayerHealth = 100;
    public float s_TotalPlayerHealth;
    public float s_CurrentPlayerHealth;

    internal Rigidbody2D p_Rigidbody2D;

    internal bool s_isStun;
    [SerializeField] int s_PushbackForce;

    public float t_StunTime;

    private void Start()
    {
        p_Rigidbody2D = GetComponent<Rigidbody2D>();
        scp_PlayerAnim = FindObjectOfType<PlayerAnim>();
        scp_PlayerHealth_EquipmentUI = FindObjectOfType<PlayerHealth_EquipmentUI>();

        //Set starting player health
        s_TotalPlayerHealth = s_StartingPlayerHealth;
        s_CurrentPlayerHealth = s_TotalPlayerHealth;

    }
    internal void TakeDamage(int dmg)
    {
        p_Rigidbody2D.velocity = -transform.right * s_PushbackForce;//pushback player
        scp_PlayerAnim.StunAnimation();
        StartCoroutine("StunPeriod");
        s_isStun = true;
        s_CurrentPlayerHealth -= dmg;
        scp_PlayerHealth_EquipmentUI.UpdateHealthBar();

    }
    //for Healthpack and HeatlhDrain Ability
    internal void AddHealth(int health)
    {
        s_CurrentPlayerHealth += health;
        if (s_CurrentPlayerHealth >= s_TotalPlayerHealth)
        {
            s_CurrentPlayerHealth = s_TotalPlayerHealth;
        }
        scp_PlayerHealth_EquipmentUI.UpdateHealthBar();
    }
    //If passive equipment has effect on healthh
    internal void UpdateHealthAmount(bool Multiply,bool Divide, float valueto)
    {
        if (Multiply)
        {
            s_TotalPlayerHealth *= valueto;
            s_CurrentPlayerHealth *= valueto;
        }
        if (Divide)
        {
            s_TotalPlayerHealth /= valueto;
            s_CurrentPlayerHealth /= valueto;
        }
        scp_PlayerHealth_EquipmentUI.UpdateHealthBar();
    }
    //Reset health stats to its original(Before equipment effect) value
    internal void ResetHealthAmount()
    {
        float HealthPercentage = s_CurrentPlayerHealth / s_TotalPlayerHealth;
        s_TotalPlayerHealth = s_StartingPlayerHealth;
        s_CurrentPlayerHealth = s_TotalPlayerHealth * HealthPercentage;//To ensure player health is off correct value when health stats are reset
        scp_PlayerHealth_EquipmentUI.UpdateHealthBar();
    }
    IEnumerator StunPeriod()
    {
        yield return new WaitForSeconds(t_StunTime);
        s_isStun = false;
    }
}
