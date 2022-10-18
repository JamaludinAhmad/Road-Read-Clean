using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseUI, inGameUI;

    public void pauseGame(){
        PauseUI.SetActive(true);
        inGameUI.SetActive(false);
        Time.timeScale = 0;


    }
    public void stopPause(){
        inGameUI.SetActive(true);
        PauseUI.SetActive(false);
        Time.timeScale = 1;

    }
    public void backTOMainMenu(){
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

  

}
