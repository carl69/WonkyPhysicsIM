using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    



   public void EzLevel()
    {
        SceneManager.LoadScene(1);

    }

    public void HardLevel1()
    {
        SceneManager.LoadScene(2);

    }
    public void HardLevel2()
    {
        SceneManager.LoadScene(3);

    }
}
