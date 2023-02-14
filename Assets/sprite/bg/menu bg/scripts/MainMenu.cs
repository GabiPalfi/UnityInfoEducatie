using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject startMenu;
    public GameObject dificultyMenu;
    public GameObject gameModeMenu;
    
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
    public void DificultyMenu(){
        optionMenu.SetActive(false);
        startMenu.SetActive(false);
        dificultyMenu.SetActive(true);
        gameModeMenu.SetActive(false);
    }
    public void EasyDeficulty(){
        Counter.dificulty =1;
    }
    public void MediumDeficulty(){
        Counter.dificulty =2;
    }
    public void HardDeficulty(){
        Counter.dificulty =4;
    }
    public void GameModeMenu(){
        startMenu.SetActive(false);
        gameModeMenu.SetActive(true);
    }
    public void StartRogueLike(){
        SceneManager.LoadScene("Hub");
    }
}
