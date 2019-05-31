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
    bool jumped = false;

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
    bool walking = false;

    // Animations
    [Header("Animation Settings")]
    public Animator anim;

    // Death
    [Header("Death settings")]
    public Vector3 SpawnPos;
    public bool died = false;

    // RESPAWN
    float RespawnTime = 1f;
    float CurRespawnTime = 0;

    // Crouch
    [Header("SliderSettings")]
    public Collider SlidingCollider;
    //bool crouch = false;

    public GameObject SlidingPartical;
    GameObject curSlidingPartical;

    // Air Drop
    [Header("Air Drop")]
    public float LengthOfDrop = 2;

    // DASH
    [Header("Dash")]
    public bool PlayerDashUnlock = true;
    public int DashCount = 1;
    int curDashCount = 1;
    float LengthOfDash = 5;

    // Falling blocks
    [Header("BlockSettings")]
    public List<AppearingGround> Blocks;

    // Dir
    [Header("Direction")]
    public GameObject Body;
    Transform BodyTransform;
    float PlayerDir = 1;

    // Sounds
    [Header("SFX")]
    public AudioClip JumpingSfx;
    public AudioClip DoubleJumpSfx;
    public AudioClip WalkingSfx;
    public AudioClip DashSfx;

    // Effects
    [Header("Effects")]
    public GameObject SlidingEffect;

    //Refrences
    AudioSource audioS;
    Rigidbody RB;
    Collider curActivCollider;
    GameManagerScript gms;

    // Start is called before the first frame update
    void Start()
    {
        SlidingEffect.SetActive(false);
        audioS = GetComponent<AudioSource>();
        gms = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();
        SpawnPos = transform.position;
        RB = GetComponent<Rigidbody>();
        curFallSpeed = fallSpeed;// set the fall speed on the start incase the player starts in the air
        curActivCollider = WalkingCollider;// set the activ collider
        BodyTransform = Body.transform;
    }

    private void FixedUpdate()
    {
        // DIRection
        if (Input.GetAxisRaw("Horizontal") != 0 && PlayerDir != Input.GetAxisRaw("Horizontal"))
        {
            PlayerDir = Input.GetAxisRaw("Horizontal");
            anim.SetFloat("PlayerDir", PlayerDir);
            BodyTransform.localEulerAngles = new Vector3(0, 90 * PlayerDir,0);
            walking = true;
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            walking = false;
        }

        if (walking && ! audioS.isPlaying)
        {
            audioS.PlayOneShot(WalkingSfx);
        }

        //Walking
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        if (inputHorizontal != 0 && CurRespawnTime <= 0)
        {
            
            Vector3 rayStartPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

            RaycastHit hit;
            if (Physics.Raycast(rayStartPos, transform.TransformDirection(Vector3.right * inputHorizontal), out hit, 0.6f, JumpableLayers))
            {
                Debug.DrawRay(rayStartPos, transform.TransformDirection(Vector3.right * inputHorizontal), Color.yellow); // shows Debug
            }
            else
            {

                anim.SetFloat("WalkSpeed", inputHorizontal);
                transform.position += Vector3.right * WalkingSpeed * inputHorizontal;// * Time.deltaTime;


                if (Input.GetButtonDown("crouch"))
                {
                    anim.SetTrigger("Slide");
                }
                if (Input.GetButton("crouch"))
                {
                    ChangeCollider(SlidingCollider);
                    SlidingEffect.SetActive(true);
                }
                else if (isGrounded)
                {
                    ChangeCollider(WalkingCollider);
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

            //Set Dash
            curDashCount = DashCount;

            // LANDED
            if (landed == false)
            {
                jumped = false;
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

        ////////////////////////////////////////////////////////////////////// Creates animation errors
        //if (isGrounded)
        //{
        //    if (inputHorizontal == 0)
        //    {
        //        // Crouch
        //        if (Input.GetButton("crouch") && CurRespawnTime <= 0)
        //        {
        //            crouch = true;
        //            anim.SetBool("Crouch", true);
        //        }
        //        else
        //        {
        //            crouch = false;
        //            anim.SetBool("Crouch", false);
        //        }
        //        if (!crouch)
        //        {
        //            ChangeCollider(WalkingCollider);
        //        }
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        // DASH
        if (Input.GetButtonDown("Dash") && curDashCount >= 1 && PlayerDashUnlock && CurRespawnTime <= 0)
        {
            // COUNTING DOWN
            curDashCount -= 1;
            // DASHING
            anim.SetTrigger("Dash");
            audioS.PlayOneShot(DashSfx);

            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x + LengthOfDash * PlayerDir, pos.y, 0);
        }

        //// STARTS WALKING
        //if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        //{
        //    CurRespawnTime = 0;
        //}

        // teleport down
        if (Input.GetButtonDown("crouch") && CurRespawnTime <= 0)
        {
            RaycastHit hitGround;
            Vector3 RayStartPos = new Vector3(transform.position.x,
                transform.position.y + 1f,
                transform.position.z);

            curJumpHight = 0; // STOPS THE JUMP
            ChangeCollider(SlidingCollider); // change colliders

            if (Physics.Raycast(RayStartPos, transform.TransformDirection(Vector3.down), out hitGround, LengthOfDrop +2f, JumpableLayers))
            {
                RB.velocity = new Vector3(RB.velocity.x, 0, 0);
                transform.position = hitGround.point + new Vector3(0, 0, 0);
            }
            else
            {
                transform.position += Vector3.down * LengthOfDrop;
            }
        }

        // STOP JUMPING
        if (Input.GetButtonUp("Jump"))
        {
            curJumpHight = curJumpHight / 2;
        }

        //JUMPING 
        if (Input.GetButtonDown("Jump") && CurRespawnTime <= 0)
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
                else if (!isGrounded || jumped)// Remove the jumps
                {
                    jumps -= 1;
                }

                //setting maxHight
                if (!jumped)// normal jump
                {
                    curJumpHight = JumpHight + transform.position.y;
                    anim.SetTrigger("Jumping");
                    audioS.PlayOneShot(JumpingSfx);

                }
                else // double jump
                {
                    curJumpHight = JumpHight/2 + transform.position.y;
                    anim.SetTrigger("DoubleJump");
                    audioS.PlayOneShot(DoubleJumpSfx);

                }

                jumped = true;
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
        if (died == false)
        {
            died = true;
            CurRespawnTime = RespawnTime;
            RB.velocity = new Vector3(0, 0, 0);

            gms.playerDeath();
            ChangeCollider(WalkingCollider);
            StartCoroutine("PlayerDyingWaiting");
        }       
    }

    IEnumerator PlayerDyingWaiting()
    {
        anim.SetTrigger("Death");
        StopCoroutine("Jumping");
        yield return new WaitForSeconds(0.3f);
        anim.SetTrigger("Respawn");
        ChangeCollider(WalkingCollider);
        transform.position = SpawnPos;
        RespawnPlatforms();

        died = false;

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
