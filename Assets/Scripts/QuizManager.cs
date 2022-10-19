using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    #region singelton
    public static QuizManager Instance;

    private void Awake() {
        if(Instance == null){
            Instance = this;
        }
    }
    #endregion

    [SerializeField] public String[] jawaban; 

    public Text buttonUpUI, buttonDownUI;
    public GameObject quizPanel;
    public bool[] idxanswer;
    private void Start() {
        idxanswer = new bool[2];
    }

    private void Update() {
        if(SignSpawner.Instance.signList.Count > 0){
            quizPanel.SetActive(true);
        }
        else{
            quizPanel.SetActive(false);
        }
    }
    public void GenerateQuiz(int jawabanbenar){
        jawaban = SignSpawner.Instance.getJawaban();
        int rand = UnityEngine.Random.Range(0,2);
        //jika rand satu maka jawaban benar ada di button kanan
        if(rand == 1){
            idxanswer[1] = true;
            idxanswer[0] = false;
            buttonDownUI.text = jawaban[jawabanbenar];

            //button kiri
            int randquiz = UnityEngine.Random.Range(0, jawaban.Length);
            while(randquiz == jawabanbenar){
                randquiz = UnityEngine.Random.Range(0, jawaban.Length);
            }
            buttonUpUI.text = jawaban[randquiz];
        }

        //jawaban benar di kiri
        else if(rand == 0){
            idxanswer[1] = false;
            idxanswer[0] = true;
            buttonUpUI.text = jawaban[jawabanbenar];

            //button kanan
            int randquiz = UnityEngine.Random.Range(0, jawaban.Length);
            while(randquiz == jawabanbenar){
                randquiz = UnityEngine.Random.Range(0, jawaban.Length);
            }
            buttonDownUI.text = jawaban[randquiz];
        }


    }
    public void buttonClick(int idx){
        SignSpawner.Instance.signList.ElementAt(0).answered = true;
        SignSpawner.Instance.signList.ElementAt(0).arrow.SetActive(false);
        SignSpawner.Instance.signList.RemoveAt(0);
        if(idxanswer[idx] == true){
            Debug.Log("Jawaban anda benar");
            if(SignSpawner.Instance.signList.Count >= 1){
                SignSpawner.Instance.signList.ElementAt(0).SignQuiz();
                SignSpawner.Instance.signList.ElementAt(0).arrow.SetActive(true);
            }

        }

        else{
            Debug.Log("Jawaban anda salah");
            if(SignSpawner.Instance.signList.Count >= 1){
                SignSpawner.Instance.signList.ElementAt(0).SignQuiz();
                SignSpawner.Instance.signList.ElementAt(0).arrow.SetActive(true);
            }
            
            Pengendara.Instance.nyawaBerkurang();
        }
    }

    
}
