using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAudioEffect : MonoBehaviour
{
    AudioManager AudioManager;
    float Bass;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Bass = AudioManager.Bass * 5 + 1;
        transform.localScale = new Vector3(Bass, Bass, Bass);

    }
}
