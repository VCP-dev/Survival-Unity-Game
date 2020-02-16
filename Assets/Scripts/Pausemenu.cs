using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemenu : MonoBehaviour
{
   public static bool gameispaused=false;

   public GameObject PausemenuUI;

    void Start()
    {
        Cursor.visible=false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameispaused)
            {
               Cursor.visible=false;
               Resume();
            }
            else
            {
               Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.visible=false;
         PausemenuUI.SetActive(false);
                gameispaused=false;
                Time.timeScale=1f;

    }

    void Pause()
    {
        Cursor.visible=true;
         PausemenuUI.SetActive(true);
                gameispaused=true;
                Time.timeScale=0f;


    }

    public void Quitgame()
    {
        Application.Quit();
    }

}
