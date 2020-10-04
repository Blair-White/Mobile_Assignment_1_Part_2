using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundDrift : MonoBehaviour
{
    private Vector3 mPos, startPos;
    public float rate, xBound, yBound;
    private bool rightLeft;
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        mPos = this.transform.localPosition;
        if(rightLeft)
        {
            if(mPos.x < startPos.x + xBound)
                this.transform.localPosition = new Vector3(mPos.x+rate,mPos.y+rate,0);
            else
            {
                rightLeft = false;
            }
        }

        if(!rightLeft)
        {
           if (mPos.x > startPos.x - xBound)
                this.transform.localPosition = new Vector3(mPos.x - rate, mPos.y - rate, 0);
            else
            {
                rightLeft = true;
            }

        }

    }
}
