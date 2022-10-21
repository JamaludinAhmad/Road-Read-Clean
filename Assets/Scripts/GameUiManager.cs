using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUiManager : MonoBehaviour
{
    GameUiManager(){
    }
    public  GameObject PauseUI, inGameUI, DeathUI;
    public static GameUiManager gameUiman;
    [SerializeField] Sprite[] imageSign;
    [SerializeField] String[] Jawaban;

    [SerializeField] private Text teksDesc;
    [SerializeField] private Image image;
    
    int count;

    private void Awake() {
        if(gameUiman == null)
            gameUiman = this;
        
        count = 0;
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

    
    public void DeskripsiSelanjutnya(){
        imageSign = SignSpawner.Instance.GetSprites();
        Jawaban = SignSpawner.Instance.getJawaban();
        image = image.GetComponent<Image>();

        count++;
        if(count > Jawaban.Length - 1){
            count = 0;
        }
        image.sprite = imageSign[count];
        teksDesc.text = Jawaban[count];
    }

    public void DeskripsiSebelumnya(){
        imageSign = SignSpawner.Instance.GetSprites();
        Jawaban = SignSpawner.Instance.getJawaban();
        image = image.GetComponent<Image>();

        count--;
        if(count < Jawaban.Length - 1){
            count = Jawaban.Length;
        }
        image.sprite = imageSign[count];
        teksDesc.text = Jawaban[count];
    }
  

}
