using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public GameObject mPlayer;
    private bool isActive;
    private int activeCount;
    public int expmultiplier;
    // Start is called before the first frame update
    void Start()
    {
        mPlayer = GameObject.Find("PlayerCharacter");    
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.02f, 0);
            activeCount++;
            if(activeCount > 80)
            {
                isActive = true;
            }
        }

        if(isActive)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, mPlayer.transform.position, .5f);
            if(Vector3.Distance(this.transform.position, mPlayer.transform.position) < 0.05f)
            {
                mPlayer.SendMessage("GetExp", 0.15f * expmultiplier);
                Destroy(this.gameObject);
            }
        }


    }
}
