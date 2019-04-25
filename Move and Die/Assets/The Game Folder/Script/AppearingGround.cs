using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearingGround : MonoBehaviour
{
    public bool appear;
    public GameObject child;
    // Start is called before the first frame update
    void Start()
    {
        child = this.gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (appear == true) { child.SetActive(true); child.GetComponent<Animator>().Play("Idle", -1, 0f); }
    }
}
