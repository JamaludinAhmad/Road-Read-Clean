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
            if(!answered){
                //quiz kelewat
                SignSpawner.Instance.signList.RemoveAt(0);
                if(SignSpawner.Instance.signList.Count >= 1){
                    SignSpawner.Instance.signList.ElementAt(0).SignQuiz();
                    arrow.SetActive(false);
                }

                Pengendara.Instance.nyawaBerkurang();
            }
            //generate another quiz
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
