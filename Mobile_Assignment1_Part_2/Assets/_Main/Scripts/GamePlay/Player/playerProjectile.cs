using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class playerProjectile : MonoBehaviour
{
    public float MoveSpeed;
    public int LifeTime;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        if(counter > LifeTime)
        {
            Destroy(this.gameObject);
        }
        Vector3 mPos = this.transform.position;
        this.transform.position = new Vector3(mPos.x, mPos.y + MoveSpeed, mPos.z);
    }
}
