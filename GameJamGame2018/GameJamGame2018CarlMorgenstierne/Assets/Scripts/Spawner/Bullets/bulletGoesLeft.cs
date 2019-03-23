using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletGoesLeft : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = (Time.deltaTime*speed * -1);
		transform.Translate (x,0,0);

	}
}
