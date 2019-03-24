using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    public int X;
    public int Z;
    public GameObject Grid;

    // Start is called before the first frame update
    void Start()
    {
        for (int Xside = 0; Xside < X; Xside++)
        {
            for (int Zside = 0; Zside < Z; Zside++)
            {
                Vector3 pos = new Vector3(Xside,0,Zside);

                GameObject GridBox = Instantiate(Grid,transform);
                GridBox.transform.position = pos;
            }
        }
    }


}
