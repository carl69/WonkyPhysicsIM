using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : MonoBehaviour {

    public GameObject WindScreen;
    public AudioSource music;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 13)
        {
            Time.timeScale = 0;
            music.Pause();
            WindScreen.SetActive(true);
        }
    }
}
