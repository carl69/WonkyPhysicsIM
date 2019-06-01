using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject SpawnedObject;
    public int Length;
    public int Depth;
    public float Gaps;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Length; i++)
        {
            for (int u = 0; u < Depth; u++)
            {
                GameObject o = Instantiate(SpawnedObject);
                o.transform.position = new Vector3(i * Gaps,transform.position.y,u * Gaps);
                o.GetComponent<Renderer>().material.SetColor("Test",Color.red);
            }
        }
    }
}
