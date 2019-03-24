using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLordController : MonoBehaviour
{
    public GameObject ZombiePrefab;

    public List<ZombieController> Zombiez;


    // Start is called before the first frame update
    //void Start()
    //{
    //    GameObject[] zombas = GameObject.FindGameObjectsWithTag("Zombies");
    //    foreach (GameObject item in zombas)
    //    {
    //        Zombiez.Add(item.GetComponent<ZombieController>());
    //    }
    //}

        // zombies gets added when they turn
    public void AddZombie2List(ZombieController Z)
    {
        Zombiez.Add(Z);
        ZombieUpdate(); // update the zombie poss when following the player
    }

    public void ZombieUpdate()
    {
        // get zombie count
        int zombieCount = Zombiez.Count;


        // send the info
        foreach (ZombieController item in Zombiez)
        {
            // random target poss
            Vector3 target = new Vector3(
                Random.Range(-zombieCount / 3, zombieCount / 3),
                0,
                Random.Range(-zombieCount / 3, zombieCount / 3));

            item.UpdateWalkPoint(target);
        }
    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(ZombiePrefab);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            // get zombie count
            int zombieCount = Zombiez.Count;


            // send the info
            foreach (ZombieController item in Zombiez)
            {
                // random target poss
                Vector3 target = new Vector3(
                    Random.Range(-zombieCount / 3, zombieCount / 3),
                    0,
                    Random.Range(-zombieCount / 3, zombieCount / 3));

                item.UpdateWalkPoint(target);
            }
        }
    }
}
