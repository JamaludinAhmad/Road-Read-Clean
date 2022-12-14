using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Sign : MoveLeft
{
    Sprite sign;
    [SerializeField] private int answer;
    public bool answered;
    public bool terlewati;

    public GameObject arrow;
    public GameObject pelanggar;


    private void Start() {
        answered = false;
    }
    public override void Move()
    {
        base.Move();
        float dst = transform.position.x - Pengendara.Instance.transform.position.x;
        if(dst < -0.5 && !terlewati){
            //belum di answer
            if(!answered){
                //quiz kelewat
                arrow.SetActive(false);
                SignSpawner.Instance.signList.RemoveAt(0);
                if(SignSpawner.Instance.signList.Count >= 1){
                    SignSpawner.Instance.signList.ElementAt(0).SignQuiz();
                }
                Pengendara.Instance.nyawaBerkurang();
                terlewati = true;
            }
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
        int rand = UnityEngine.Random.Range(0, 10);

        if(rand >= 5 && (answer == 1 || answer == 2) && GameManager.Instance.adapelanggar){
            pelanggar.SetActive(true);
        }
        
        QuizManager.Instance.GenerateQuiz(answer);
    }

}
