using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] int kecepatan;

    public void Update() {
        if(!Pengendara.Instance.IsDead()){
            Move();
        }
    }

    public virtual void Move(){
        transform.Translate(Vector3.left * kecepatan * Time.deltaTime);
    }

}
