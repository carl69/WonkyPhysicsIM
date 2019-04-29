using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EzEndGameButton : MonoBehaviour
{
    public bool MainMenu = false; 

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Cancel"))
        {
            if (MainMenu)
            {
                Application.Quit();

            }
            else
            {
                SceneManager.LoadScene(0);
            }
            
        }
    }
}
