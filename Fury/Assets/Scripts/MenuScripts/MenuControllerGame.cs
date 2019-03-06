using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControllerGame : MonoBehaviour
{


    public void ExitTheGame()
    {
        Application.Quit();
    }
    public void PlayMen()
    {
        SceneManager.LoadScene("PlayMenu");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        
    }
    public void Play()
    {
        SceneManager.LoadScene("TestLevel");
    }

   
}
