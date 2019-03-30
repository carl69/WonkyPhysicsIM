using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float Speed;

    void Update()
    {
        transform.localPosition += transform.rotation * Vector3.left * Speed * Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().PlayerGotHit();
        }
        Destroy(this.gameObject);
    }
}
