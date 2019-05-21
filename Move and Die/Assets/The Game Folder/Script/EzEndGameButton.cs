using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EzEndGameButton : MonoBehaviour
{
    public bool MainMenu = false;
    public GameObject Menu;

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
                if (Menu.activeInHierarchy == true)
                {
                    Menu.SetActive(false);
                }
                else
                {
                    Menu.SetActive(true);
                }
            }
            
        }
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);

    }
    public void BackToGame()
    {
        Menu.SetActive(false);
    }
    public void EndGame()
    {
        Application.Quit();
    }

}
