using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOneTiming : MonoBehaviour
{
    public float SecondsCount;
    public int SecondsPast;
    public int SpawnState;
    public GameObject Crasher, Hoverer, Pather, Boss;
    private Transform Path2Start, Path3Start, HoverStart;
    private Vector3 CrasherStartPos;
    private Transform Path1Start = null;
    // Start is called before the first frame update
    void Start()
    {
        SecondsPast = 1;
        HoverStart = GameObject.Find("HoverStart").transform;
        CrasherStartPos = HoverStart.transform.position;
        //StartCoroutine(SpawnPatherWave(1, 1, 0, 1, 0));
    }

    // Update is called once per frame
    void Update()
    {
        SecondsCount += Time.deltaTime;
        if (SecondsCount >= SecondsPast) { SecondsPast++; SpawnState = SecondsPast; };

        //if you're looking at this Sir, i know you hate switch overuse lol 
        //but just seemed like the most intuitive way to do this. 
        //im sure theres a much better way. 
        switch (SpawnState)
        {
            case 5: Instantiate(Crasher, CrasherStartPos, Quaternion.identity); SpawnState = -1; break;
            case 8: Instantiate(Crasher, CrasherStartPos, Quaternion.identity); SpawnState = -1; break;
            case 11: Instantiate(Crasher, CrasherStartPos, Quaternion.identity); SpawnState = -1; break;
            case 12: Instantiate(Crasher, CrasherStartPos, Quaternion.identity); SpawnState = -1; break;
            case 16: StartCoroutine(SpawnPatherWave(3, 1, 0, 1, 0)); SpawnState = -1; break;
            case 22: StartCoroutine(SpawnPatherWave(4, 2, 0, 1, 0)); SpawnState = -1; break;
            case 28: StartCoroutine(SpawnPatherWave(4, 3, 0, 1, 0)); SpawnState = -1; break;
            case 35: Instantiate(Hoverer, HoverStart); SpawnState = -1; break;
            case 39: Instantiate(Crasher, CrasherStartPos, Quaternion.identity); SpawnState = -1; break;
            case 43: Instantiate(Crasher, CrasherStartPos, Quaternion.identity); SpawnState = -1; break;
            case 45: Instantiate(Crasher, CrasherStartPos, Quaternion.identity); SpawnState = -1; break;
            case 49: Instantiate(Crasher, CrasherStartPos, Quaternion.identity); SpawnState = -1; break;
            case 55: Instantiate(Hoverer, HoverStart); SpawnState = -1; break;
            case 57: Instantiate(Hoverer, HoverStart); SpawnState = -1; break;
            case 60: StartCoroutine(SpawnPatherWave(10, 2, 0, 1, 0)); SpawnState = -1; break;
            case 62: Instantiate(Crasher, CrasherStartPos, Quaternion.identity); SpawnState = -1; break;
            case 65: Instantiate(Crasher, CrasherStartPos, Quaternion.identity); SpawnState = -1; break;
            case 68: Instantiate(Crasher, CrasherStartPos, Quaternion.identity); SpawnState = -1; break;
            case 76: StartCoroutine(SpawnPatherWave(12, 3, 0, 1, 0)); SpawnState = -1; break;
            case 80: Instantiate(Hoverer, HoverStart); SpawnState = -1; break;
            case 81: Instantiate(Hoverer, HoverStart); SpawnState = -1; break;
            case -1: break;
            default:
                break;
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
