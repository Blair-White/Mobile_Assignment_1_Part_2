using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissileScript : MonoBehaviour
{
    public bool isHot;
    public int DelayFire, HoverSpeed, FireSpeed;
    public Animator mAnimator;
    public AnimationClip mClip;
    public AudioSource AudioSrc;
    public AudioClip HoverSound, FireSound, ImpactSound;
    public GameObject ImpactEffect, AudioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        AudioPlayer = GameObject.Find("SFX AudioSource");
        AudioSrc = AudioPlayer.GetComponent<AudioSource>();
        AudioSrc.volume = .5f;
        AudioSrc.PlayOneShot(HoverSound);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!isHot)
        {
            DelayFire++;
            if (DelayFire > 60) { isHot = true; AudioSrc.PlayOneShot(HoverSound); }
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - HoverSpeed, 0);
        }

        if(isHot)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + FireSpeed, 0);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyShip")
        {
            collision.gameObject.SendMessage("HitBullet");
            AudioSrc.volume = 1.0f;
            AudioSrc.PlayOneShot(ImpactSound);
            Instantiate(ImpactEffect, new Vector3(collision.transform.position.x, collision.transform.position.y, 0), Quaternion.Euler(0, 0, 90));
            Destroy(this.gameObject);
        }
    }
}
