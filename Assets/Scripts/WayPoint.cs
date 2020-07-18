using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    Vector2Int gridPos;
    const int gridSize = 10;

    public bool isExplored = false;
    public WayPoint previous; 

    void Start(){
        
    }

    public int getGridSize(){
        return gridSize; 
    }

    public Vector2Int getGridPos(){
        return new Vector2Int( 
        Mathf.RoundToInt(transform.position.x/gridSize),
        Mathf.RoundToInt(transform.position.z/gridSize));
    }

    public  void setColor(Color color){
        MeshRenderer topMeshRend = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRend.material.color = color;

    }
    
    void Update(){
        // if  explored == true){
        //     setColor(Color.blue);
        // }
    }
}
