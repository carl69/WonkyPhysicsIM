using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    public void Heal()
    {
        player.GetComponent<Health>().hitPoints += 25;
    }
    public void Blast()
    {
        Instantiate(Resources.Load("Blast attack"), player.transform.position, player.transform.rotation);
    }
    public void Range()
    {
        Instantiate(Resources.Load("Ranged attack"), player.transform.position, player.transform.rotation);
    }
    public void Melee()
    {
        Instantiate(Resources.Load("Melee attack"), player.transform.position, player.transform.rotation);
    }
}
