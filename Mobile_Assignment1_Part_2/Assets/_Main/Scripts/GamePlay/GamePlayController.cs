﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    private bool init;
    private int initTimer, gameTimer;
    public GameObject mPlayer, uiCanvas, score, shields, hull, scrap, 
        shieldsUpButton, shieldsUp, attackSpeedUpButton, attackSpeedUp, missileUpButton, missileUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!init)
        {
            initTimer++;
            if(initTimer>45)
            {
                init = true; initTimer = 0;
                score.SetActive(true); shields.SetActive(true); hull.SetActive(true); scrap.SetActive(true);
            }
        }



    }
}