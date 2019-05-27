using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public bool LastLevel = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!LastLevel)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
