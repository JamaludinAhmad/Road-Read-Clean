using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Sign : MoveLeft
{
    Sprite sign;
    [SerializeField] private int answer;
    public bool answered;

    public GameObject arrow;


    private void Start() {
        answered = false;
    }
    public override void Move()
    {
        base.Move();
        float dst = transform.position.x - Pengendara.Instance.transform.position.x;
        if(dst < -0.5){
            //belum di answer
            if(!answered){
                //quiz kelewat
                arrow.SetActive(false);
                SignSpawner.Instance.signList.RemoveAt(0);
                if(SignSpawner.Instance.signList.Count >= 1){
                    SignSpawner.Instance.signList.ElementAt(0).SignQuiz();
                }
                Pengendara.Instance.nyawaBerkurang();
            }
            Destroy(gameObject);
        }

        if(transform.position.x - Camera.main.transform.position.x < -10){
            Destroy(gameObject);
        }
    }
    public void setSprite(Sprite sign){
        GetComponent<SpriteRenderer>().sprite = sign;
        this.sign = sign;
    }

    public void SetAnswer(int answer){
        this.answer = answer;
    }

    public void SignQuiz(){
        
        QuizManager.Instance.GenerateQuiz(answer);
    }

}
