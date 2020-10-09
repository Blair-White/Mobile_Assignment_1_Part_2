using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public AudioSource MySource;
    public void PlayOneShotSound(AudioClip clip)
    {
        MySource.PlayOneShot(clip);
    }
}
