using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaverScript : MonoBehaviour
{
    public int HP = 8;
    public SpriteRenderer mRenderer;
    public GameObject explosion, mBullet, coin, healthpack, mPlayer;
    public GameObject AudioPlayer;
    public AudioSource AudioSrc;
    public AudioClip ExplosionSound;
    private bool isHit;
    private int count, shootcount;

    // Start is called before the first frame update
    void Start()
    {
        AudioPlayer = GameObject.Find("SFX AudioSource");
        mPlayer = GameObject.Find("PlayerCharacter");
        AudioSrc = AudioPlayer.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        shootcount++;
        if(shootcount > 200)
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
        GameObject c = Instantiate(coin, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        c.GetComponent<CoinPickup>().expmultiplier = 5;
        RollForHealthDrop();
        mPlayer.SendMessage("GetScore", Random.Range(25, 35));
        Destroy(this.gameObject);
    }

    void RollForHealthDrop()
    {
        int r = Random.Range(0, 100);
        if (r > 90)
        {
            Instantiate(healthpack, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }
}
