using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    PlayerHealth scp_PlayerHealth;
    PlayerAttack scp_PlayerAttack;

    int st_PlayerStartingHealth;

    //UI
    [Header("UI")]
    //Health
    public Image ui_PlayerHealth;

    public TextMeshProUGUI ui_TotalArrow;
    private void Start()
    {
        scp_PlayerHealth = FindObjectOfType<PlayerHealth>();
        scp_PlayerAttack = FindObjectOfType<PlayerAttack>();

        st_PlayerStartingHealth = scp_PlayerHealth.s_PlayerHealth;
    }

    internal void UpdateHealthBar()
    {
        float H = (float)scp_PlayerHealth.s_PlayerHealth / st_PlayerStartingHealth;
        ui_PlayerHealth.fillAmount = H;
    }

    internal void UpdateArrowInventory(int TA)
    {
        ui_TotalArrow.text = "x" + TA.ToString();
    }
}
