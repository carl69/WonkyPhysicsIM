using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPointScript : MonoBehaviour
{
    public GameObject ball;
    public GameObject Couonter;
    public Text UiText;
    GameManagerScript GM;
    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector2 spawnPoint = new Vector2(transform.position.x, transform.position.y + 1);

            other.gameObject.GetComponent<playerMovement>().SpawnPos = spawnPoint;

            UiText.text = GM.PlayerDeaths.ToString();

            ball.SetActive(true);
            Couonter.SetActive(true);
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
