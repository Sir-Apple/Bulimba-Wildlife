using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PointManager : MonoBehaviour
{
    public static PointManager Instance;
    public Text txtPoints;

    private int points = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        points = 0;
        DisplayPoints();
    }
    public int GetCurPoints()
    {
        return points;
    }

    public void IncPoints(int p)
    {
        points += p;
        DisplayPoints();
    }

    public void DecPoints(int p)
    {
        points -= p;
        DisplayPoints();
    }

    public int GetHighestPoints()
    {
        return PlayerPrefs.GetInt("TheHighestPoints", 0);
    }

    public void SetHighestPoints()
    {
        if (points > GetHighestPoints())
        {
            PlayerPrefs.SetInt("TheHighestPoints", points);
        } 
    }

    private void DisplayPoints()
    {
        txtPoints.text = "Score: " + points;
    }


}
