using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHealth : MonoBehaviour
{
    EnemiesAnim scp_EnemiesAnim;
    EnemyMovement scp_EnemiesMovement;

    [SerializeField] internal int es_EnemyHealth;

    [SerializeField] bool type_FlyingEnemy;

    //for FlyingEnemy
    bool hit_Floor;
    private void Start()
    {
        scp_EnemiesAnim = GetComponentInChildren<EnemiesAnim>();
        scp_EnemiesMovement = GetComponent<EnemyMovement>();
    }

    public void TakeDamage(int dmg)
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
    IEnumerator DestroyGameObject()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
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
        scp_EnemiesMovement.em_CurrentSpeed = 0;
        yield return new WaitForSeconds(1);
        scp_EnemiesMovement.em_CurrentSpeed = scp_EnemiesMovement.em_Speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            scp_EnemiesAnim.DeathAnim();
            StartCoroutine("DestroyGameObject");
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
