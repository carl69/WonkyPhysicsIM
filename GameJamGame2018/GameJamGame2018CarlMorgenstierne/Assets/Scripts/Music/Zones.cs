using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zones : MonoBehaviour {
    public AudioClip Ac;
    public AudioSource parentAudio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            parentAudio.clip = Ac;
            parentAudio.Play();
        }
    }
}
