using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float playerWalkSpeed = 5;
    [Header("Jump Config")]
    public float jumpForce = 100;
    public float GravityDown = 2;
    public float JumpArc = 9;
    public bool isGrounded = false;
    Rigidbody RB;

    [Header("Collision Detection")]
    public LayerMask layerMask;


    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    bool falling = false;

    private void FixedUpdate(){

        // GRAVITY CHECK
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1, layerMask)) {

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            isGrounded = true;
        }
        else {
            isGrounded = false;
        }
    }


    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            RaycastHit hit;
            float inputAxes = Input.GetAxis("Horizontal");

            if (Physics.Raycast(transform.position + new Vector3(0, 0f, 0), transform.TransformDirection(Vector3.right * 2 * inputAxes), out hit, 1, layerMask))
            {
                Debug.DrawRay(transform.position + new Vector3(0, 0, 0), transform.TransformDirection(Vector3.right * inputAxes) * hit.distance, Color.yellow);
            }
            else
            {
            RB.velocity = new Vector3(
                inputAxes * playerWalkSpeed,
                RB.velocity.y,
                0);

            }

        }

        // JUMP

        if (Input.GetButtonDown("Jump"))
        {

            if (isGrounded)
            {
                RB.velocity = new Vector3(
                    RB.velocity.x,
                    0,
                    RB.velocity.z);

                RB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

                StartCoroutine("GoingUp");

            }

        }
        
        if (Input.GetButtonUp("Jump")) 
        {
            if (RB.velocity.y > 0)
            {
                StartCoroutine("GoingDown");
            }
            Down = false;
        }

        if (Down)
        {
            if (RB.velocity.y <= JumpArc)
            {
                StartCoroutine("GoingDown");
                Down = false;
            }
        }


    }
    bool Down = false;



    IEnumerator GoingUp()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();

        Down = true;       
    }

    IEnumerator GoingDown()
    {
        RB.AddForce(Vector3.up * GravityDown, ForceMode.Impulse);
        return null;
    }


    // DYING
    public void PlayerGotHit()
    {
        SceneManager.LoadScene(0);

    }
}
