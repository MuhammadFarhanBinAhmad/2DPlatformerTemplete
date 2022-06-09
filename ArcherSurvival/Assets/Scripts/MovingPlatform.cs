using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public List<Transform> pos_Points;
    [SerializeField] int pos_CurrentPoint;

    [SerializeField] bool platform_IsMoving = true;
    [SerializeField] float platform_MoveSpeed;
    [SerializeField] float platform_WaitTime;

    private void Start()
    {
        transform.position = pos_Points[0].position;
    }

    private void FixedUpdate()
    {
        if(Vector2.Distance(transform.position,pos_Points[pos_CurrentPoint].position) < 0.05f)
        {
            if (platform_IsMoving)
            {
                StartCoroutine("Wait");
                platform_IsMoving = false;
            }
        }

        if (platform_IsMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos_Points[pos_CurrentPoint].position, platform_MoveSpeed * Time.deltaTime);
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(platform_WaitTime);
        pos_CurrentPoint++;
        if (pos_CurrentPoint > pos_Points.Count-1)
        {
            pos_CurrentPoint = 0;
        }
        platform_IsMoving = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
