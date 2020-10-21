using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mPlayerMouse : MonoBehaviour
{
    private bool init, bossComplete;
    public GameObject startPos, EndGameObject, FadePanel;
    private float xx, yy, zz, timerA,EndTimer;
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
        if(!bossComplete)
        {
            xx = transform.position.x; yy = transform.position.y; zz = transform.position.z;
            if (!init)
            {
                timerA++;
                if (timerA > 33)
                {
                    if (transform.position.y < startPos.transform.position.y)
                        transform.position = new Vector3(xx, yy + 0.1f, zz);
                    else { init = true; timerA = 0; }
                }
            }

            if (init)
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

        if(bossComplete)
        {
            EndTimer++;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z);
            if(EndTimer > 60)
            {
                FadePanel.SendMessage("FadeOut");
            }
            if(EndTimer > 190)
            {
                EndGameObject.SendMessage("EndGame");
            }
        }

    }

    void BossFinished()
    {
        bossComplete = true;

    }

}
