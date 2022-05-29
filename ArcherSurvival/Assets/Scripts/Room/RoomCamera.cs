using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCamera : MonoBehaviour
{
    [SerializeField] RoomEnemies scp_RoomEnemies;
    [SerializeField] GameObject cam_VirtualCamera;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            cam_VirtualCamera.SetActive(true);
            if (scp_RoomEnemies != null)
            {
                scp_RoomEnemies.CheckEnemyCurrentState();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            cam_VirtualCamera.SetActive(false);
        }
    }
}
