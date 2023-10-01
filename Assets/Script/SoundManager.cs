using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip Bosscreate, Buy, Coin, CoinSpawn, EnemyBullet0,
        EnemyBullet1, Explosion0, Explosion1, Explosion2, Heal, Magnet, PlayerBullet, Selectt, Upgrade;
    static AudioSource audioSrc;
    void Start()
    {
        Bosscreate = Resources.Load<AudioClip>("Bosscreate");
        Buy = Resources.Load<AudioClip>("Buy");
        Coin = Resources.Load<AudioClip>("Coin");
        CoinSpawn = Resources.Load<AudioClip>("CoinSpawn");
        EnemyBullet0 = Resources.Load<AudioClip>("EnemyBullet0");
        EnemyBullet1 = Resources.Load<AudioClip>("EnemyBullet1");
        Explosion0 = Resources.Load<AudioClip>("Explosion0");
        Explosion1 = Resources.Load<AudioClip>("Explosion1");
        Explosion2 = Resources.Load<AudioClip>("Explosion2");
        Heal = Resources.Load<AudioClip>("Heal");
        Magnet = Resources.Load<AudioClip>("Magnet");
        PlayerBullet = Resources.Load<AudioClip>("PlayerBullet");
        Selectt = Resources.Load<AudioClip>("Selectt");
        Upgrade = Resources.Load<AudioClip>("Upgrade");
       

        audioSrc = GetComponent<AudioSource>();
    }


    void Update()
    {

    }
    public static void PlaySound(string clip)
    {
        
            switch (clip)
            {
                case "Bosscreate":
                    audioSrc.PlayOneShot(Bosscreate);
                    break;
                case "Buy":
                    audioSrc.PlayOneShot(Buy);
                    break;
                case "Coin":
                    audioSrc.PlayOneShot(Coin);
                    break;
                case "CoinSpawn":
                    audioSrc.PlayOneShot(CoinSpawn);
                    break;
                case "EnemyBullet0":
                    audioSrc.PlayOneShot(EnemyBullet0);
                    break;
                case "EnemyBullet1":
                    audioSrc.PlayOneShot(EnemyBullet1);
                    break;
                case "Explosion0":
                    audioSrc.PlayOneShot(Explosion0);
                    break;
                case "Explosion1":
                    audioSrc.PlayOneShot(Explosion1);
                    break;
                case "Explosion2":
                    audioSrc.PlayOneShot(Explosion2);
                    break;
                case "Heal":
                    audioSrc.PlayOneShot(Heal);
                    break;
                case "Magnet":
                    audioSrc.PlayOneShot(Magnet);
                    break;
                case "PlayerBullet":
                    audioSrc.PlayOneShot(PlayerBullet);
                    break;
                case "Select":
                    audioSrc.PlayOneShot(Selectt);
                    break;
                case "Upgrade":
                    audioSrc.PlayOneShot(Upgrade);
                    break;



                    break;
            
        }
       
    }
}


