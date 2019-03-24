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
        player.GetComponent<Health>().hitPoints =+ 25;
    }
    public void Blast()
    {

    }
    public void Range()
    {

    }
    public void Melee()
    {

    }
}
