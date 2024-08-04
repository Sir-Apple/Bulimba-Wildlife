using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioSource BGM;

    // Animal Popup Windows
    public GameObject commonTreeSnakePopup;
    public GameObject coastalTaipanPopup;
    public GameObject sandYabbyPopup;
    public GameObject yellowPalmDartPopup;
    public GameObject blueSkimmerPopup;
    public GameObject regentSkipperPopup;
    public GameObject EuropeanGardenSnailPopup;

    public int helpScreenNumber;
    public List<GameObject> helpScreenList;

    private void Awake()
    {
        helpScreenList = new List<GameObject>();
        helpScreenList.Add(commonTreeSnakePopup);
        helpScreenList.Add(coastalTaipanPopup);
        helpScreenList.Add(sandYabbyPopup);
        helpScreenList.Add(yellowPalmDartPopup);
        helpScreenList.Add(blueSkimmerPopup);
        helpScreenList.Add(regentSkipperPopup);
        helpScreenList.Add(EuropeanGardenSnailPopup);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Quit()
    {
        Application.Quit();
    }


    public void showHelpScreen()
    {
        GameObject screenToShow = helpScreenList[helpScreenNumber];
        screenToShow.SetActive(true);

        GameObject button = screenToShow.transform.Find("Continue Button").gameObject;
        button.SetActive(false);
        GameObject helpScreenButtons = screenToShow.transform.Find("Help Menu Screen").gameObject;
        helpScreenButtons.SetActive(true);
    }

    public void nextButton()
    {
        GameObject screenToShow = helpScreenList[helpScreenNumber];
        screenToShow.SetActive(false);
        if (helpScreenNumber < helpScreenList.Count - 1)
        {
            helpScreenNumber += 1;
        }
        showHelpScreen();
    }

    public void previousButton()
    {
        GameObject screenToShow = helpScreenList[helpScreenNumber];
        screenToShow.SetActive(false);
        helpScreenNumber -= 1;
        if (helpScreenNumber < 0)
        {
            helpScreenNumber = 0;
        }
        showHelpScreen();
    }

    public void backButton()
    {
        foreach (GameObject popupWindow in helpScreenList)
        {
            popupWindow.SetActive(false);
        }
    }
}
