using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int hitPoints;
    public Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Player")
        {
            hitPoints = 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Player")
        {
            healthBar.value = hitPoints;
        }
        if (hitPoints <= 0) { Die(); }
    }
    public void Die()
    {
        print(gameObject.name+ " died");
    }
}
