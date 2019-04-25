using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject Bullets;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("SpawnBullet") || Input.GetButtonDown("crouch"))
        {


            GameObject bullet = Instantiate(Bullets);
            // Bullet rot
            bullet.transform.eulerAngles = Vector3.down * 90;
            // Bullet Pos
            bullet.transform.position = new Vector3(
                transform.position.x + 20,
                Player.position.y + Random.Range(0,4),
                0);
        }
    }
}
