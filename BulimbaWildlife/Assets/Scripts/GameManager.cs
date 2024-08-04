using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int hungerRegen;                                 //Hunger regeneration
    public int hydraRegen;                                  //Hydration regeneration
    public int decHungerPerSec;                             //Decrease hunger points per second, when hunger > 0
    public int decHydraPerSec;                              //Decrease hydra points per second, when hydration > 0
    public int starving;                                    //Decrease hunger points per second, when hunger = 0
    public int thirsting;                                   //Decrease hydration points per second, when hunger = 0

    public GameObject commonTreeSnakePopup;
    public bool allowCommonTreeSnakePopup = true;

    public GameObject coastalTaipanPopup;
    public bool allowCoastalTaipanPopup = true;

    public GameObject sandYabbyPopup;
    public bool allowSandYabbyPopup = true;

    public GameObject yellowPalmDartPopup;
    public bool allowYellowPalmDartPopup = true;

    public GameObject blueSkimmerPopup;
    public bool allowBlueSkimmerPopup = true;

    public GameObject regentSkipperPopup;
    public bool allowRegentSkipperPopup = true;

    public GameObject europeanGardenSnailPopup;
    public bool allowEuropeanGardenSnailPopup = true;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        decHungerPerSec = 2;
        decHydraPerSec = 2;
        hungerRegen = 5;
        hydraRegen = 5;
        starving = 10;
        thirsting = 10;

        InvokeRepeating("HealthRegenHunger", 0, 1.0f);
        InvokeRepeating("HealthRegenHydra", 0, 1.0f);
        InvokeRepeating("DecHunger", 0, 1.0f);
        InvokeRepeating("DecHydration", 0, 1.0f);
        InvokeRepeating("Starve", 0, 1.0f);
        InvokeRepeating("Thirst", 0, 1.0f);

        ContinueGame();
    }

    private void HealthRegenHunger()
    {
        if (Bars.Instance.GetCurHunger() != 0)
        {
            PlayerManager.Instance.IncHealth(5);

            Bars.Instance.IncHealth(5);
        }
    }

    private void HealthRegenHydra()
    {
        if (Bars.Instance.GetCurHydra() != 0)
        {
            PlayerManager.Instance.IncHealth(5);

            Bars.Instance.IncHealth(5);
        }
    }
    private void DecHunger()
    {
        PlayerManager.Instance.DecHunger(decHungerPerSec);

        Bars.Instance.DecHunger(decHungerPerSec);
    }

    private void DecHydration()
    {
        PlayerManager.Instance.DecHydration(decHydraPerSec);

        Bars.Instance.DecHydration(decHydraPerSec);
    }

    
    private void Starve()
    {
        if (Bars.Instance.GetCurHunger() == 0)
        {
            PlayerManager.Instance.DecHealth(starving);

            Bars.Instance.DecHealth(starving);
        }
    }
    private void Thirst()
    {
        if (Bars.Instance.GetCurHydra() == 0)
        {
            PlayerManager.Instance.DecHealth(thirsting);

            Bars.Instance.DecHealth(thirsting);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
    }

    public void ReplayGame()
    {
        ContinueGame();
        SceneManager.LoadScene("GameScene");
    }

    public void GameOver()
    {
        PauseGame();
        PointManager.Instance.SetHighestPoints();
        UIManager.Instance.DisplayGameResult();
        PointManager.Instance.SetHighestPoints();
    }

    
    public void commonTreeSnakeInfoPopup()
    {
        if (allowCommonTreeSnakePopup)
        {
            Time.timeScale = 0;
            InGameMenu.Instance.HideControler();
            commonTreeSnakePopup.SetActive(true);
            GameObject button = commonTreeSnakePopup.transform.Find("Continue Button").gameObject;
            button.SetActive(true);
            GameObject helpScreenButtons = commonTreeSnakePopup.transform.Find("Help Menu Screen").gameObject;
            helpScreenButtons.SetActive(false);
            allowCommonTreeSnakePopup = false;
        }
    }
    public void coastalTaipanInfoPopup()
    {
        if (allowCoastalTaipanPopup)
        {
            Time.timeScale = 0;
            InGameMenu.Instance.HideControler();
            coastalTaipanPopup.SetActive(true);
            GameObject button = coastalTaipanPopup.transform.Find("Continue Button").gameObject;
            button.SetActive(true);
            GameObject helpScreenButtons = coastalTaipanPopup.transform.Find("Help Menu Screen").gameObject;
            helpScreenButtons.SetActive(false);
            allowCoastalTaipanPopup = false;
        }
    }

    public void sandYabbyInfoPopup()
    {
        if (allowSandYabbyPopup)
        {
            Time.timeScale = 0;
            InGameMenu.Instance.HideControler();
            sandYabbyPopup.SetActive(true);
            GameObject button = sandYabbyPopup.transform.Find("Continue Button").gameObject;
            button.SetActive(true);
            GameObject helpScreenButtons = sandYabbyPopup.transform.Find("Help Menu Screen").gameObject;
            helpScreenButtons.SetActive(false);
            allowSandYabbyPopup = false;
        }
    }

    public void yellowPalmDartInfoPopup()
    {
        if (allowYellowPalmDartPopup)
        {
            Time.timeScale = 0;
            InGameMenu.Instance.HideControler();
            yellowPalmDartPopup.SetActive(true);
            GameObject button = yellowPalmDartPopup.transform.Find("Continue Button").gameObject;
            button.SetActive(true);
            GameObject helpScreenButtons = yellowPalmDartPopup.transform.Find("Help Menu Screen").gameObject;
            helpScreenButtons.SetActive(false);
            allowYellowPalmDartPopup = false;
        }
    }

    public void blueSkimmerInfoPopup()
    {
        if (allowBlueSkimmerPopup)
        {
            Time.timeScale = 0;
            InGameMenu.Instance.HideControler();
            blueSkimmerPopup.SetActive(true);
            GameObject button = blueSkimmerPopup.transform.Find("Continue Button").gameObject;
            button.SetActive(true);
            GameObject helpScreenButtons = blueSkimmerPopup.transform.Find("Help Menu Screen").gameObject;
            helpScreenButtons.SetActive(false);
            allowBlueSkimmerPopup = false;
        }
    }

    public void regentSkipperInfoPopup()
    {
        if (allowRegentSkipperPopup)
        {
            Time.timeScale = 0;
            InGameMenu.Instance.HideControler();
            regentSkipperPopup.SetActive(true);
            GameObject button = regentSkipperPopup.transform.Find("Continue Button").gameObject;
            button.SetActive(true);
            GameObject helpScreenButtons = regentSkipperPopup.transform.Find("Help Menu Screen").gameObject;
            helpScreenButtons.SetActive(false);
            allowRegentSkipperPopup = false;
        }
    }

    public void europeanGardenSnailInfoPopup()
    {
        if (allowEuropeanGardenSnailPopup)
        {
            Time.timeScale = 0;
            InGameMenu.Instance.HideControler();
            europeanGardenSnailPopup.SetActive(true);
            GameObject button = europeanGardenSnailPopup.transform.Find("Continue Button").gameObject;
            button.SetActive(true);
            GameObject helpScreenButtons = europeanGardenSnailPopup.transform.Find("Help Menu Screen").gameObject;
            helpScreenButtons.SetActive(false);
            allowEuropeanGardenSnailPopup = false;
        }
    }
}
