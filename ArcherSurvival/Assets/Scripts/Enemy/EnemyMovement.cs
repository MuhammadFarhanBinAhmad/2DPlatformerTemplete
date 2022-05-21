using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    EnemiesAttack scp_EnemiesAttack;
    PlayerHealth scp_PlayerHealth;
    EnemiesAnim scp_EnemiesAnim;

    [SerializeField] Transform pos_Point01, pos_Point02;
    Transform pos_CurrentPoint;

    [SerializeField] internal float em_Speed;
    internal float em_CurrentSpeed;

    [SerializeField]internal bool em_Stop;
    bool hit_Player;

    [SerializeField] float em_RestTimeBeforeMoving;
    int em_CurrentMovementState;

    RaycastHit2D hit;
    Vector3 raycast;

    private void Start()
    {
        scp_EnemiesAttack = FindObjectOfType<EnemiesAttack>();
        scp_EnemiesAnim = GetComponentInChildren<EnemiesAnim>();

        em_CurrentSpeed = em_Speed;
        pos_CurrentPoint = pos_Point01;
        raycast = transform.right;
    }
    private void FixedUpdate()
    {
        MovementPhase();
    }
    void MovementPhase()
    {
        float Distance = Vector2.Distance(transform.position, pos_CurrentPoint.position);
        hit = Physics2D.Raycast(transform.position, raycast, 1);


        //Reach Point
        if (Distance <= .5f)
        {
            if (!em_Stop)
            {
                em_Stop = true;
                scp_EnemiesAnim.RunningAnim(em_Stop);

                em_CurrentMovementState = 1;
                StartCoroutine("StartRest");
            }
        }

        //Contacted Player
        if (hit.collider != null)
        {
            if (hit.collider.GetComponent<PlayerHealth>() != null)
            {
                //stop to attack
                if (!em_Stop)
                {
                    em_Stop = true;
                    scp_EnemiesAnim.RunningAnim(em_Stop);

                    scp_PlayerHealth = hit.collider.GetComponent<PlayerHealth>();
                    em_CurrentMovementState = 2;
                }
            }
        }
        else if (scp_PlayerHealth != null)
        {
            scp_PlayerHealth = null;
            StartCoroutine("ContinueMoving");
        }

        //Patrolling
        if (!em_Stop)
        {
            em_CurrentMovementState = 0;
        }

        switch (em_CurrentMovementState)
        {
            //Move
            case 0:
                transform.position += transform.right* em_CurrentSpeed * Time.fixedDeltaTime;
                break;
            //Rest
            case 1:
                em_Stop = true;
                scp_EnemiesAnim.RunningAnim(em_Stop);
                break;
            //ContactPlayer
            case 2:
                em_Stop = true;
                scp_EnemiesAnim.RunningAnim(em_Stop);
                scp_EnemiesAttack.DetectPlayer();
                break;


        }
    }
    void ChangeCurrentPoint()
    {
        if (pos_CurrentPoint == pos_Point01)
        {
            pos_CurrentPoint = pos_Point02;
            return;
        }
        if (pos_CurrentPoint == pos_Point02)
        {
            pos_CurrentPoint = pos_Point01;
            return;
        }
        em_CurrentMovementState = 0;
    }
    void ChangeDirection()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);//Face opposite direction

        em_Stop = false;
        scp_EnemiesAnim.RunningAnim(em_Stop);

        em_Speed = em_Speed *-1;//Move opposite directon
        em_CurrentSpeed = em_Speed;
        raycast *= -1;
    }
    IEnumerator ContinueMoving()
    {
        yield return new WaitForSeconds(em_RestTimeBeforeMoving);

        em_Stop = false;
        scp_EnemiesAnim.RunningAnim(em_Stop);

        em_CurrentMovementState = 0;
    }
    IEnumerator StartRest()
    {
        yield return new WaitForSeconds(em_RestTimeBeforeMoving);

        ChangeDirection();

        ChangeCurrentPoint();
    }
}
