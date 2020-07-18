using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    void Start(){
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.getPath();
        StartCoroutine(followPath(path));
    }

    IEnumerator followPath(List<WayPoint> path)
    {
        foreach (WayPoint wayPoint in path){
            transform.position = wayPoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }

    void Update()
    {
        
    }
}
