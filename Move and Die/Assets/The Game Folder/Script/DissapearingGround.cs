using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearingGround : MonoBehaviour
{
    float fadeSpeed;
    bool dissapearing;
    public Renderer rend;
    Animator blockAnimator;
    private void Start()
    {
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

            //Set the main Color of the Material to green
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", Color.green);

            StartCoroutine(dissapearTimer());
        }
    }
    public void DestroyBlock() { gameObject.SetActive(false); }
}
