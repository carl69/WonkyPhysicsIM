using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    public GameObject ball;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector2 spawnPoint = new Vector2(transform.position.x, transform.position.y + 1);

            other.gameObject.GetComponent<playerMovement>().SpawnPos = spawnPoint;

            ball.SetActive(true);
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        Vector2 spawnPoint = new Vector2(transform.position.x, transform.position.y + 2);

    //        other.gameObject.GetComponent<playerMovement>().SpawnPos = spawnPoint;
    //    }
    //}
}
