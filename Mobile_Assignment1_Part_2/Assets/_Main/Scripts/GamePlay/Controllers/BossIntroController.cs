using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIntroController : MonoBehaviour
{
    public GameObject mText, mPanel, mBoss;
    public bool incoming, inOut;
    private int counta, countb;
    // Start is called before the first frame update
    void Start()
    {
        mText.SetActive(true);
        mPanel.SetActive(true);
        incoming = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(countb > 8)
        {
            mPanel.SetActive(false);
            mText.SetActive(false);
            mBoss.SetActive(true);
            this.GetComponent<BossIntroController>().enabled = false;
            
        }

       if(incoming)
       {
            counta++;
            if (counta > 45)
            { 
                if(inOut)
                {
                    mPanel.SendMessage("FadeOut");
                    mText.SendMessage("FadeOut");
                    inOut = false;
                    counta = 0;
                    countb++;
                }
                else if(!inOut)
                {
                    mPanel.SendMessage("FadeIn");
                    mText.SendMessage("FadeIn");
                    inOut = true;
                    counta = 0;
                    countb++;
                }
            }
            
       }
    }
}
