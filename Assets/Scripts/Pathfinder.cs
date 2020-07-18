 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    [SerializeField] WayPoint startWayPoint, endWayPoint;
    Queue<WayPoint> queue = new Queue<WayPoint>();
    WayPoint current;
    private List<WayPoint> path = new List<WayPoint>();

    bool isRunning = true;

    Vector2Int[] directions = {
                            Vector2Int.up, 
                            Vector2Int.right, 
                            Vector2Int.down,
                            Vector2Int.left};

    public List<WayPoint> getPath(){
        loadBlocks();
        setColors();
        pathSearch();
        pathCreate();
        return path;
    }

    private void pathCreate(){
        path.Add(endWayPoint);

        WayPoint next = endWayPoint.previous;
        while (next != startWayPoint){
            path.Add(next);
            next = next.previous;
        }
        path.Add(startWayPoint);
        path.Reverse();
    }

    private void pathSearch(){
        queue.Enqueue(startWayPoint);

        //while the queue isnt empty
        while (queue.Count > 0 && isRunning){
            current = queue.Dequeue(); 
            current.isExplored = true;

            //check if at the end
            if (current == endWayPoint){
                isRunning = false;
            }
            //explore all other options 
            else{
                exploreNeighbors();
            }
        }   
    }
    
    private void exploreNeighbors(){
        if (!isRunning){return;}

        foreach (Vector2Int direction in directions){
            Vector2Int neighborCoord = current.getGridPos() + direction;

            //check if in the grid 
            if (grid.ContainsKey(neighborCoord)){
                WayPoint neighbor = grid[neighborCoord];

                //if Waypoint hasnt been explored yet
                if (neighbor.isExplored == false){  //queue.Contains(neighbor) == false
                    queue.Enqueue(neighbor);
                    neighbor.previous = current;
                }
            }
        }
    }

    private void loadBlocks(){
        //find all the waypoints on the grid
        var wayPoints = FindObjectsOfType<WayPoint>();

        //go through each waypoint/block and...
        foreach (WayPoint wayPoint in wayPoints){
            var gridPos = wayPoint.getGridPos();

            //deals with overlapping blocks 
            if (grid.ContainsKey(gridPos)){
                Debug.LogWarning("Overlapping Block" + wayPoint);
            }
            else{
                //adds waypoint to dictionary 
                grid.Add(gridPos, wayPoint);
            }
        }
    }

     private void setColors(){
        startWayPoint.setColor(Color.green);
        endWayPoint.setColor(Color.red);
    }


    void Update()
    { 
        
    }
}
