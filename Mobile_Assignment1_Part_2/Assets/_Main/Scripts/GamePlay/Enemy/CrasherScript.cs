using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrasherScript : MonoBehaviour
{
    public int HP = 5;
    public GameObject explosion, coin, healthpack, mPlayer;
    public SpriteRenderer mRenderer;
    public GameObject AudioPlayer;
    public AudioSource AudioSrc;
    public AudioClip ExplosionSound;
    private bool isHit;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        mPlayer = GameObject.Find("PlayerCharacter");
        AudioPlayer = GameObject.Find("SFX AudioSource");
        AudioSrc = AudioPlayer.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isHit)
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
        c.GetComponent<CoinPickup>().expmultiplier = 2;
        mPlayer.SendMessage("GetScore", Random.Range(15, 35));
        RollForHealthDrop();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.SendMessage("PlayerHit", 0.25f);
            DestroyedByPlayer();
           
        }
    }

    void RollForHealthDrop()
    {
        int r = Random.Range(0, 100);
        if (r >= 90)
        {
            Instantiate(healthpack, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }
}
