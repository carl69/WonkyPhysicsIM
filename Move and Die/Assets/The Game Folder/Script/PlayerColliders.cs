using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliders : MonoBehaviour
{
    public Collider Walking,Sliding,Jumping;


    public void WalkingVoid()
    {
        Walking.enabled = true;
        Sliding.enabled = false;
        Jumping.enabled = false;
    }
    public void SlidingVoid()
    {
        Sliding.enabled = true;
        Walking.enabled = false;
        Jumping.enabled = false;

    }
    public void JumpingVoid()
    {
        Jumping.enabled = true;
        Sliding.enabled = false;
        Walking.enabled = false;
    }
}
