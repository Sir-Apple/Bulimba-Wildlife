using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public static InGameMenu Instance;

    public GameObject Menu;
    public GameObject JoyStick;
    public GameObject ControlBtns;
    public GameObject Minimap;

    private void Awake()
    {
        Instance = this;
    }
    public void TouchMenuBtn()
    {
        OpenMenu();
        HideControler(); //Hide buttons and joystick
        HideMinimap();
        GameManager.Instance.PauseGame();
    }

    public void TouchContinueBtn()
    {
        HideMenu();
        OpenControler();
        ShowMinimap();
        GameManager.Instance.ContinueGame();
    }

    public void TouchReplayBtn()
    {
        HideMenu();
        OpenControler();
        ShowMinimap();
        GameManager.Instance.ReplayGame();
    }

    public void TouchBackBtn()
    {
        OpenControler();
        ShowMinimap();
        SceneManager.LoadScene("MainMenu");
    }

    public void TouchQuitBtn()
    {
        Application.Quit();
    }

    private void OpenMenu()
    {
        Menu.SetActive(true);
    }
    private void HideMenu()
    {
        Menu.SetActive(false);
    }

    public void OpenControler()
    {
        JoyStick.SetActive(true);
        ControlBtns.SetActive(true);
    }

    public void HideControler()
    {
        JoyStick.SetActive(false);
        ControlBtns.SetActive(false); 
    }

    public void ShowMinimap()
    {
        Minimap.SetActive(true);
    }

    public void HideMinimap()
    {
        Minimap.SetActive(false);
    }

    public void helpButton()
    {
        UIManager.Instance.showHelpScreen();
    }

    //the three functions should be moved to GameManager later
    public void PauseGame()
    {
        Time.timeScale = 0;
        
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        
    }
    private void ReplayGame()
    {
        ContinueGame();
        SceneManager.LoadScene("GameScene");
    }
}
