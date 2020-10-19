﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaverScript : MonoBehaviour
{
    public int HP = 8;
    public SpriteRenderer mRenderer;
    public GameObject explosion, mBullet;
    public GameObject AudioPlayer;
    public AudioSource AudioSrc;
    public AudioClip ExplosionSound;
    private bool isHit;
    private int count, shootcount;

    // Start is called before the first frame update
    void Start()
    {
        AudioPlayer = GameObject.Find("SFX AudioSource");
        AudioSrc = AudioPlayer.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        shootcount++;
        if(shootcount > 300)
        {
            GameObject b = Instantiate(mBullet, transform.position, Quaternion.identity);
            b.GetComponent<EnemyProjectile>().mDamage = .15f;
            shootcount = 0;
        }
        if (isHit)
        {
            count++;
            if (count > 3)
            {
                mRenderer.color = new Color(1, 1, 1, 1);
                isHit = false;
                count = 0;
            }

        }
        if (HP <= 0) DestroyedByPlayer();
    }

    void HitBullet()
    {
        HP -= 1;
        isHit = true;
        mRenderer.color = new Color(1, 0, 0, 1);
    }

    void HitMissile(int AddedDamage)
    {
        HP -= 2 + AddedDamage;
        isHit = true;
        mRenderer.color = new Color(1, 0, 0, 1);
    }

    void DestroyedByPlayer()
    {
        AudioSrc.PlayOneShot(ExplosionSound);
        Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        Destroy(this.gameObject);
    }
}
