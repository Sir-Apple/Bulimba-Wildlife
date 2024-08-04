using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialPopups : MonoBehaviour
{
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Description;
    public GameObject TutorialWindow;
    public GameObject Snake;
    public GameObject SandYabby;
    public GameObject ContinueButton;
    public GameObject ExitButton;
    public Slider Health;
    public Slider Hunger;
    public float tutorialCount;
    public bool UIbool;
    public bool Eatingbool;
    public bool Healthbool;
    public bool sandYabbybool;
    public bool Endingbool;

    private void Start()
    {
        Introduction();
    }

    public void Update()
    {
        if (tutorialCount == 1)
        {
            Moving();
        }
        else if (tutorialCount == 2)
        {
            StartCoroutine(DelayEating(3));
        }


        if (Hunger.value <= 85)
        {
            if (Eatingbool == false)
            {
                Eatingbool = true;
                Eating();
            }
        }

        if (Health.value <= 50)
        {
            if (Healthbool == false)
            {
                Healthbool = true;
                Flying();
            }
        }

        if (SandYabby == null)
        {
            if (sandYabbybool == false)
            {
                sandYabbybool = true;
                Attacking();
            }
        }
    }

    IEnumerator DelayEating(float time)
    {
        
        yield return new WaitForSeconds(time);
        
        if (UIbool == false)
        {
            UIbool = true;
            UI();
        }
    }

    public void CloseWindow()
    {
        TutorialWindow.SetActive(false);
        InGameMenu.Instance.ContinueGame();
        InGameMenu.Instance.ShowMinimap();
        InGameMenu.Instance.OpenControler();
        tutorialCount++;
    }
    public void Introduction()
    {
        InGameMenu.Instance.PauseGame();
        InGameMenu.Instance.HideMinimap();
        InGameMenu.Instance.HideControler();
        TutorialWindow.SetActive(true);
        Title.text = "Tutorial: Introduction";
        Description.text = "Welcome to Bulimba Wildlife, in this tutorial you will learn the basics of how to play this game. The aim of this game is to explore the enviroment in search of four unique items. Along the way you will discover how the White Ibis interacts with their surroundings.";
    }
    public void Moving()
    {
        InGameMenu.Instance.PauseGame();
        InGameMenu.Instance.HideMinimap();
        InGameMenu.Instance.HideControler();
        TutorialWindow.SetActive(true);
        Title.text = "Tutorial: Moving";
        Description.text = "To begin, use the joystick in the bottom left hand corner to move the White Ibis.";
    }

    public void UI()
    {
        InGameMenu.Instance.PauseGame();
        InGameMenu.Instance.HideMinimap();
        InGameMenu.Instance.HideControler();
        TutorialWindow.SetActive(true);
        Title.text = "Tutorial: UI";
        Description.text = "In the left hand corner you have your health bar, hunger bar and hydration bar. Make sure you keep you hunger and hydration bars are filled to stave off starvation and dehydration.";
    }

    public void Eating()
    {
        InGameMenu.Instance.PauseGame();
        InGameMenu.Instance.HideMinimap();
        InGameMenu.Instance.HideControler();
        TutorialWindow.SetActive(true);
        Title.text = "Tutorial: Eating";
        SandYabby.SetActive(true);
        Description.text = "It looks like your hunger and hydration bars are dropping. To prevent starvation and dehydration, search around your surroundings for a source of food and water and use the consume button in the bottom right corner (there is a creek to the east, maybe you can find what your looking for there).";
    }

    public void Attacking()
    {
        InGameMenu.Instance.PauseGame();
        InGameMenu.Instance.HideMinimap();
        InGameMenu.Instance.HideControler();
        TutorialWindow.SetActive(true);
        Title.text = "Tutorial: Attacking";
        Description.text = "Good work on finding food and water. But I think you have attracted the attention of a dangerous snake. Use the attack button in the right hand side of the screen to fight back.";
        Snake.SetActive(true);
    }

    public void Flying()
    {
        InGameMenu.Instance.PauseGame();
        InGameMenu.Instance.HideMinimap();
        InGameMenu.Instance.HideControler();
        TutorialWindow.SetActive(true);
        Title.text = "Tutorial: Flying";
        Description.text = "It looks like your not going to win this fight. White Ibis's arn't known for their combat abilities but they do have the ability to fly. Use the fly button in the bottom right hand side of the screen to fly away from the snake. Be careful though, you can't fly forever and will eventually have to land.";
        StartCoroutine(EndingTimer(10));
    }

    IEnumerator EndingTimer(float time)
    {
        yield return new WaitForSeconds(time);

        if (Endingbool == false)
        {
            Endingbool = true;
            Ending();
        }
    }

    public void Ending()
    {
        InGameMenu.Instance.PauseGame();
        InGameMenu.Instance.HideMinimap();
        InGameMenu.Instance.HideControler();
        TutorialWindow.SetActive(true);
        ContinueButton.SetActive(false);
        ExitButton.SetActive(true);
        Title.text = "Tutorial: Complete";
        Description.text = "Congratulations you have learnt all the basics of Bulimba Wildlife.";
    }

    public void Exit()
    {
        
        SceneManager.LoadScene("MainMenu");
    }
}
