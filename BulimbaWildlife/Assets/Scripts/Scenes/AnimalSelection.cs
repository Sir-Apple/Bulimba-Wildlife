using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimalSelection : MonoBehaviour
{
    //public void TouchEnterBtn()
    //{
    //    LoadNextScene();
    //}

    public void TouchEnterBtn_Ibis()
    {
        GlobalParameters.currentCharactor = GlobalParameters.Charactors.ibis;
        LoadNextScene();
    }
    public void TouchEnterBtn_Other()
    {
        GlobalParameters.currentCharactor = GlobalParameters.Charactors.other;
        LoadNextScene();
    }

    public void TouchBackBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }


}
