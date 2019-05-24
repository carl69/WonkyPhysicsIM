using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject Bullets;
    public Transform Player;
    public GameManagerScript GMScript;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("SpawnBullet") || Input.GetButtonDown("crouch") || Input.GetButtonDown("Dash"))
        {


            GameObject bullet = Instantiate(Bullets);
            // Bullet Var
            bulletScript bs = bullet.GetComponent<bulletScript>();
            bs.GMS = GMScript;
            // add bullet to the list
            GMScript.BS.Add(bs);
            // Bullet rot
            bullet.transform.eulerAngles = Vector3.down * 90;
            // Bullet Pos
            bullet.transform.position = new Vector3(
                transform.position.x + 30,
                Player.position.y + Random.Range(0,4),
                0);
        }
    }
}
