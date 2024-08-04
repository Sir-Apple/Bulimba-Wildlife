using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bars : MonoBehaviour
{
    public static Bars Instance;

    public Slider HealthBar;
    public Slider HungerBar;
    public Slider HydraBar;

    private AudioSource source;

    private void Awake()
    {
        Instance = this;
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        //Initialisation
        //HealthBar.maxValue = PlayerManager.Instance.GetMaxHealth();
        //HungerBar.maxValue = PlayerManager.Instance.GetMaxHunger();
        //HydraBar.maxValue = PlayerManager.Instance.GetMaxHydration();
        HealthBar.maxValue = 100;
        HungerBar.maxValue = 100;
        HydraBar.maxValue = 200;

        HealthBar.value = HealthBar.maxValue;
        HungerBar.value = HungerBar.maxValue;
        HydraBar.value = HydraBar.maxValue;
    }

    public int GetCurHealth()
    {
        return (int)HealthBar.value;
    }

    public int GetCurHunger()
    {
        return (int)HungerBar.value;
    }

    public int GetCurHydra()
    {
        return (int)HydraBar.value;
    }

    //Increase value of HealthBar
    public void IncHealth(int damage)
    {
        HealthBar.value += damage;

    }

    //Decrease value of HealthBar
    public void DecHealth(int damage)
    {
        source.Play();
        HealthBar.value -= damage;
    }

    //Increase value of HungerBar
    public void IncHunger(int hunger)
    {
        HungerBar.value += hunger;
    }

    //Decrease value of HungerBar
    public void DecHunger(int hunger)
    {
        HungerBar.value -= hunger;

    }

    //Increase value of HydraBar
    public void IncHydration(int hydra)
    {
        HydraBar.value += hydra;
    }

    //Decrease value of HydraBar
    public void DecHydration(int hydra)
    {
        HydraBar.value -= hydra;
    }
}
