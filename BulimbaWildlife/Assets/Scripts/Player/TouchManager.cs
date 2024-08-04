using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{
    public static TouchManager Instance;

    public bool foodPickUpAllowed = false;                     //Is allowed to pick up or not
    public bool touchFood = false;
    private void Awake()
    {
        Instance = this;
    }

    public void PickUp()
    {
        if (touchFood)
        {
            foodPickUpAllowed = true;
        }
    }

}
