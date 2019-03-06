using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject gameMenuConvas;
    public GameObject interfaceConvas;
    public GameObject fakeMenu;
    bool paused = false;
    bool fake = false;
    int timer = 1;
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused && !fake)
        {
            timer = 0; 
            interfaceConvas.SetActive(false);
            UnityEngine.Cursor.visible = true;
            gameMenuConvas.SetActive(true);
          
            paused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused && !fake)
        {
            timer = 1;
            gameMenuConvas.SetActive(false);
            UnityEngine.Cursor.visible = false;
            interfaceConvas.SetActive(true);
            paused = false;
        }

        if (Input.GetKeyDown(KeyCode.End) && !fake)
        {
            timer = 0;
            interfaceConvas.SetActive(false);
            UnityEngine.Cursor.visible = true;
            fakeMenu.SetActive(true);
            fake = true;
            
        }
        else if (Input.GetKeyDown(KeyCode.End) && fake)
        {
            if (paused)
            {
                timer = 0;
            }
            else timer = 1;

            fakeMenu.SetActive(false);
            UnityEngine.Cursor.visible = false;
            interfaceConvas.SetActive(true);
            fake = false;
        }

        Time.timeScale = timer;
        
    }
}
