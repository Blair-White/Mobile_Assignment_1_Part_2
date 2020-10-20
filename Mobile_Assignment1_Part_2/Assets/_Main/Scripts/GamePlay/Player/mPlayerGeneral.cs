﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class mPlayerGeneral : MonoBehaviour
{
    public int ShootThrottle, MissileThrottle;
    private int ShootCount, MissileCount;
    public GameObject projectile, muzzle, missile, mAudioPlayer;
    public int MissileAddedDamage = 0;
    public GameObject HealthBar, ShieldBar, ExpBar, ScoreText;
    public float Health, HealthDisplayed, Shield, ShieldDisplayed, Exp, ExpDisplayed;
    public float ShieldRegenRate = 0.001f;
    private int Score, ScoreDisplayed, MyLevel;
    public SpriteRenderer mRenderer;
    private bool isHit, isCollectCoin;
    private int count, coinResetCount;

    public AudioSource mAudSource;
    public AudioClip[] coinclips;
    public AudioClip HealSound;
    public int coinstate;
    // Start is called before the first frame update
    void Start()
    {
        MyLevel = 1;
        Score = 0;
        Exp = 0;
        Health = 1f;
        Shield = 1f;
        HealthDisplayed = 1f;
        ShieldDisplayed = 1f;
        ExpDisplayed = 0f;
        mAudSource = mAudioPlayer.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollectCoin) coinResetCount++;
        if (coinResetCount > 300) { isCollectCoin = false; coinResetCount = 0; coinstate = 0; }

        if (isHit)
        {
            count++;
            if (count > 5)
            {
                mRenderer.color = new Color(1, 1, 1, 1);
                isHit = false;
                count = 0;
            }

        }

        if (Shield < ShieldDisplayed) { ShieldDisplayed -= 0.01f; }
        if(Shield > ShieldDisplayed) { ShieldDisplayed += 0.01f; }
        if(Shield < 1f) { Shield += ShieldRegenRate; }
        
        if(Health < HealthDisplayed) { HealthDisplayed -= 0.01f; }
        if(Health > HealthDisplayed) { HealthDisplayed += 0.01f; }
        
        if(Exp < ExpDisplayed) { ExpDisplayed -= 0.01f; }
        if(Exp > ExpDisplayed) { ExpDisplayed += 0.01f; }
        
        if(Score > ScoreDisplayed) { ScoreDisplayed += 1; }
       
        if (Health <= 0) PlayerKilled();
        if (Health > 1) { Health = 1; }
        if (Health < 0) { Health = 0; }
        
        if (Shield > 1) { Shield = 1; }
        if (Shield < 0) { Shield = 0; }

        if (Exp >= 1) { Exp = 1; PlayerLevelUp(); }
        if (Exp <= 0) { Exp = 0; }

        HealthBar.gameObject.transform.localScale =new Vector3(HealthDisplayed,1, 1);
        ShieldBar.gameObject.transform.localScale = new Vector3(ShieldDisplayed,1, 1 );
        ExpBar.gameObject.transform.localScale = new Vector3(ExpDisplayed, 1, 1 );
        ScoreText.GetComponent<TextMeshProUGUI>().text = ScoreDisplayed.ToString();


        muzzle.SetActive(false);
        ShootCount++;
        if(ShootCount > ShootThrottle)
        {
            Instantiate(projectile, new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z), Quaternion.identity);
            ShootCount = 0;
            muzzle.SetActive(true);
        }

        MissileCount++;
        if(MissileCount > MissileThrottle)
        {
          MissileCount = 0;
          GameObject m = Instantiate(missile, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
          m.GetComponent<PlayerMissileScript>().AddedDamage = MissileAddedDamage;  
        }
    }


    void PlayerKilled()
    {

    }

    void PlayerHit(float Damage)
    {
        if(Shield - Damage < 0)
        {
            float SpillDamage = Damage - Shield;
            Shield = 0;
            Health -= SpillDamage;
        }
        else if(Shield - Damage > 0)
        { Shield -= Damage; }

        isHit = true;
        mRenderer.color = new Color(1, 0, 0, 1);
    }

    void HealPlayer(float HealAmount)
    {
        if (Shield + HealAmount >= 1)
        {
            float SpillDamage = HealAmount - (1 - Shield);
            Shield = 1;
            Health += SpillDamage;
        }
        else if (Shield + HealAmount < 1)
        { Shield += HealAmount; }

        isHit = true;
        mRenderer.color = new Color(0, 1, 0, 1);
        mAudSource.PlayOneShot(HealSound);
    }

    void GetExp(float ExpAmount)
    {
        ExpAmount /= MyLevel;
        Exp += ExpAmount;
        mAudSource.PlayOneShot(coinclips[coinstate]);
        coinstate++;
        if (coinstate > 3) coinstate = 0;
        isCollectCoin = true;
    }

    void UpgradeCannon()
    {

    }

    void UpgradeShields()
    {

    }

    void UpgradeMissile()
    {

    }

    void GetScore(int ScoreAmount)
    {
        Score += ScoreAmount;
    }

    void PlayerLevelUp()
    {
        MyLevel++;
    }
}
