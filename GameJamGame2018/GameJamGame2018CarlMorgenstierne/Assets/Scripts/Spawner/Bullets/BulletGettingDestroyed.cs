using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGettingDestroyed : MonoBehaviour {

	private void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Player") {
			return;
		} else {
            if (collision.gameObject.layer == 13)
            {
                Destroy(collision.gameObject);
            }
			Destroy (this.gameObject);
		}
	
	}
}
