using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public int HP = 1552;
    public GameObject explosion, bullet, mPlayer, Crasher, Crasherstart;
    public SpriteRenderer mRenderer;
    public GameObject AudioPlayer;
    public AudioSource AudioSrc;
    public AudioClip ExplosionSound;
    public Vector3 CrasherStartPos;
    private bool isHit,isInit;
    private int count, spawnCount, shootCount;
    // Start is called before the first frame update
    void Start()
    {
        AudioPlayer = GameObject.Find("SFX AudioSource");
        AudioSrc = AudioPlayer.GetComponent<AudioSource>();
        Crasherstart = GameObject.Find("HoverStart");
        CrasherStartPos = Crasherstart.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

       

        if (isHit)
        {
            count++;
            if (count > 1)
            {
                mRenderer.color = new Color(1, 1, 1, 1);
                isHit = false;
                count = 0;
            }

        }
        if (HP <= 0) DestroyedByPlayer();

        if(!isInit)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.1f, 0);
            if (this.transform.position.y < 3.3f) isInit = true;
        }
        if(isInit)
        {
            transform.right = mPlayer.transform.position - transform.position;
            shootCount++;
            if(shootCount > 10)
            {
                GameObject b = Instantiate(bullet, CrasherStartPos, Quaternion.identity);
                b.GetComponent<EnemyProjectile>().mDamage = .25f;
                
                shootCount = 0;
            }
            spawnCount++;
            if(spawnCount > 30)
            {
                Instantiate(Crasher, this.transform.position, Quaternion.identity);
                spawnCount = 0;
            }
        }


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
