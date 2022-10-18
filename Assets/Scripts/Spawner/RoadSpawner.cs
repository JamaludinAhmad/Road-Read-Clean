using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] private Transform env;
    public Road prevRoad, roadRef;

    void Spawn(){
        Road newroad = Instantiate(roadRef);
        newroad.gameObject.SetActive(true);
        prevRoad.SetNextPos(newroad);
        newroad.transform.SetParent(env);
    }
    private void OnTriggerExit2D(Collider2D other) {
        Road road = other.GetComponent<Road>();

        if(road){
            prevRoad = road;

            Spawn();
        }
    }
}
