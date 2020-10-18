using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public int HP = 152;
    public GameObject explosion;
    public SpriteRenderer mRenderer;
    public GameObject AudioPlayer;
    public AudioSource AudioSrc;
    public AudioClip ExplosionSound;
    private bool isHit;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        AudioPlayer = GameObject.Find("SFX AudioSource");
        AudioSrc = AudioPlayer.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
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

    void HitMissile()
    {
        HP -= 10;
    }

    void DestroyedByPlayer()
    {
        AudioSrc.PlayOneShot(ExplosionSound);
        Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        Destroy(this.gameObject);
    }
}
