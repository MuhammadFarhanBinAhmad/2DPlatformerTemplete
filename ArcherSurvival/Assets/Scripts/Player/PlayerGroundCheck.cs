using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{

    PlayerMovement scp_PlayerMovement;

    [SerializeField]internal bool m_IsGrounded;
    [SerializeField] LayerMask l_GroundLayer;
    [SerializeField]Collider2D p_FootCollider;

    private void Start()
    {
        scp_PlayerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        //ground check
        m_IsGrounded = p_FootCollider.IsTouchingLayers(l_GroundLayer);
    }
}
