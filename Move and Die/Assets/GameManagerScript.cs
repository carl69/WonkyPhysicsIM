using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public int GameMod = 1;


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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Gamemode 1");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Gamemode 2");
        }

    }


}
