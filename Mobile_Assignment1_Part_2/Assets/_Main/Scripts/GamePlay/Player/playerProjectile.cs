using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class playerProjectile : MonoBehaviour
{
    public float MoveSpeed;
    public int LifeTime;
    private int counter;
    public AudioSource AudioSrc;
    public AudioClip FireSound, ImpactSound;
    public GameObject ImpactEffect, AudioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        AudioPlayer = GameObject.Find("SFX AudioSource");
        AudioSrc = AudioPlayer.GetComponent<AudioSource>();
        AudioSrc.volume = .5f;
        AudioSrc.PlayOneShot(FireSound);
    }
    // Update is called once per frame
    void Update()
    {
        counter++;
        if(counter > LifeTime)
        {
            Destroy(this.gameObject);
        }
        Vector3 mPos = this.transform.position;
        this.transform.position = new Vector3(mPos.x, mPos.y + MoveSpeed, mPos.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EnemyShip")
        {
            collision.gameObject.SendMessage("HitBullet");
            AudioSrc.volume = 1.0f;            
            AudioSrc.PlayOneShot(ImpactSound);
            Instantiate(ImpactEffect, new Vector3(transform.position.x, transform.position.y,0), Quaternion.Euler(0,0,90));
            Destroy(this.gameObject);
        }
    }
}
