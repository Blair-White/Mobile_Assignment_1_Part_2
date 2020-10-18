using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleChase : MonoBehaviour
{
    private GameObject mPlayer;
    private int turnRate;
    public float movespeed;
    private Transform targetTransform;
    private Vector3 lookPos;
    private bool tooclose;
    // Start is called before the first frame update
    void Start()
    {
        mPlayer = GameObject.Find("PlayerCharacter");
        targetTransform = mPlayer.transform;
        turnRate = 2;
        if (movespeed == 0) movespeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!tooclose)
        {
            transform.right = targetTransform.position - transform.position;
            transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, movespeed * Time.deltaTime);
        }
        if (Mathf.Abs(transform.position.y - targetTransform.position.y) < 0.5f)
        {
            tooclose = true;
            this.transform.rotation = Quaternion.Euler(0,0,-90);
        }
        if(tooclose)
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y - movespeed * 4 * Time.deltaTime, transform.position.z);
        }
    }
}
