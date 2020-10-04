using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeSprite : MonoBehaviour
{
    public float rate = 0;
    private float baseRate = 0;
    private float targetAlpha = 0;
    private float mAlpha = 0;
    private SpriteRenderer mRenderer;

    public enum States { FadeIn, FadeOut, done, idle };
    public States state;
    private void Awake()
    {
        mRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        state = States.FadeIn;
    }
    // Start is called before the first frame update
    void Start()
    {
        targetAlpha = 1;
        mRenderer.color = new Color(1, 1, 1, 0);
        baseRate = rate;
    }

    // Update is called once per frame
    void Update()
    {
        mAlpha = mRenderer.color.a;

        switch (state)
        {
            case (States.FadeIn):
                mRenderer.color = new Color(1, 1, 1, mRenderer.color.a + rate);
                rate *= 1.01f;
                if (mAlpha >= targetAlpha) state = States.done;
                break;

            case (States.FadeOut):
                mRenderer.color = new Color(1, 1, 1, mRenderer.color.a - rate);
                rate *= 1.01f;
                if (mAlpha <= targetAlpha) state = States.done;
                break;

            case (States.done):
                if (rate != baseRate) rate = baseRate;
                state = States.idle;
                break;

            case (States.idle):
                
                break;

        }

    }

    void FadeIn() {state = States.FadeIn; targetAlpha = 1; mRenderer.color = new Color(1, 1, 1, 0); }
    void FadeOut() { state = States.FadeOut; targetAlpha = 0; mRenderer.color = new Color(1, 1, 1, 1); }
}
