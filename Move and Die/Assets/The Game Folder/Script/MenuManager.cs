using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    public void QUITDAGAME()
    {
        Application.Quit();
    }


   public void Tutorial()
    {
        SceneManager.LoadScene(1);

    }

    public void SkipTutorial()
    {
        SceneManager.LoadScene(2);

    }
    public void loadingLevelX(int indexNr)
    {
        SceneManager.LoadScene(indexNr);

    }
    //public void LevelSelect()
    //{
    //    SceneManager.LoadScene(1);

    //}
}
