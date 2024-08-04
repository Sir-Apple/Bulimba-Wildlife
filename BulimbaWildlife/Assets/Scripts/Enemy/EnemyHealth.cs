using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public GameObject Canvas;
    public Slider healthBar;
    // Start is called before the first frame update

    void Awake()
    {

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;



        if (health == 100)
        {
            Canvas.SetActive(false);
        }
        else
        {
            Canvas.SetActive(true);
        }
        
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    public void DecHealth()
    {
        health -= 5;
    }
}
