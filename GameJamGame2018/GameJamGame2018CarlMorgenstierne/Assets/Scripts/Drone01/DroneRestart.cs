using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DroneRestart : MonoBehaviour {
    public GameObject parent;

    Vector3 respawnPoint;
    private void Start()
    {
        respawnPoint = parent.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.layer == 9) {
            parent.transform.position = respawnPoint;
        }
        else if (collision.gameObject.layer == 15)
        {
            respawnPoint = collision.gameObject.transform.position;
            collision.gameObject.GetComponent<AudioSource>().Play();
        }
	}
}
