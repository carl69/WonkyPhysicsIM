using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieObjectSpawner : MonoBehaviour {
	public GameObject[] Enemies;

	public float HighestSpawn = 5;
	public float LowestSpawn = -5;

	int itemSpawn = 0;

    public bool[] Spawns;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && Spawns[0] == true) {
			itemSpawn = 0;
			Spawn ();
		}else
			if (Input.GetKeyDown(KeyCode.D) && Spawns[1] == true) {
			itemSpawn = 1;
			Spawn ();
			}else
				if (Input.GetKeyDown(KeyCode.A) && Spawns[2] == true) {
			itemSpawn = 2;
			Spawn ();
				}else
					if (Input.GetKeyDown(KeyCode.Space) && Spawns[3] == true) {
			itemSpawn = 3;
			Spawn ();
					}else if (Input.GetMouseButtonDown(1) && Spawns[4] == true) {
			itemSpawn = 4;
			Spawn ();
		}
	}

    void Spawn(){
		float posY = Random.Range (LowestSpawn,HighestSpawn);


		Instantiate (Enemies[itemSpawn], new Vector3(transform.position.x, posY, 0),Quaternion.identity);
	}
}
