using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public enum PathTypes { Hovering, Waypoints};
    public PathTypes PathType;
    public int PathNumber, PathState;
    public float MoveSpeed;
    private GameObject PathParent1, PathParent2, PathParent3, PathStart1,PathStart2,PathStart3;
    public Transform[] Path_1_Transforms, Path_2_Transforms, Path_3_Transforms, HoverTransforms;
    
    // Start is called before the first frame update
    void Start()
    { 
        if(MoveSpeed == 0) { MoveSpeed = 2.0f; }
        //If Time Refactor all of this. 
        if(PathNumber == 1)
        {
            PathParent1 = GameObject.Find("Path_1");
            PathStart1 = GameObject.Find("Path1Start");
            Path_1_Transforms = PathParent1.GetComponentsInChildren<Transform>();
            this.transform.position = new Vector3(PathStart1.transform.position.x, PathStart1.transform.position.y, PathStart1.transform.position.z);
        }
       
        if(PathNumber == 2)
        {
            PathParent2 = GameObject.Find("Path_2");
            PathStart2 = GameObject.Find("Path2Start");
            Path_2_Transforms = PathParent2.GetComponentsInChildren<Transform>();
            this.transform.position = new Vector3(PathStart2.transform.position.x, PathStart2.transform.position.y, PathStart2.transform.position.z);
        }
       
        if(PathNumber == 3)
        {
            PathParent3 = GameObject.Find("Path_3");
            PathStart3 = GameObject.Find("Path3Start");
            Path_3_Transforms = PathParent3.GetComponentsInChildren<Transform>();
            this.transform.position = new Vector3(PathStart3.transform.position.x, PathStart3.transform.position.y, PathStart3.transform.position.z);
        }       
    }

    // Update is called once per frame
    void Update()
    {
      //If Time Refactor
      if(PathNumber == 1) { MoveMe(1, Path_1_Transforms); }
      if(PathNumber == 2) { MoveMe(2, Path_2_Transforms); }
      if(PathNumber == 3) { MoveMe(3, Path_3_Transforms); }
    }

    void MoveMe(int path, Transform[] waypoints)
    {
        if (PathState >= waypoints.Length) { Destroy(this.gameObject); return; }
        if(Vector3.Distance(waypoints[PathState].position, this.transform.position) > 0.2f)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, waypoints[PathState].transform.position, MoveSpeed * Time.deltaTime);
            transform.right = waypoints[PathState].position - transform.position;
        }
        else
        {
            PathState++;
        }
    }
}
