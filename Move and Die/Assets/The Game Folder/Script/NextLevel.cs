using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public bool LastLevel = false;
    GameManagerScript GMS;
    AudioSource AudioS;
    bool won = false;
    public GameObject LevelCanvas;
    private void Start()
    {
        AudioS = GetComponent<AudioSource>();
        GMS = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && won == false)
        {
            won = true;
            GMS.GameWon();
            AudioS.Play();
            LevelCanvas.SetActive(true);
        }
    }
    public void LevelSelect()
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
