using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingFireSprite : MonoBehaviour {
	public Sprite[] Fires;
	public float TotalTime = 1;
	float Timer;
	SpriteRenderer sp;
    int times = 0;

	void Start(){
		sp = GetComponent<SpriteRenderer> ();
	}



	void LateUpdate () {
        if (Input.GetKey(KeyCode.Space))
        {
            StartTimer();
        }
        else if (sp.sprite != null)
        {
            IdleFire();
        }
	}


    void IdleFire()
    {
        sp.sprite = null;
    }


    void StartTimer()
    {
        if (Timer > TotalTime)
        {
            Timer = 0;

            ChangeImage();

        }
        else
        {
            Timer += Time.deltaTime;
        }
    }

    void ChangeImage()
    {
        if (times == Fires.Length - 1)
        {
            times = 0;
        }
        else
        {
            times++;
        }
        sp.sprite = Fires[times];
    }
}
