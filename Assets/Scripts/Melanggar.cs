using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melanggar : MonoBehaviour
{
    
    float dst;
    bool sudahdiingatkan;

    public GameObject terimakasihUI;

    private void Start() {
        sudahdiingatkan = false;   
    }
    private void Update() {
        //djarak
        float dst = transform.position.x - Pengendara.Instance.transform.position.x;

        if(dst <= -1){
            if(!sudahdiingatkan){
                Pengendara.Instance.nyawaBerkurang();
            }
            
        }        
    }
    private void OnMouseEnter() {
        //jika mobil mendekati pengendara maka bisa di click dan menghasilkan terima kasih
        if(dst <= 3 && dst > -2){
            //munculkan "terima kasih sudah mengingatkan"
            Debug.Log("Terima kasih sudah mengingatkan");
            terimakasihUI.SetActive(true);
            sudahdiingatkan = true;
        }

   }
}
