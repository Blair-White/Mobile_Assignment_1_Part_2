using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class textFade : MonoBehaviour
{
    private bool inout;
    private bool idle;
    public float StartAlpha;
    public float rate;
    private Color mColor;
    public bool fadeComplete = false;
    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {
        mColor = this.GetComponent<TextMeshProUGUI>().color;
        if (StartAlpha == 0) inout = true; else inout = false;
        if (StartAlpha == 0)
        {
            this.GetComponent<TextMeshProUGUI>().color = new Color(mColor.r, mColor.g, mColor.b, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (idle) return;
        if (inout) { this.GetComponent<TextMeshProUGUI>().color =
                new Color(mColor.r, mColor.g, mColor.b, this.GetComponent<TextMeshProUGUI>().color.a + rate); }
        if (!inout) { this.GetComponent<TextMeshProUGUI>().color = 
                new Color(mColor.r, mColor.g, mColor.b, this.GetComponent<TextMeshProUGUI>().color.a - rate); }
        if (inout && this.GetComponent<TextMeshProUGUI>().color.a <= 0) idle = true;
        if (!inout && this.GetComponent<TextMeshProUGUI>().color.a >= 1) idle = true;
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

