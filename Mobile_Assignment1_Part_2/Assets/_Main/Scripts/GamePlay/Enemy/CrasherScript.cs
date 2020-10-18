﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrasherScript : MonoBehaviour
{
    public int HP = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0) DestroyedByPlayer();
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