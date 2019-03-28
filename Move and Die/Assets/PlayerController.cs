using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerWalkSpeed = 5;
    [Header("Jump Config")]
    public float jumpForce = 100;
    public float GravityDown = 2;
    float gravityGoinDown = 0;

    Rigidbody RB;
    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * playerWalkSpeed * Time.deltaTime,0,0);

        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                RB.velocity = new Vector3(
                    RB.velocity.x,
                    0,
                    RB.velocity.z);

                RB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

                StartCoroutine("GoingUp");
            }
        }

        if (Input.GetButtonUp("Jump") && Down) 
        {
            StartCoroutine("GoingDown");
            Down = false;

        }

        if (Down)
        {
            if (RB.velocity.y <= 11)
            {
                Debug.Log("???");
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

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

}
