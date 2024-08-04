using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public AudioSource BGM;
    public Text highScore;//分数
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("AnimalSelection");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
