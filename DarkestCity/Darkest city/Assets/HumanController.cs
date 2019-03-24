using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public GameObject ZombiePrefab;
    public int HumanLife = 1;
    public int HumanDamage = 0;

    public void DealDamage()
    {
        HumanLife --;
        if (HumanLife <= 0)
        {
            print("human Turned");
            GameObject Z = Instantiate(ZombiePrefab, null);
            Z.transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }
}
