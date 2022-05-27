using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D p_RigidBody2D;
    [SerializeField]internal float go_ProjectileSpeed;
    [SerializeField]internal float go_ProjectileDamage;
    private void Start()
    {
        p_RigidBody2D = GetComponent<Rigidbody2D>();
        StartCoroutine("DestroyProjectile");
    }
    // Update is called once per frame
    void Update()
    {
        p_RigidBody2D.velocity = transform.right * go_ProjectileSpeed;
    }

    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<EnemiesHealth>() !=null)
        {
            other.GetComponent<EnemiesHealth>().TakeDamage(go_ProjectileDamage);
            Destroy(gameObject);
        }
    }
}
