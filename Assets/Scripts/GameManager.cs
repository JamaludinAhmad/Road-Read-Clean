using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] float cooldown, cooldownSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null){
            Instance = this;
        }
        cooldownSpeed = 0;
        cooldown = 0;
    }


    private void Update() {
        cooldown += Time.deltaTime;

        //buat sistem level pada spawn
        //0 - 100 meter 1 spawn dan kecepatan 8
        //0 - 250 meter 2 spawn dan kecepatan 9
        //0 - 350 meter 3 spawn dan kecepatan 13

        // > 500 meter tanda baru batas tanda jadi 6

        //ubah batas tanda dan spawn
        if(Pengendara.Instance.GetJarakTempuh() > 500){
            SignSpawner.Instance.batastanda = 6;
        }

        if(Pengendara.Instance.GetJarakTempuh() > 350 && cooldown > 3f){
            SignSpawner.Instance.SpawnSign(3);
            cooldown = 0;
        }

        else if(Pengendara.Instance.GetJarakTempuh() > 150 && cooldown > 3f){
            SignSpawner.Instance.SpawnSign(2);
            cooldown = 0;
        }
        
        else if(Pengendara.Instance.GetJarakTempuh() > 0 && cooldown > 3f){
            SignSpawner.Instance.SpawnSign(1);
            cooldown = 0;
        }

        //atur random kecepatan pengendara
        cooldownSpeed += Time.deltaTime;
        if(Pengendara.Instance.GetJarakTempuh() > 50 && cooldownSpeed > 4){
            int rand = UnityEngine.Random.Range(1, 10);
            if(rand > 4){
                Pengendara.Instance.kecepatan = 8;
            }

            cooldownSpeed = 0;
        }
        
        //keceptan 9 - 10
        else if(Pengendara.Instance.GetJarakTempuh() > 250 && cooldownSpeed > 4){
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
        else if(Pengendara.Instance.GetJarakTempuh() > 500 && cooldownSpeed > 4){
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
