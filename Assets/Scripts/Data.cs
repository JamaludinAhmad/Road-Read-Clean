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

        
    }

    private void Update() {
        if(Pengendara.Instance.GetJarakTempuh() > highscoreMeter){
            highscoreMeter = Pengendara.Instance.GetJarakTempuh();
            highscoreMeterUI.text = "Highscore "+ highscoreMeter.ToString();
            
            
            PlayerPrefs.SetFloat(highscoremeter,highscoreMeter);
        }

    }

    

}
