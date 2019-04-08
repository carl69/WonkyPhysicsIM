﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // JUMPING
    [Header("Jump Settings")]
    public float JumpSpeed;
    public float JumpHight;
    float curJumpHight;
    public float fallSpeed = 2;
    float curFallSpeed = 0;
    public LayerMask JumpableLayers;
    // WALKING
    [Header("Walking Settings")]
    public float WalkingSpeed = 10;


    //Refrences
    Rigidbody RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        curFallSpeed = fallSpeed;// set the fall speed on the start incase the player starts in the air
    }

    private void FixedUpdate()
    {
        //Walking
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            float inputHorizontal = Input.GetAxisRaw("Horizontal");

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right * inputHorizontal), out hit, 0.5f, JumpableLayers))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right * inputHorizontal), Color.yellow); // shows Debug
                print("WALLS");
            }
            else
            {
                //RB.AddForce(Vector3.right * WalkingSpeed * inputHorizontal * Time.deltaTime,ForceMode.Impulse);
                transform.position += Vector3.right * WalkingSpeed * inputHorizontal * Time.deltaTime;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {



        //JUMPING 
        if (Input.GetButtonDown("Jump"))
        {
            // check if you are grounded
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1, JumpableLayers)){
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow); // shows Debug

                //setting maxHight
                curJumpHight = JumpHight + transform.position.y;

                JumpTakeOff();

                StartCoroutine("Jumping");

                curFallSpeed = 0;

            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            curJumpHight = 0;
        }

        // FakeGravity
        RB.velocity -= new Vector3(0, Time.deltaTime * curFallSpeed, 0); //Placeholder

    }

    // the jump start
    void JumpTakeOff()
    {
        RB.AddForce(Vector3.up * JumpSpeed,ForceMode.Impulse);
    }


    IEnumerator Jumping()
    {
        yield return new WaitForFixedUpdate();

        // checks if the player are moving down and stopping the jump here
        if (RB.velocity.y <= 0)
        {
            print("Happen");
            curFallSpeed = fallSpeed;

            yield return null;
        }

        // checks if the player have reach their target hight
        if (curJumpHight >= transform.position.y)
        {
            StartCoroutine("Jumping");
            yield return null;
        }
        else
        {
            curFallSpeed = fallSpeed;

            RB.velocity = new Vector3(
                RB.velocity.x,
                0, // Sett the Y velocity to 0
                RB.velocity.z);
        }
        
    }

}