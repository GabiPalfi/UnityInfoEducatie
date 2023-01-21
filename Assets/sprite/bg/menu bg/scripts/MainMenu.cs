using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject startMenu;
    
    public void  PlayGame(){
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame(){
       Application.Quit();
    }
    public void OptionMenu(){
        optionMenu.SetActive(true);
        startMenu.SetActive(false);
    }
    public void StartMenu(){
        optionMenu.SetActive(false);
        startMenu.SetActive(true);
    }
}
