﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public int HP = 152;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0) DestroyedByPlayer();
    }

    void DestroyedByPlayer()
    {


        Destroy(this.gameObject);
    }

    void HitBullet()
    {
        HP -= 1;
    }

    void HitMissile()
    {
        HP -= 10;
    }


}