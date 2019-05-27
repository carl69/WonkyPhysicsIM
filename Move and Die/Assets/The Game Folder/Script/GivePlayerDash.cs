using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePlayerDash : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<playerMovement>().PlayerDashUnlock = true;
        }
    }
}
