using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoFade : MonoBehaviour
{
    public int FadeState = 0;
    public float rate = 0;
    private float baseRate = 0;
    private float targetAlpha = 0;
    public float mAlpha = 0;
    private SpriteRenderer mRenderer;
    private int transitionThrottle;
    private bool upDown;
    private void Awake()
    {
        mRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        mRenderer.color = new Color(1, 1, 1, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        targetAlpha = 1.0f;
        rate = .011f;
        baseRate = rate;
    }

    // Update is called once per frame
    void Update()
    {
        mAlpha = mRenderer.material.color.a;
        switch (FadeState)
        {
            
            case 0: targetAlpha = 1; upDown = false; break;
            case 1: targetAlpha = .7f; upDown = true; break;
            case 2: targetAlpha = 1; upDown = false; break;
            case 3: targetAlpha = .75f; upDown = true; break;
            case 4: targetAlpha = 1; upDown = false; break;
            case 5: targetAlpha = .8f; upDown = true; break;
            case 6: targetAlpha = 1; upDown = false; break;
            case 7: targetAlpha = .85f; upDown = true; break;
            case 8: targetAlpha = 1; upDown = false;  break;
            case 9:
                transitionThrottle++;
                if(mRenderer.color.a <= 0 && transitionThrottle > 140)
                {
                    SceneManager.LoadScene(1);
                }
                break;
            


            default:
                break;

        }

      

        mRenderer.color = new Color(1, 1, 1, mRenderer.color.a + rate);
        rate *= 1.01f;


        if(!upDown)
        {
            if(mRenderer.color.a >= targetAlpha)
            {
                upDown = false;
                rate = -baseRate;
                FadeState++;
            }
        }
        if(upDown)
        {
            if (mRenderer.color.a <= targetAlpha)
            {
                upDown = true;
                rate = baseRate;
                FadeState++;
            }

        }
    }
}
