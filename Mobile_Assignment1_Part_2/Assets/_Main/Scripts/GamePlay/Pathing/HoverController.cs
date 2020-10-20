using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverController : MonoBehaviour
{
    private GameObject mPlayer, HoverPositionParent, StartPosition;
    public GameObject explosion, mBullet, coin, Healthpack;
    public GameObject AudioPlayer;
    public AudioSource AudioSrc;
    public AudioClip ExplosionSound;
    private Transform[] HoverPositions;
    private int CurrentHoverTarget, NewHoverTarget, shootcount;
    private float waitCount, ShootCount, ShootInterval;
    public float TimeBetweenMoves, MoveSpeed;

    public int HP = 25;
    public SpriteRenderer mRenderer;
    private bool isHit;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        AudioPlayer = GameObject.Find("SFX AudioSource");
        AudioSrc = AudioPlayer.GetComponent<AudioSource>();
        if (MoveSpeed == 0) MoveSpeed = 3;
        if (TimeBetweenMoves == 0) TimeBetweenMoves = 4;
        HoverPositionParent = GameObject.Find("HoverPositions");
        mPlayer = GameObject.Find("PlayerCharacter");
        StartPosition = GameObject.Find("HoverStart");
        HoverPositions = HoverPositionParent.GetComponentsInChildren<Transform>();
        CurrentHoverTarget = Random.Range(0, HoverPositions.Length);
        this.transform.position = new Vector3(StartPosition.transform.position.x, StartPosition.transform.position.y, 0);

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
        transform.right = mPlayer.transform.position - transform.position;

        if (Vector3.Distance(this.transform.position, HoverPositions[CurrentHoverTarget].position) > 0.2f)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, 
                new Vector3(HoverPositions[CurrentHoverTarget].position.x, HoverPositions[CurrentHoverTarget].position.y, 0), MoveSpeed * Time.deltaTime);
        }
            


        waitCount += Time.deltaTime;
        if(waitCount > TimeBetweenMoves)
        {
            while(NewHoverTarget == CurrentHoverTarget)
            {
                NewHoverTarget = Random.Range(0, HoverPositions.Length);
                return;
            }
            CurrentHoverTarget = NewHoverTarget;
            waitCount = 0;
        }


        shootcount++;
        if (shootcount > 60)
        {

            GameObject b = Instantiate(mBullet, transform.position, Quaternion.identity);
            b.GetComponent<EnemyProjectile>().mDamage = .25f;
            shootcount = 0;
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
        GameObject c = Instantiate(coin, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        c.GetComponent<CoinPickup>().expmultiplier = 5;
        RollForHealthDrop();
        mPlayer.SendMessage("GetScore", Random.Range(105, 155));
        Destroy(this.gameObject);
    }

    void RollForHealthDrop()
    {
        int r = Random.Range(0, 100);
        if(r > 100)
        {
            Instantiate(Healthpack, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }
}
