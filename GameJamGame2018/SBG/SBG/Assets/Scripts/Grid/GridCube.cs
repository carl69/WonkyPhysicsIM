using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCube : MonoBehaviour
{
    public Material SelectedM;
    public Material DeSelectedM;
    public Material WalkableM;
    Material DefulM;


    public Renderer R;
    GridController GridC;


    bool movable = false;
    private void OnMouseDown()
    {
        if (movable)
        {
            R.material = SelectedM;
            GridC.Moving(this.gameObject);
        }

    }

    //private void OnMouseUp()
    //{
    //    R.material = DeSelectedM;
    //}


    void Start()
    {
        R = GetComponent<Renderer>();
        GridC = GameObject.FindGameObjectWithTag("GridController").GetComponent<GridController>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            R.material = WalkableM;
            movable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            R.material = DeSelectedM;
            movable = false;
        }
    }

}
