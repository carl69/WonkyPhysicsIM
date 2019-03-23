using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShilds : MonoBehaviour {
    public float ReChargeTime = 5;
    float timer = 5;

    SpriteRenderer SR;
    CircleCollider2D CC2d;
	// Use this for initialization
	void Start () {
        SR = GetComponent<SpriteRenderer>();
        CC2d = GetComponent<CircleCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (timer < ReChargeTime)
        {
            timer += Time.deltaTime;
        }
        else if (SR.enabled == false)
        {
            SR.enabled = true;
            CC2d.enabled = true;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 13)
        {
            Destroy(collision.gameObject);
            timer = 0;

            SR.enabled = false;
            CC2d.enabled = false;
        }
    }
}
