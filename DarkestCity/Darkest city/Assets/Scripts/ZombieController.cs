using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    public NavMeshAgent ZombieAgent;
    public int ZombieHealth = 1;

    Transform player;
    Transform Human;
    Vector3 RandomTargetPlacement;
    Vector3 target;

    ZombieLordController zombieLord;


    public enum CurState 
    {
        Follow,Chase
    }
    public CurState ZombieState;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        zombieLord = GameObject.FindGameObjectWithTag("ZombieLord").GetComponent<ZombieLordController>();
        zombieLord.AddZombie2List(this);
    }


    float curTimeTarget = 0;
    float TimeWaitTime = 0.1f;
    void FixedUpdate()// move this to a overlord controller
    {

        
        if (curTimeTarget < Time.time)
        {
            //Reset Timer
            curTimeTarget = Time.time + TimeWaitTime;


            switch (ZombieState)
            {
                case CurState.Follow:
                    //WALK
                    target = player.position + RandomTargetPlacement;

                    break;


                case CurState.Chase:
                    // go back to follow stage
                    if (Human == null)
                    {
                        ZombieState = CurState.Follow;
                    }
                    else
                    {
                        target = Human.position;
                    }


                    break;
                default:
                    break;
            }


            ZombieAgent.SetDestination(target);

        }

    }

    public void UpdateWalkPoint(Vector3 walkpoint)
    {
        RandomTargetPlacement = walkpoint;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Humans")
        {
            if (other.isTrigger)
            {
                return;
            }
            if (Human == null)
            {
                Human = other.transform;
                ZombieState = CurState.Chase;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //collision.transform.SendMessage("DealDamage");
        HumanController HC = collision.transform.GetComponent<HumanController>();
        HC.DealDamage();
        ZombieHealth -= HC.HumanDamage;

        if (ZombieHealth <= 0)
        {
            Destroy(this.gameObject);
        }

    }

}
