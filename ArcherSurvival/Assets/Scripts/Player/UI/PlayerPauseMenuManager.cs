using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPauseMenuManager : MonoBehaviour
{

    [SerializeField] GameObject ui_PauseMenup;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!ui_PauseMenup.activeSelf)
            {
                ui_PauseMenup.SetActive(true);
                return;
            }
            if (ui_PauseMenup.activeSelf)
            {
                ui_PauseMenup.SetActive(false);
                return;
            }
        }
    }
}
