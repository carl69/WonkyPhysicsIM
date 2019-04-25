using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearingGround : MonoBehaviour
{
    public bool appear;
    public GameObject child;
    // Start is called before the first frame update

    public void Appear()
    {
        child = this.gameObject.transform.GetChild(0).gameObject;
        child.SetActive(true); child.GetComponent<Animator>().Play("Idle", -1, 0f);
    }
}
