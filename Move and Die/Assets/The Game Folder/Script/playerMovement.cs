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
    public Collider JumpingCollider;
    int jumps = 0;

    // IsGrounded
    [Header("isGrounded Settings")]
    public bool isGrounded = false;
    float AirJumpTime = 0.2f;
    float CurAirTimer = 0;
    bool landed = false;
    public GameObject LandingPartical;
    public Transform LandingParticalSpawn;
    // WALKING
    [Header("Walking Settings")]
    public float WalkingSpeed = 10;
    public Collider WalkingCollider;

    // Animations
    [Header("Animation Settings")]
    public Animator anim;

    // Death
    [Header("Death settings")]
    public Vector3 SpawnPos;

    // RESPAWN
    public float RespawnTime = 1f;
    float CurRespawnTime = 0;

    // Crouch
    [Header("SliderSettings")]
    public Collider SlidingCollider;
    bool crouch = false;

    public GameObject SlidingPartical;
    GameObject curSlidingPartical;

    // Air Drop
    [Header("Air Drop")]
    public float LengthOfDrop = 2;

    // Falling blocks
    [Header("BlockSettings")]
    public List<AppearingGround> Blocks;

    //Refrences
    Rigidbody RB;
    Collider curActivCollider;
    GameManagerScript gms;

    // Start is called before the first frame update
    void Start()
    {
        gms = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();
        SpawnPos = transform.position;
        RB = GetComponent<Rigidbody>();
        curFallSpeed = fallSpeed;// set the fall speed on the start incase the player starts in the air
        curActivCollider = WalkingCollider;// set the activ collider
    }

    private void FixedUpdate()
    {
        //Walking
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        if (inputHorizontal != 0 && CurRespawnTime <= 0)
        {
            
            Vector3 rayStartPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

            RaycastHit hit;
            if (Physics.Raycast(rayStartPos, transform.TransformDirection(Vector3.right * inputHorizontal), out hit, 0.6f, JumpableLayers))
            {
                Debug.DrawRay(rayStartPos, transform.TransformDirection(Vector3.right * inputHorizontal), Color.yellow); // shows Debug
                print("WALLS");
            }
            else
            {

                anim.SetFloat("WalkSpeed", inputHorizontal);
                transform.position += Vector3.right * WalkingSpeed * inputHorizontal;// * Time.deltaTime;

                if (!crouch)
                {
                    if (Input.GetButtonDown("crouch"))
                    {
                        anim.SetTrigger("Slide");

                    }
                    if (Input.GetButton("crouch"))
                    {
                        ChangeCollider(SlidingCollider);
                    }
                    else if (isGrounded)
                    {
                        ChangeCollider(WalkingCollider);
                    }
                }
            }
        }
        else
        {
            CurRespawnTime -= Time.deltaTime;
            anim.SetFloat("WalkSpeed", 0);
        }


        // Is Grounded
        RaycastHit hitGround;
        Vector3 RayStartPos = new Vector3(transform.position.x,
            transform.position.y + 0.9f,
            transform.position.z);

        RaycastHit hits;
        Vector3 rayStartsPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

        // Checks under
        if (Physics.Raycast(RayStartPos, transform.TransformDirection(Vector3.down), out hitGround, 1.5f, JumpableLayers) || Physics.Raycast(rayStartsPos, transform.TransformDirection(Vector3.right * inputHorizontal), out hits, 0.6f, JumpableLayers))
        {
            Debug.DrawRay(RayStartPos, transform.TransformDirection(Vector3.down) * hitGround.distance, Color.yellow); // shows Debug
            isGrounded = true;
            CurAirTimer = AirJumpTime + Time.time;
            //Set Double Jumps
            jumps = 1;

            // LANDED
            if (landed == false)
            {
                landed = true;
                GameObject landingpartical = Instantiate(LandingPartical);
                landingpartical.transform.position = LandingParticalSpawn.position;
            }
        }
        else
        {
            // NO LONGER LANDED
            if (landed == true)
            {
                landed = false;
            }

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
                    crouch = true;
                    anim.SetBool("Crouch", true);
                }
                else
                {
                    crouch = false;
                    anim.SetBool("Crouch", false);
                }
                if (!crouch)
                {
                    ChangeCollider(WalkingCollider);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // STARTS WALKING
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            CurRespawnTime = 0;
        }

        // teleport down
        if (Input.GetButtonDown("crouch"))
        {
            RaycastHit hitGround;
            Vector3 RayStartPos = new Vector3(transform.position.x,
                transform.position.y + 1f,
                transform.position.z);

            curJumpHight = 0; // STOPS THE JUMP
            ChangeCollider(WalkingCollider); // change colliders

            if (Physics.Raycast(RayStartPos, transform.TransformDirection(Vector3.down), out hitGround, LengthOfDrop +2f, JumpableLayers))
            {
                RB.velocity = new Vector3(RB.velocity.x, 0, 0);
                transform.position = hitGround.point + new Vector3(0, 0, 0);
                Debug.Log("Ground");
            }
            else
            {
                transform.position += Vector3.down * LengthOfDrop;
                Debug.Log("AIR");
            }
        }

        // STOP JUMPING
        if (Input.GetButtonUp("Jump"))
        {
            curJumpHight = curJumpHight / 2;
        }

        //JUMPING 
        if (Input.GetButtonDown("Jump"))
        {
            // check if you are grounded

            if (isGrounded)
            {
                jumps = 1;
            }

            if (isGrounded || jumps >= 1)
            {
                RB.velocity = new Vector3(RB.velocity.x,0,0);

                //Give doubleJump
                if (jumps <= 0)
                {
                    
                }
                else if (!isGrounded)// Remove the jumps
                {
                    jumps -= 1;
                }

                //setting maxHight
                if (isGrounded)
                {
                    curJumpHight = JumpHight + transform.position.y;
                    anim.SetTrigger("Jumping");

                }
                else
                {
                    curJumpHight = JumpHight/2 + transform.position.y;
                    anim.SetTrigger("DoubleJump");


                }

                // no more extra airtime for you
                CurAirTimer = 0;
                isGrounded = false;


                JumpTakeOff();

                StartCoroutine("Jumping");

                curFallSpeed = 0;

            }
        }


        // FakeGravity
        RB.velocity -= new Vector3(0, Time.deltaTime * curFallSpeed, 0); //Placeholder

    }

    // the jump start
    void JumpTakeOff()
    {
        ChangeCollider(JumpingCollider);

        RB.AddForce(Vector3.up * JumpSpeed,ForceMode.Impulse);
    }


    IEnumerator Jumping()
    {
        yield return new WaitForFixedUpdate();

        // checks if the player are moving down and stopping the jump here
        if (RB.velocity.y <= 0)
        {
            curFallSpeed = fallSpeed;

            yield return null;
        }

        // checks if the player have reach their target hight
        if (curJumpHight >= transform.position.y)
        {
            ChangeCollider(JumpingCollider);
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

            ChangeCollider(WalkingCollider);
        }
        
    }
    // DYING
    public void PlayerGotHit()
    {
        CurRespawnTime = RespawnTime;
        transform.position = SpawnPos;
        RB.velocity = new Vector3(0, 0, 0);
        RespawnPlatforms();

        gms.playerDeath();


    }

    // Colliders
    void ChangeCollider(Collider c)
    {
        if (curActivCollider != c)
        {
            curActivCollider.enabled = false;
            curActivCollider = c;
            curActivCollider.enabled = true;
        }

    }

    // falling platforms
    void RespawnPlatforms()
    {
        foreach (AppearingGround a in Blocks)
        {
            a.Appear();
        }
    }
}
