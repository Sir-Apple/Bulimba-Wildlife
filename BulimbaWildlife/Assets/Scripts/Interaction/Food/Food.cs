using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Food : MonoBehaviour
{
    //public int health; 
    public int hunger; 
    public int hydration;
    public int points;
    public string foodName;
    public bool destoryAfterPick;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            popUpWindow();
            UIManager.Instance.DisplayInteractionInfo(foodName);
            other.GetComponent<TouchManager>().touchFood = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            
            if (other.GetComponent<TouchManager>().foodPickUpAllowed == true)
            {
                source.Play();

                Bars.Instance.IncHunger(hunger);
                PlayerManager.Instance.IncHunger(hunger);

                Bars.Instance.IncHydration(hydration);
                PlayerManager.Instance.IncHydration(hydration);

                PointManager.Instance.IncPoints(points);

                if (destoryAfterPick == true)
                {
                    UIManager.Instance.CleanInteractionInfo();
                    Destroy(gameObject);
                }
                other.GetComponent<TouchManager>().foodPickUpAllowed = false;
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UIManager.Instance.CleanInteractionInfo();
            other.GetComponent<TouchManager>().touchFood = false;
        }
    }

    
    public void popUpWindow()
    {
        if (foodName == "Sand Yabby")
        {
            GameManager.Instance.sandYabbyInfoPopup();
        }

        if (foodName == "Yellow Palm Dart")
        {
            GameManager.Instance.yellowPalmDartInfoPopup();
        }

        if (foodName == "Blue Skimmer")
        {
            GameManager.Instance.blueSkimmerInfoPopup();
        }

        if (foodName == "Regent Skipper")
        {
            GameManager.Instance.regentSkipperInfoPopup();
        }

        if (foodName == "European Garden Snail")
        {
            GameManager.Instance.europeanGardenSnailInfoPopup();
        }
    }
}
