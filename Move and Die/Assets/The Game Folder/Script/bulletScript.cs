using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float Speed;
    [HideInInspector]
    public GameManagerScript GMS;


    void Update()
    {
        transform.localPosition += transform.rotation * Vector3.forward * Speed * Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<playerMovement>().PlayerGotHit();
        }
        else
        {
            GMS.BS.Remove(this); // happens if bullets hits walls or other things

        }

        DestroyBullet();
    }

    public void DestroyBullet()
    {
        Destroy(this.gameObject); // bullet gets destroyed
    }
}
