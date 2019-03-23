using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone01MovementScript : MonoBehaviour {
	public float WalkingSpeed;
	public float RunSpeadMultiplier;
	public float floatingPower;



    bool grounded;
    public float airTime;
    float atimer;


	public GameObject Shild;
	public float shildTime = 2;
	float shilddown = 0;
	public float shildCooldown = 1;

	public float bulletSpeed = 10;
	private Vector3 target;


	private GameObject bullet;
	public GameObject bullet1;



    public AudioClip shooting;
    public AudioClip Shildsound;
    AudioSource AS;
	// Use this for initialization
	void Start () {
		target = transform.position;
        AS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetButtonDown("Fire1"))
		{
            AS.PlayOneShot(shooting);

			Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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







		if (Input.GetMouseButtonDown(1) && Shild.activeSelf == false && shilddown > shildCooldown) {

            AS.PlayOneShot(Shildsound);
			Shild.SetActive (true);
		}
		if (Shild.activeSelf == true) {
			shilddown += Time.deltaTime;
			if (shilddown > shildTime) {
				Shild.SetActive (false);
				shilddown = 0;
			}
		}else if (shilddown < shildCooldown) {
			shilddown += Time.deltaTime;
		}



		if (Input.GetAxis("Horizontal") != 0) {
			float r = 1;
			if (Input.GetKey (KeyCode.LeftShift)) {
				r = RunSpeadMultiplier;
			} else {
				r = 1;
			}

			float x = (Input.GetAxis("Horizontal")* Time.deltaTime*WalkingSpeed*r);

			transform.Translate (x,0,0);
		}
		if (Input.GetKey(KeyCode.Space)) {
            //UsingFlyingGas();
            if (atimer > airTime)
            {
                return;
            }
            else
            {
                transform.Translate(0, floatingPower * Time.deltaTime, 0);
                atimer += Time.deltaTime;
            }
		}
	}

    private void UsingFlyingGas()
    {
        if (atimer > airTime)
        {
            return;
        }
        else
        {
            atimer += Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            atimer = 0;
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            grounded = false;
        }
    }
}
