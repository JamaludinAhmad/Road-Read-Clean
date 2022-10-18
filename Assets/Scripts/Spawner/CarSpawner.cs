using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject car, anothercare;
    
    private void Start() {
        StartCoroutine(spawnCarRev(10));
    }

    IEnumerator spawnCarRev(int second){
        yield return new WaitForSeconds(second);
        while(!Pengendara.Instance.IsDead()){
            int rand = UnityEngine.Random.Range(5, 10);

            GameObject newCar = Instantiate(car);
            newCar.transform.position = transform.position;
            newCar.SetActive(true);
            if(rand > 8){
                int dst = UnityEngine.Random.Range(1,3);
                if(dst == 2 ){
                    
                    GameObject anotherCar = Instantiate(anothercare);
                    anotherCar.transform.position = new Vector3(transform.position.x, transform.position.y - 0.9f);
                    anotherCar.SetActive(true);
                }
            }
            yield return new WaitForSeconds(rand);

        }

    }
}
