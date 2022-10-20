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
        if(Pengendara.Instance.GetJarakTempuh() > highscoreMeter && Pengendara.Instance.IsDead()){
            highscoreMeter = Pengendara.Instance.GetJarakTempuh();
            highscoreMeterUI.text = "New Highscore "+ (int)highscoreMeter;
            
            
            PlayerPrefs.SetFloat(highscoremeter,highscoreMeter);
        }
        else{
            highscoreMeterUI.text = "Score "+ (int)Pengendara.Instance.GetJarakTempuh();
        }

        if(Input.GetKeyDown(KeyCode.A)){
            PlayerPrefs.SetFloat(highscoremeter, 0);
            Debug.Log("reseted");
        }

    }



    

}
