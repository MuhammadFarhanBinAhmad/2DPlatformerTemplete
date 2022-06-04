using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth_EquipmentUI : MonoBehaviour
{
    PlayerHealth scp_PlayerHealth;
    PlayerAttack scp_PlayerAttack;

    //UI
    [Header("UI")]
    //Health
    public Image ui_PlayerHealth;
    public Image icon_PlayerSword;
    public Image icon_PlayerAxe;
    public Image icon_PlayerBow;
    public Image icon_PlayerEquipment;
    private void Start()
    {
        scp_PlayerHealth = FindObjectOfType<PlayerHealth>();
        scp_PlayerAttack = FindObjectOfType<PlayerAttack>();
    }

    internal void UpdateHealthBar()
    {
        float H = scp_PlayerHealth.s_CurrentPlayerHealth / scp_PlayerHealth.s_TotalPlayerHealth;
        ui_PlayerHealth.fillAmount = H;
    }
    internal void UpdateSwordIcon(Sprite image)
    {
        icon_PlayerSword.sprite = image;
    }
    internal void UpdateAxeIcon(Sprite image)
    {
        icon_PlayerAxe.sprite = image;
    }
    internal void UpdateBowIcon(Sprite image)
    {
        icon_PlayerBow.sprite = image;
    }
    internal void UpdateEquipmentIcon(Sprite image)
    {
        icon_PlayerEquipment.sprite = image;
    }
}
