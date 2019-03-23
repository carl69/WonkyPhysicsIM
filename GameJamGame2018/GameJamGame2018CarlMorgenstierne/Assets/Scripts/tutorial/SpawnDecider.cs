using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SpawnDecider : MonoBehaviour {
    public GameObject spawner;
    public int whatToStart;

    public AudioMixerSnapshot org;
    public AudioMixerSnapshot lowerd;

    public AudioClip Ac;
    public AudioSource parentAudio;

    private bool hasPlayed = false;
    private void Update()
    {
        if (parentAudio.isPlaying && parentAudio.clip == Ac)
        {
            hasPlayed = true;
        }
        else if(hasPlayed == true)
        {
            org.TransitionTo(.01f);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {

            if (parentAudio.isPlaying == false)
            {
                parentAudio.clip = Ac;
                parentAudio.Play();
                lowerd.TransitionTo(.01f);
            }


            spawner.GetComponent<EnemieObjectSpawner>().Spawns[whatToStart] = true;


        }
    }
}
