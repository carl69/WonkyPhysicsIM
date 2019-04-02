using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [Header("Jump Settings")]
    public float JumpSpeed;
    public float JumpHight;
    float curJumpHight;


    //Refrences
    Rigidbody RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //setting maxHight
            curJumpHight = JumpHight + transform.position.y;

            JumpTakeOff();

            StartCoroutine("Jumping");
        }

        if (Input.GetButtonUp("Jump"))
        {
            curJumpHight = 0;
        }
    }

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
            Debug.Log(curJumpHight);
            Debug.Log(transform.position.y);

            RB.velocity = new Vector3(
                RB.velocity.x,
                0, // Sett the Y velocity to 0
                RB.velocity.z);
        }
        
    }

}
