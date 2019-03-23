using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 3;
    public List<ZombieController> Zombiez;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] zombas = GameObject.FindGameObjectsWithTag("Zombies");
        foreach (GameObject item in zombas)
        {
            Zombiez.Add(item.GetComponent<ZombieController>());
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime,0,Input.GetAxisRaw("Vertical") * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.U))
        {
            // get zombie count
            int zombieCount = Zombiez.Count;




            // send the info
            foreach (ZombieController item in Zombiez)
            {
                // random target poss
                Vector3 target = new Vector3(
                    transform.position.x + Random.Range(-zombieCount/2, zombieCount/2),
                    0,
                    transform.position.z + Random.Range(-zombieCount/2, zombieCount/2));

                item.UpdateWalkPoint(target);
            }
        }
    }
}
