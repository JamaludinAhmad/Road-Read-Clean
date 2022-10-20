using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    bool isStarted;
    [SerializeField] float cooldown, cooldownSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null){
            Instance = this;
        }
        cooldownSpeed = 0;
        cooldown = 0;
        isStarted = false;
    }


    private void Update() {
        cooldown += Time.deltaTime;

        if(Pengendara.Instance.IsDead()){
            return;
        }

        if(isStarted){

            
        }
        //buat sistem level pada spawn

        // > 500 meter tanda baru batas tanda jadi 6

        //ubah batas tanda dan spawn
        if(Pengendara.Instance.GetJarakTempuh() > 500){
            SignSpawner.Instance.batastanda = 6;
        }

        if(Pengendara.Instance.GetJarakTempuh() > 350 && cooldown > 3f){
            int rand = UnityEngine.Random.Range(1, 4);
            SignSpawner.Instance.SpawnSign(rand);
            cooldown = 0;
        }

        else if(Pengendara.Instance.GetJarakTempuh() > 150 && cooldown > 3f){
            int rand = UnityEngine.Random.Range(1, 3);
            SignSpawner.Instance.SpawnSign(rand);
            cooldown = 0;
        }
        
        else if(Pengendara.Instance.GetJarakTempuh() > 0 && cooldown > 3f){
            SignSpawner.Instance.SpawnSign(1);
            cooldown = 0;
        }

        //atur random kecepatan pengendara
        cooldownSpeed += Time.deltaTime;
        if(Pengendara.Instance.GetJarakTempuh() > 100 && cooldownSpeed > 4){
            int rand = UnityEngine.Random.Range(1, 10);
            if(rand > 4){
                Pengendara.Instance.kecepatan = 8;
            }

            cooldownSpeed = 0;
        }
        
        //keceptan 9 - 10
        else if(Pengendara.Instance.GetJarakTempuh() > 450 && cooldownSpeed > 4){
            int rand = UnityEngine.Random.Range(1, 10);
            if(rand > 8){
                Pengendara.Instance.kecepatan = 10;
            }
            else if(rand > 4){
                Pengendara.Instance.kecepatan = 9;
            }

            cooldownSpeed = 0;
        }

        //keceptan 11 - 14
        else if(Pengendara.Instance.GetJarakTempuh() > 1000 && cooldownSpeed > 4){
            int rand = UnityEngine.Random.Range(1, 10);
            if(rand > 8){
                Pengendara.Instance.kecepatan = 14;
            }
            else if(rand > 5){
                Pengendara.Instance.kecepatan = 13;
            }
            else if(rand > 2){
                Pengendara.Instance.kecepatan = 12;
            }
            else{
                Pengendara.Instance.kecepatan = 11;
            }

            cooldownSpeed = 0;
        }
    }

    public void buttonReset(){
        Pengendara.Instance.kecepatan = 6;
    }
}
