using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotEffect : MonoBehaviour
{
    public AnimationClip MyClip;
    public float TimePassed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimePassed += Time.deltaTime;
        if(MyClip.length <= TimePassed)
        {
            Destroy(this.gameObject);
        }
    }
}
