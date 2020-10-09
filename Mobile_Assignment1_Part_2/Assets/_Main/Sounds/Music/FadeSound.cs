using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSound : MonoBehaviour
{
    private AudioSource mAudio;
    private bool fadeIn, fadeOut;
    public float MaxVolume, FadeInRate, FadeOutRate;
   
    // Start is called before the first frame update
    void Start()
    {
        mAudio = this.GetComponent<AudioSource>();
        mAudio.volume = 0;
        FadeInSound();
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            if(mAudio.volume < MaxVolume)
            {
                mAudio.volume += FadeInRate;
            }
        }
        if (fadeOut)
        {
            if(mAudio.volume > 0)
            {
                mAudio.volume -= FadeOutRate;
            }
        }

    }

    void FadeInSound()
    {
        fadeIn = true;
        fadeOut = false;
    }

    void FadeOutSound()
    {
        fadeOut = true;
        fadeIn = false;
    }

    void StopSound()
    {

    }
}
