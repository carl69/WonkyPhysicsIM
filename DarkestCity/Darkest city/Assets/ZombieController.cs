using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    public Vector3 walkTarget;
    public NavMeshAgent ZombieAgent;




    public void UpdateWalkPoint(Vector3 walkpoint)
    {

        ZombieAgent.SetDestination(walkpoint);

    }
}
