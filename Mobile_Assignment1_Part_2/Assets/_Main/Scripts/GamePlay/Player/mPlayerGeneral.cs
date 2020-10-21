using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
    public GameObject LvlCannon, LvlMissile, LvlShield, LvlText;
    public float Health, HealthDisplayed, Shield, ShieldDisplayed, Exp, ExpDisplayed;
    public float ShieldRegenRate = 0.001f;
    private int Score, ScoreDisplayed, MyLevel;
    public SpriteRenderer mRenderer;
    private bool isHit, isCollectCoin, isLvling,initDeath;
    private int count, coinResetCount, lvlcount;

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

        if(isLvling)
        {
            lvlcount++;
            if(lvlcount > 90)
            {
                lvlcount = 0;
                isLvling = false;
                endlevelup();
            }
        }
    }


    void PlayerKilled()
    {
        initDeath = true;
        Destroy(this.gameObject);
        GameObject g = GameObject.Find("GamePlayController");
        g.SendMessage("PlayerDied");
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
        isLvling = true;
        Exp = 0;
        if(MyLevel == 1)
        {
            LvlCannon.SetActive(true);
            LvlText.SetActive(true);
            ShootThrottle -= 5;
        }
        if(MyLevel == 2)
        {
            LvlMissile.SetActive(true);
            LvlText.SetActive(true);
            MissileAddedDamage += 8;
        }
        if(MyLevel == 3)
        {
            LvlShield.SetActive(true);
            LvlText.SetActive(true);
            ShieldRegenRate += 0.001f;
        }
        
        if(MyLevel == 4)
        {
            LvlCannon.SetActive(true);
            LvlText.SetActive(true);
            ShootThrottle -= 3;
        }
        if (MyLevel == 5)
        {
            LvlCannon.SetActive(true);
            LvlText.SetActive(true);
            ShootThrottle -= 3;

        }
        if(MyLevel == 6)
        {
            LvlCannon.SetActive(true);
            LvlText.SetActive(true);
            ShootThrottle -= 2;
        }
        if (MyLevel == 7)
        {
            LvlCannon.SetActive(true);
            LvlText.SetActive(true);
            ShootThrottle -= 2;
        }
        if (MyLevel == 8)
        {
            LvlMissile.SetActive(true);
            LvlText.SetActive(true);
            MissileAddedDamage += 5;
        }
        MyLevel++;
        
    }
    void endlevelup()
    {
        LvlCannon.SetActive(false);
        LvlMissile.SetActive(false);
        LvlShield.SetActive(false);
        LvlText.SetActive(false);
    }
}
