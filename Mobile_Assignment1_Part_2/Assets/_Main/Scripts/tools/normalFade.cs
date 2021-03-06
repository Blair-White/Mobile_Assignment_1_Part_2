﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class normalFade : MonoBehaviour
{
    private bool inout;
    private bool idle;
    public float StartAlpha;
    public float rate;
    public bool fadeComplete = false;
    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {
        if (StartAlpha == 0) inout = true; else inout = false;
        if (StartAlpha == 0)
        {
            this.GetComponent<Image>().color = new Color(1, 1, 1,0);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (idle) { return; }
        if (inout) { this.GetComponent<Image>().color = new Color(1, 1, 1, this.GetComponent<Image>().color.a + rate); }
        if (!inout) { this.GetComponent<Image>().color = new Color(1, 1, 1, this.GetComponent<Image>().color.a - rate); }
        if (inout && this.GetComponent<Image>().color.a >= 1) idle = true;
        if (!inout && this.GetComponent<Image>().color.a <= 0) idle = true;
    }

    void FadeOut()
    {
        inout = true;
        idle = false;
    }

    void FadeIn()
    {
        inout = false;
        idle = false;
    }
}

