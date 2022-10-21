using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SignSpawner : MonoBehaviour
{
    #region singleton
    public static SignSpawner Instance;
    private void Awake() {
        if(Instance == null){
            Instance = this;
        }
    }
    #endregion
    

    public int batastanda;
    public String[] Jawaban;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Sign signRef;

    public List<Sign> signList = new List<Sign>();


    private void Start() {
        batastanda = 3;
    }

    public String[] getJawaban(){
        return Jawaban;
    }

    public Sprite[] GetSprites(){
        return sprites;
    }

    public void SpawnSign(int jumlah){
        StartCoroutine(spawnSign(jumlah));
    }

    public IEnumerator spawnSign(int jumlah){
        QuizManager.Instance.quizPanel.SetActive(true);
        for(int i = 0; i < jumlah; i++){
            int rand = UnityEngine.Random.Range(0, batastanda - 1);
            Sign newSign = Instantiate(signRef);
            newSign.setSprite(sprites[rand]);
            newSign.SetAnswer(rand);
            signList.Add(newSign);
            if(signList.Count == 1){
                signList.ElementAt(0).SignQuiz();
                signList.ElementAt(0).arrow.SetActive(true);
            }
            newSign.transform.position = this.transform.position;
            // newSign.arrow.transform.position = (Vector2)newSign.transform.position + (Vector2.up);
            newSign.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.8f);
        }
        
    }
}
