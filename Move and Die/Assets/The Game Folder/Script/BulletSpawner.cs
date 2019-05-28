using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject Bullets;
    public Transform Player;
    public GameManagerScript GMScript;

    float dir = 0;
    float oldDir = 0;

    private void FixedUpdate()
    {
        float curDir = Input.GetAxis("Horizontal");
        if (curDir < 0)
        {
            dir = -1;
        }
        else if (curDir > 0)
        {
            dir = 1;
        }

        if (dir != oldDir)
        {
            oldDir = dir;

            spawnBullet();
        }
    }
    // Update is called once per frame
    void Update()
    {
        //float curDir = Input.GetAxis("Horizontal");
        //if (curDir < 0)
        //{
        //    dir = -1;
        //}
        //else if (curDir > 0)
        //{
        //    dir = 1;
        //}

        //if (dir != oldDir)
        //{
        //    oldDir = dir;
        //    spawnBullet();
        //}


        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("crouch") || Input.GetButtonDown("Dash"))
        {
            spawnBullet();
        }
    }
    void spawnBullet()
    {
        GameObject bullet = Instantiate(Bullets, new Vector3(
            transform.position.x + 30,
            Player.position.y + Random.Range(0, 4),
            0),Quaternion.identity);

        // Bullet Var
        bulletScript bs = bullet.GetComponent<bulletScript>();
        bs.GMS = GMScript;
        // add bullet to the list
        GMScript.BS.Add(bs);
        // Bullet rot
        bullet.transform.eulerAngles = Vector3.down * 90;
        //// Bullet Pos
        //bullet.transform.position = new Vector3(
        //    transform.position.x + 30,
        //    Player.position.y + Random.Range(0, 4),
        //    0);
    }
}
