using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerFollow : MonoBehaviour
{
    public Vector3 PlayerPos;
    public Transform Player;
    public float moveSpeed = 10;



    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(
            Player.position.x + PlayerPos.x,
            transform.position.y,
            PlayerPos.z);

        //transform.position = Vector3.MoveTowards(
        //    transform.position,
        //    targetPos,
        //    moveSpeed * Time.deltaTime);

        transform.position = Vector3.Lerp(
           transform.position,
           targetPos,
           moveSpeed * Time.deltaTime);
    }
}
