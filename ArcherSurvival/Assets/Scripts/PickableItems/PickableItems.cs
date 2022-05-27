using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItems : MonoBehaviour
{
    [SerializeField] internal bool GO_Health;
    [SerializeField] internal int h_value;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GO_Health)
        {
            FindObjectOfType<PlayerHealth>().AddHealth(h_value);
            Destroy(gameObject);
        }
    }
}
