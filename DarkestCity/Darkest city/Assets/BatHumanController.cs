using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BatHumanController : MonoBehaviour
{
    int HumanLife = 3;
    Transform target;
    public NavMeshAgent Human;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zombies")
        {
            if (other.isTrigger)
            {
                return;
            }

            target = other.transform;
        }
    }
    private void FixedUpdate()
    {
        if (target != null)
        {
            Human.SetDestination(target.position);
        }
    }


}
