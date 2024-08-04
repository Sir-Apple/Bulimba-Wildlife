using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperty : MonoBehaviour
{
    public static PlayerProperty Instance;

    private int curHealth; //current health points
    private int maxHealth; //max health points
    private int curHunger;
    private int maxHunger;
    private int curHydra;
    private int maxHydra;

    public int CurHealth { get => curHealth; set => curHealth = value; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public int CurHunger { get => curHunger; set => curHunger = value; }
    public int MaxHunger { get => maxHunger; set => maxHunger = value; }
    public int CurHydra { get => curHydra; set => curHydra = value; }
    public int MaxHydra { get => maxHydra; set => maxHydra = value; }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {

        maxHealth = 100;
        maxHunger = 100;
        maxHydra = 100;

        curHealth = maxHealth;
        curHunger = maxHunger;
        curHydra = maxHydra;

        StartCoroutine("AliveCheck");
    }

    IEnumerator AliveCheck() 
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            if (CurHealth <= 0)
            {
                //player died
                GameManager.Instance.GameOver();
                break;
            }
        }
    }


}
