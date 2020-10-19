using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private Vector3 normalizeDirection;
    public float mDamage;
    public Transform target;
    public float speed = 1f;
    private GameObject mplayer;
    private int lifetime = 400;
    private int lifecount;
    void Start()
    {
        
        mplayer = GameObject.Find("PlayerCharacter");
        target = mplayer.transform;
        normalizeDirection = (target.position - transform.position).normalized;
        transform.forward = mplayer.transform.position - transform.position;
        transform.rotation = Quaternion.Euler(0, 0, this.transform.rotation.eulerAngles.z-180);
        
    }

    void Update()
    {
        lifecount++;
        if(lifecount > lifetime)
        {
            Destroy(this.gameObject);
        }
        transform.position += normalizeDirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.SendMessage("PlayerHit", mDamage);
            Destroy(this.gameObject);
        }
    }

}
