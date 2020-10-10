using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOneTiming : MonoBehaviour
{
    public float SecondsCount;
    public int SecondsPast;
    public int SpawnState;
    public GameObject Crasher, Hoverer, Pather, Boss;
    private Transform Path1Start, Path2Start, Path3Start, HoverStart;
    
    
    // Start is called before the first frame update
    void Start()
    {
        SecondsPast = 1;
        HoverStart = GameObject.Find("HoverStart").transform;
        //StartCoroutine(SpawnPatherWave(1, 1, 0, 1, 0));
    }

    // Update is called once per frame
    void Update()
    {
        SecondsCount += Time.deltaTime;
        if (SecondsCount >= SecondsPast) SecondsPast++;
        if (SecondsPast == 5 && SpawnState == 0)
        { 
         Instantiate(Hoverer);
            SpawnState++;
        }
           
    }

    IEnumerator SpawnPatherWave(int HowMany, int path, float intervalCount, float interval, int Spawned = 0)
    {
        
        while(Spawned < HowMany)
        {
            intervalCount += Time.deltaTime;
            if (intervalCount > interval)
            {
                GameObject newSpawn = Instantiate(Pather, Path1Start);
                newSpawn.GetComponent<WaypointController>().PathType = WaypointController.PathTypes.Waypoints;
                newSpawn.GetComponent<WaypointController>().PathNumber = path;
                intervalCount = 0;
                Spawned++;
            }


            yield return null;
        }

        yield break;
    }
}
