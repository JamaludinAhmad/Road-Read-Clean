using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUiManager : MonoBehaviour
{
    GameUiManager(){
    }
    public  GameObject PauseUI, inGameUI, DeathUI;
    public static GameUiManager gameUiman;

    private void Awake() {
        gameUiman = this;
    }



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
    public void DeathUImuncul(){
        
        DeathUI.SetActive(true);
        inGameUI.SetActive(false);
        PauseUI.SetActive(false);
    }

    public void mainLagi(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

    }

  

}
