using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    GameObject SelectedGrid;
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Moving(GameObject GridGameObject)
    {
        SelectedGrid = GridGameObject;
        Vector3 posi = SelectedGrid.transform.position;
        posi.y += 1;
        Player.transform.position = posi;
    }


}
