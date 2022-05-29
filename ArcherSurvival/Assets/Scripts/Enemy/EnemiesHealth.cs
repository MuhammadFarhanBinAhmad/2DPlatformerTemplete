using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHealth : MonoBehaviour
{
    EnemiesAnim scp_EnemiesAnim;
    EnemyMovement scp_EnemiesMovement;

    [SerializeField] internal float es_StartingEnemyHealth;
    [SerializeField] internal float es_EnemyHealth;
    [SerializeField] int es_StunPeriod;
    [SerializeField] bool type_FlyingEnemy;

    //for FlyingEnemy
    bool hit_Floor;
    private void Start()
    {
        scp_EnemiesAnim = GetComponentInChildren<EnemiesAnim>();
        scp_EnemiesMovement = GetComponent<EnemyMovement>();

        es_EnemyHealth = es_StartingEnemyHealth;
    }

    public void TakeDamage(float dmg)
    {
        if (es_EnemyHealth > 0)
        {
            es_EnemyHealth -= dmg;
            scp_EnemiesAnim.HitAnim();
        }
        if (es_EnemyHealth <= 0)
        {
            if (!type_FlyingEnemy)
            {
                scp_EnemiesAnim.DeathAnim();
                StartCoroutine("DestroyGameObject");
            }
            if (type_FlyingEnemy)
            {
                Falling();
            }
        }
        StartCoroutine("EnemyStun");
    }
    internal void RespawnEnemy()
    {
        es_EnemyHealth = es_StartingEnemyHealth;
        scp_EnemiesMovement.em_Stop = false;
    }
    internal void ResetHealth()
    {
        es_EnemyHealth = es_StartingEnemyHealth;
        scp_EnemiesMovement.em_Stop = false;
    }
    IEnumerator DestroyGameObject()
    {
        scp_EnemiesMovement.em_Stop = false;
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
    void Falling()
    {
        scp_EnemiesAnim.FallingAnim();
        GetComponent<Rigidbody2D>().gravityScale = 1;
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    IEnumerator EnemyStun()
    {
        scp_EnemiesAnim.HitAnim();
        //scp_EnemiesMovement.em_CurrentSpeed = 0;
        scp_EnemiesMovement.em_Stop = true;
        scp_EnemiesAnim.RunningAnim(true);
        yield return new WaitForSeconds(es_StunPeriod);
        scp_EnemiesAnim.RunningAnim(false);
        scp_EnemiesMovement.em_Stop = false;
        //scp_EnemiesMovement.em_CurrentSpeed = scp_EnemiesMovement.em_Speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6 && type_FlyingEnemy)
        {
            scp_EnemiesAnim.DeathAnim();
            StartCoroutine("DestroyGameObject");
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
