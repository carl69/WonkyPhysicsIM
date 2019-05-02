using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

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

}
