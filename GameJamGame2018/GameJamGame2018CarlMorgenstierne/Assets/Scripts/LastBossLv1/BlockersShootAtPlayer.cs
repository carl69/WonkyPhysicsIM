using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockersShootAtPlayer : MonoBehaviour {
    private GameObject player;

    private GameObject bullet;
    public GameObject bullet1;
    public float bulletSpeed;

    public float fireRate = 2;
    float timer;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        if (timer < fireRate)
        {
            timer += Time.deltaTime;
        }else
        if (Input.GetButtonDown("Fire1"))
        {
            timer = 0;

            Vector3 worldMousePos = player.transform.position;
            Vector2 direction = (Vector2)((worldMousePos - transform.position));
            direction.Normalize();
            // Creates the bullet locally
            GameObject bullet = (GameObject)Instantiate(
                bullet1,
                transform.position + (Vector3)(direction * 0.5f),
                Quaternion.identity);
            // Adds velocity to the bullet
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }
}
