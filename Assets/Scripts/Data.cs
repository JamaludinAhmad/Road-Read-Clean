using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    public static Data dt;
    private void Awake() {
        dt = this;
    }

    public  float highscoreMeter;
    public Text highscoreMeterUI;
    public string highscoremeter = "HIGHSCOREMETER" ;

    private void Start() {
        highscoreMeter = PlayerPrefs.GetFloat(highscoremeter);
        highscoreMeterUI.text = "Highscore "+ highscoreMeter.ToString();
        Pengendara.Instance.onPengendaraDead += MunculkanHighscore;
        
    }

    public void MunculkanHighscore() {
        if(Pengendara.Instance.GetJarakTempuh() > highscoreMeter){
            highscoreMeter = Pengendara.Instance.GetJarakTempuh();
            highscoreMeterUI.text = "New Highscore "+ (int)highscoreMeter;
            
            
            PlayerPrefs.SetFloat(highscoremeter,highscoreMeter);
        }
        else{
            highscoreMeter = Pengendara.Instance.GetJarakTempuh();
            highscoreMeterUI.text = "Score "+ (int)highscoreMeter;
        
        }

    }

    private void Update() {
            if(Input.GetKeyDown(KeyCode.A)){
            PlayerPrefs.SetFloat(highscoremeter, 0);
            Debug.Log("reseted");
        }
    }



    

}
