using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaverScript : MonoBehaviour
{
    public int HP = 8;
    public SpriteRenderer mRenderer;
    private bool isHit;
    private int count;
    // Start is called before the first frame update
    void Start()
    {

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


        Destroy(this.gameObject);
    }
}
