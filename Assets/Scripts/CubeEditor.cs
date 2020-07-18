using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(WayPoint))]
public class CubeEditor : MonoBehaviour{

    TextMesh textMesh;
    WayPoint wayPoint;
    
    void Start(){
       wayPoint = GetComponent<WayPoint>();
    }

    void Update() {
        //grabs the gridsize and position from WayPoint
        int gridSize = wayPoint.getGridSize();
        transform.position = new Vector3(wayPoint.getGridPos().x * gridSize, 0f, wayPoint.getGridPos().y * gridSize);

        updateLabel();
    }

    void updateLabel(){
        int gridSize = wayPoint.getGridSize();
        textMesh = GetComponentInChildren<TextMesh>();
        Vector2Int gridPos = wayPoint.getGridPos();
        string textLabel = gridPos.x + "," + gridPos.y;  
        textMesh.text = textLabel;
        gameObject.name = "Block " + textLabel; 
    }
}
 