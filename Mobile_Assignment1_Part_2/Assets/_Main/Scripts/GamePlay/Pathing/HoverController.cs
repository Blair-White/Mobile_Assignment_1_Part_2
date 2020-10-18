using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverController : MonoBehaviour
{
    private GameObject mPlayer, HoverPositionParent, StartPosition;
    private Transform[] HoverPositions;
    private int CurrentHoverTarget, NewHoverTarget;
    private float waitCount, ShootCount, ShootInterval;
    public float TimeBetweenMoves, MoveSpeed;

    public int HP = 25;
    // Start is called before the first frame update
    void Start()
    {
        if (MoveSpeed == 0) MoveSpeed = 3;
        if (TimeBetweenMoves == 0) TimeBetweenMoves = 4;
        HoverPositionParent = GameObject.Find("HoverPositions");
        mPlayer = GameObject.Find("PlayerCharacter");
        StartPosition = GameObject.Find("HoverStart");
        HoverPositions = HoverPositionParent.GetComponentsInChildren<Transform>();
        CurrentHoverTarget = Random.Range(0, HoverPositions.Length);
        this.transform.position = new Vector3(StartPosition.transform.position.x, StartPosition.transform.position.y, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0) DestroyedByPlayer();
        transform.right = mPlayer.transform.position - transform.position;

        if (Vector3.Distance(this.transform.position, HoverPositions[CurrentHoverTarget].position) > 0.2f)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, 
                new Vector3(HoverPositions[CurrentHoverTarget].position.x, HoverPositions[CurrentHoverTarget].position.y, 0), MoveSpeed * Time.deltaTime);
        }

        waitCount += Time.deltaTime;
        if(waitCount > TimeBetweenMoves)
        {
            while(NewHoverTarget == CurrentHoverTarget)
            {
                NewHoverTarget = Random.Range(0, HoverPositions.Length);
                return;
            }
            CurrentHoverTarget = NewHoverTarget;
            waitCount = 0;
        }


    }
    void HitBullet()
    {
        HP -= 1;
    }

    void HitMissile()
    {
        HP -= 10;
    }

    void DestroyedByPlayer()
    {


        Destroy(this.gameObject);
    }
}
