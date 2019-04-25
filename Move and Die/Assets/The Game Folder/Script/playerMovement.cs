using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    // IsGrounded
    [Header("isGrounded Settings")]
    public bool isGrounded = false;
    float AirJumpTime = 0.2f;
    float CurAirTimer = 0;

    // WALKING
    [Header("Walking Settings")]
    public float WalkingSpeed = 10;

    // Animations
    [Header("Animation Settings")]
    public Animator anim;

    // Death
    [Header("Death settings")]
    public bool OldDeath = false;
    [HideInInspector]
    public Vector3 SpawnPos;

    // Crouch


    //Refrences
    Rigidbody RB;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPos = transform.position;
        RB = GetComponent<Rigidbody>();
        curFallSpeed = fallSpeed;// set the fall speed on the start incase the player starts in the air
    }

    private void FixedUpdate()
    {
        //Walking
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        if (inputHorizontal != 0)
        {
            
            Vector3 rayStartPos = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);

            RaycastHit hit;
            if (Physics.Raycast(rayStartPos, transform.TransformDirection(Vector3.right * inputHorizontal), out hit, 0.3f, JumpableLayers))
            {
                Debug.DrawRay(rayStartPos, transform.TransformDirection(Vector3.right * inputHorizontal), Color.yellow); // shows Debug
                print("WALLS");
            }
            else
            {

                anim.SetFloat("WalkSpeed", inputHorizontal);
                transform.position += Vector3.right * WalkingSpeed * inputHorizontal;// * Time.deltaTime;

                if (Input.GetButton("crouch"))
                {
                    anim.SetTrigger("Slide");
                }
            }

        }
        else
        {
            anim.SetFloat("WalkSpeed", 0);
        }

        if (!Input.GetButton("crouch"))
        {
            anim.SetBool("Slide", false);
        }

        // Is Grounded
        RaycastHit hitGround;
        Vector3 RayStartPos = new Vector3(transform.position.x,
            transform.position.y + 0.9f,
            transform.position.z);

        //if (Physics.Raycast(RayStartPos, transform.TransformDirection(Vector3.right + Vector3.down * 2), out hitGround, 1f, JumpableLayers))
        //{
        //    Debug.DrawRay(RayStartPos, transform.TransformDirection(Vector3.right + Vector3.down * 2) * hitGround.distance, Color.yellow); // shows Debug
        //    Debug.DrawRay(RayStartPos, transform.TransformDirection(Vector3.left + Vector3.down * 2) * hitGround.distance, Color.yellow); // shows Debug
        //    isGrounded = true;
        //    CurAirTimer = AirJumpTime + Time.time;

        //}
        //else if (Physics.Raycast(RayStartPos, transform.TransformDirection(Vector3.left + Vector3.down * 2), out hitGround, 1f, JumpableLayers))
        //{
        //    Debug.DrawRay(RayStartPos, transform.TransformDirection(Vector3.right + Vector3.down * 2) * hitGround.distance, Color.yellow); // shows Debug
        //    Debug.DrawRay(RayStartPos, transform.TransformDirection(Vector3.left + Vector3.down * 2) * hitGround.distance, Color.yellow); // shows Debug
        //    isGrounded = true;
        //    CurAirTimer = AirJumpTime + Time.time;
        //}
        // Checks under
        if (Physics.Raycast(RayStartPos, transform.TransformDirection( Vector3.down), out hitGround, 1f, JumpableLayers))
        {
            Debug.DrawRay(RayStartPos, transform.TransformDirection( Vector3.down) * hitGround.distance, Color.yellow); // shows Debug
            isGrounded = true;
            CurAirTimer = AirJumpTime + Time.time;


        }
        else
        {
            if (CurAirTimer <= Time.time)
            {
                // Stop being grounded
                isGrounded = false;
            }

        }
        anim.SetBool("IsGrounded", isGrounded);

        if (isGrounded)
        {
            if (inputHorizontal == 0)
            {
                // Crouch
                if (Input.GetButton("crouch"))
                {
                    anim.SetBool("Crouch", true);
                }
                else
                {
                    anim.SetBool("Crouch", false);
                }
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
            
            if (isGrounded){
                // no more extra airtime for you
                CurAirTimer = 0;
                isGrounded = false;

                //setting maxHight
                curJumpHight = JumpHight + transform.position.y;

                JumpTakeOff();

                StartCoroutine("Jumping");

                curFallSpeed = 0;

            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            curJumpHight = curJumpHight / 2;
        }

        // FakeGravity
        RB.velocity -= new Vector3(0, Time.deltaTime * curFallSpeed, 0); //Placeholder

    }

    // the jump start
    void JumpTakeOff()
    {
        anim.SetTrigger("Jumping");
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
    // DYING
    public void PlayerGotHit()
    {
        if (OldDeath)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        }
        else
        {
            transform.position = SpawnPos;

        }
    }
}
