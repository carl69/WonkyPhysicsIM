using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject Bullets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {


            GameObject bullet = Instantiate(Bullets);
            // Bullet rot
            bullet.transform.eulerAngles = Vector3.down * 90;
            // Bullet Pos
            bullet.transform.position = new Vector3(
                transform.position.x + 15,
                transform.position.y + Random.Range(-3,3),
                0);
        }
    }
}
