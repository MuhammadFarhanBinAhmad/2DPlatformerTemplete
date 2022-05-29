using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnemies : MonoBehaviour
{
    public List<GameObject> list_Enemies = new List<GameObject>();

    internal void CheckEnemyCurrentState()
    {
        for (int i =0;i <= list_Enemies.Count-1;i++ )
        {
            if (!list_Enemies[i].activeSelf)
            {
                list_Enemies[i].SetActive(true);
                list_Enemies[i].GetComponent<EnemiesHealth>().ResetHealth();

            }
            if (list_Enemies[i].GetComponent<EnemiesHealth>().es_EnemyHealth < list_Enemies[i].GetComponent<EnemiesHealth>().es_StartingEnemyHealth)
            {
                list_Enemies[i].GetComponent<EnemiesHealth>().ResetHealth();

            }

        }
    }
}
