using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTurret : MonoBehaviour
{
    public GameObject[] target;
    public float objectDistance;
    public float rotationDamping;
    public GameObject bulletSpawner;
    public GameObject bullet;



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        lookAtPlayer();
        for (var i = 0; i < target.Length; i++)
        {
            objectDistance = Vector3.Distance(target[i].transform.position, transform.position);

            if (objectDistance < 20f)
            {
                
            }
        }
        if (Input.anyKeyDown)
        {
            GameObject.Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
        }
    }
    void lookAtPlayer()
    {
        for (var i = 0; i < target.Length; i++)
        {
            Quaternion rotation = Quaternion.LookRotation(target[i].transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
        }
    }

}