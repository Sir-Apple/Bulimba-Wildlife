using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Collection : MonoBehaviour
{
    public Text txtNumber;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void PickUp()
    {
        source.Play();
        txtNumber.text = "1/1";
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            PickUp();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

        }
    }

}
