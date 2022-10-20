using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PlayerLoop;
using System;


public class Pengendara : MonoBehaviour
{
    #region singleton
    public static Pengendara Instance;

    private void Awake() {
        if(Instance == null){
            Instance = this;
        }
    }

    #endregion
    
    [SerializeField] private bool isDead;
    [SerializeField] private int nyawa;
    [SerializeField] private float jarakTempuh;
    [SerializeField] private GameObject[] HealthUI;

    [SerializeField] Text jarakUI;
    private float startpos;

    public int kecepatan;

    private void Start() {
        nyawa = 3;
        isDead = false;
        jarakTempuh = 0;
        kecepatan = 7;
        startpos = this.transform.position.x;
    }

    private void FixedUpdate() {
        if(!isDead){
            Ngegas();
        }

        if(Camera.main.transform.position.x - transform.position.x <= -9f){
            Dead();
        }

        if(transform.position.x < startpos){
            kecepatan = 7;
        }
    }

    void Ngegas(){
        transform.Translate(Vector2.right * (kecepatan - 7) * Time.deltaTime);
        jarakTempuh += kecepatan * Time.deltaTime;
        jarakUI.text = String.Format("{0:00}", jarakTempuh) + " m";
    }

    public bool IsDead(){
        return isDead;
    }

    public void nyawaBerkurang(){
        Debug.Log("nyawa berkurang");
        HealthUI[nyawa -1].SetActive(false);
        nyawa--;
        if(nyawa <= 0){
            Dead();
        }
    }

    void Dead(){
        isDead = true;
        nyawa = 0;
        Time.timeScale = 0;
        //lakukan munculkan UI
        GameUiManager.gameUiman.DeathUImuncul();
        
        
        
    }

    public float GetJarakTempuh(){
        return jarakTempuh;
    }


}
