using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUiManager : MonoBehaviour
{

    public  GameObject PauseUI, inGameUI, DeathUI, panduanUI;
    public static GameUiManager gameUiman;
    
    [SerializeField] Sprite[] imageSign;
    [SerializeField] String[] Jawaban;


    [SerializeField] private Text teksDesc;
    [SerializeField] private Image image;

    bool clickpanduan;
    
    int count;

    private void Awake() {
        if(gameUiman == null)
            gameUiman = this;
        
        count = 0;
        clickpanduan = false;
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
        if(count < 0){
            count = Jawaban.Length - 1;
        }
        image.sprite = imageSign[count];
        teksDesc.text = Jawaban[count];
    }

    public void clickPanduan(){
        //jika belum click panduan
        if(!clickpanduan){
            panduanUI.SetActive(true);
            clickpanduan = true;
            Time.timeScale = 0;
        }

        else if(clickpanduan){
            panduanUI.SetActive(false);
            clickpanduan = false;
            Time.timeScale = 1;
        }
    }
  

}
