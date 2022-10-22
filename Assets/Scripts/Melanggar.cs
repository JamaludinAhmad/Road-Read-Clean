using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melanggar : MonoBehaviour
{
    
    float dst;

    private void Start() {
        
    }
    private void Update() {
        //djarak
        float dst = transform.position.x - Pengendara.Instance.transform.position.x;

        if(dst <= -1){
            Pengendara.Instance.nyawaBerkurang();
            Destroy(gameObject);
        }        
    }
    private void OnMouseEnter() {
        //jika mobil mendekati pengendara maka bisa di click dan menghasilkan terima kasih
        if(dst <= 3 && dst > -1){
            //munculkan "terima kasih sudah mengingatkan"
            Debug.Log("Terima kasih sudah mengingatkan");
        }

   }
}
