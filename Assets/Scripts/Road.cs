using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MoveLeft
{
    [SerializeField] private Transform nextPos;
    public void SetNextPos(Road road){
        road.transform.position = nextPos.position;
    }

}
