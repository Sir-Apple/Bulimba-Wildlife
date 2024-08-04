using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text curItemTxt;                                 //Display name of currently interactive item
    public Text txtHighestPoints;
    public GameObject collectionBox;
    public GameObject gameResult;

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
        Instance = this;
        helpScreenList = new List<GameObject>();
        helpScreenList.Add(commonTreeSnakePopup);
        helpScreenList.Add(coastalTaipanPopup);
        helpScreenList.Add(sandYabbyPopup);
        helpScreenList.Add(yellowPalmDartPopup);
        helpScreenList.Add(blueSkimmerPopup);
        helpScreenList.Add(regentSkipperPopup);
        helpScreenList.Add(EuropeanGardenSnailPopup);
    }

    public void TouchColBtn()
    {
        collectionBox.SetActive(!collectionBox.activeSelf);
    }

    public void DisplayInteractionInfo(string info)
    {
        curItemTxt.text = info;
    }
    public void CleanInteractionInfo()
    {
        curItemTxt.text = "";
    }

    public void DisplayGameResult()
    {
        InGameMenu.Instance.HideControler();
        gameResult.SetActive(true);
        txtHighestPoints.text = "The Highest Points:  " + PointManager.Instance.GetHighestPoints();
    }

    public void HideGameResult()
    {
        InGameMenu.Instance.OpenControler();
        gameResult.SetActive(false);
    }

    public void clearAnimalPopups()
    {
        Time.timeScale = 1;
        InGameMenu.Instance.OpenControler();
        foreach (GameObject popupWindow in helpScreenList)
        {
            popupWindow.SetActive(false);
        }
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
