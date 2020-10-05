using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mPlayerMouse : MonoBehaviour
{
    private bool init;
    private GameObject startPos;
    private float xx, yy, zz, timerA;
    public float xMove, mSpeed;
    private Vector3 mousePos;

    private void Awake()
    {
        startPos = GameObject.Find("StartPosition");
    }
    // Start is called before the first frame update
    void Start()
    {
        xMove = xx;
        mousePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        xx = transform.position.x; yy = transform.position.y; zz = transform.position.z;
        if(!init)
        {
            timerA++;
            if (timerA > 33)
            { 
            if (transform.position.y < startPos.transform.position.y)
                transform.position = new Vector3(xx, yy + 0.1f, zz);
            else { init = true; timerA = 0; }
            }    
        }

        if(init)
        {

            if (Input.GetMouseButton(0))
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            float step = mSpeed * Time.deltaTime;
            Vector3 targetpos = new Vector3(mousePos.x, yy, zz); xMove = targetpos.x;
            if (Vector3.Distance(transform.position, mousePos) > 0.000001f)
            {
                transform.position = Vector2.Lerp(transform.position, targetpos, step);
            }
                
                





        }

    }
}
