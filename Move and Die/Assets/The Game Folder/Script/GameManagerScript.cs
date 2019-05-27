﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public int GameMod = 1;
    public List<MyTurret> Turrets = new List<MyTurret>();

    // Bullets
    public List<bulletScript> BS = new List<bulletScript>();
    public void playerDeath()
    {
        foreach (bulletScript bulletS in BS)
        {
            //BS.Remove(bulletS);

            bulletS.DestroyBullet();
        }
        BS.Clear();
    }

    // GAMEMODE
    private void Start()
    {
        GameMod = PlayerPrefs.GetInt("GameMode",1); // LOAD THE GAMEMODE
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Gamemode 1");
            PlayerPrefs.SetInt("GameMode", 1); // SAVE THE GAMEMODE
            foreach (MyTurret l in Turrets)
            {
                l.GameMod = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Gamemode 2");
            PlayerPrefs.SetInt("GameMode", 2); // SAVE THE GAMEMODE
            foreach (MyTurret l in Turrets)
            {
                l.GameMod = 2;
            }
        }

    }


}