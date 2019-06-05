using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearingGround : MonoBehaviour
{
    float fadeSpeed;
    bool dissapearing;
    public Renderer rend;
    Animator blockAnimator;
    AudioSource audioS;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
        blockAnimator = GetComponent<Animator>();
    }
    IEnumerator dissapearTimer()
    {
        print(Time.time);
        yield return new WaitForSeconds(1);
        print(Time.time);
        blockAnimator.SetBool("Fall", true);
        //Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player"&&dissapearing==false)
        {
            dissapearing = true;
            //Fetch the Renderer from the GameObject
            //Renderer rend = GetComponent<Renderer>();

            blockAnimator.SetBool("Fall", true);
        }
    }
    public void PlayAudio()
    {
        audioS.Play();

    }
    public void DestroyBlock() {
        gameObject.SetActive(true);
        gameObject.GetComponent<Animator>().Play("Idle", -1, 0f); dissapearing = false; gameObject.SetActive(false); }
}
