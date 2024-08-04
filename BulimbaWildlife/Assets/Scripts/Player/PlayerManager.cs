using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public int GetCurHealth()
    {
        return PlayerProperty.Instance.CurHealth;
    }

    public int GetCurHunger()
    {
        return PlayerProperty.Instance.CurHunger;
    }

    public int GetCurHydration()
    {
        return PlayerProperty.Instance.CurHydra;
    }

    public int GetMaxHealth()
    {
        return PlayerProperty.Instance.MaxHealth;
    }

    public int GetMaxHunger()
    {
        return PlayerProperty.Instance.MaxHunger;
    }

    public int GetMaxHydration()
    {
        return PlayerProperty.Instance.MaxHydra;
    }

    //Increase HP
    public void IncHealth(int hp)
    {
        int temp = PlayerProperty.Instance.CurHealth + hp;
        if (temp > GetMaxHealth())
        {
            PlayerProperty.Instance.CurHealth = GetMaxHealth();
        }
        else
        {
            PlayerProperty.Instance.CurHealth = temp;
        }
    }

    //Increase Hunger
    public void IncHunger(int hunger)
    {
        int temp = PlayerProperty.Instance.CurHunger + hunger;
        if (temp > GetMaxHunger())
        {
            PlayerProperty.Instance.CurHunger = GetMaxHunger();
        }
        else
        {
            PlayerProperty.Instance.CurHunger = temp;
        }
    }

    //Increase Hydration
    public void IncHydration(int hydra)
    {
        int temp = PlayerProperty.Instance.CurHydra + hydra;
        if (temp > GetMaxHydration())
        {
            PlayerProperty.Instance.CurHydra = GetMaxHydration();
        }
        else
        {
            PlayerProperty.Instance.CurHydra = temp;
        }
    }

    //Decrease HP
    public void DecHealth(int hp)
    {
        int temp = PlayerProperty.Instance.CurHealth - hp;
        if (temp < 0)
        {
            PlayerProperty.Instance.CurHealth = 0;
        }
        else
        {
            PlayerProperty.Instance.CurHealth = temp;
        }
    }

    //Decrease Hunger
    public void DecHunger(int hunger)
    {
        int temp = PlayerProperty.Instance.CurHunger - hunger;
        if (temp < 0)
        {
            PlayerProperty.Instance.CurHunger = 0;
        }
        else
        {
            PlayerProperty.Instance.CurHunger = temp;
        }
    }

    //Decrease Hydration
    public void DecHydration(int hydra)
    {
        int temp = PlayerProperty.Instance.CurHydra - hydra;
        if (temp > 0)
        {
            PlayerProperty.Instance.CurHydra = 0;
        }
        else
        {
            PlayerProperty.Instance.CurHydra = temp;
        }
    }
}
