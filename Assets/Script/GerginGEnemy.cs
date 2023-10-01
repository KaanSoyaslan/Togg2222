using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerginGEnemy : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int randomSpot;


    public GameObject explode;
    public SpriteRenderer spriteRenderer;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public float enemyhealth;
    float iki;
    float ьз;


    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);


        iki = (enemyhealth / 3) * 2;
        ьз = (enemyhealth / 3);

    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {

            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;

            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pbullet"))
        {
            enemyhealth--;
            if (enemyhealth <= iki)
            {
                spriteRenderer.sprite = Sprite2;
            }
            if (enemyhealth <= ьз)
            {
                spriteRenderer.sprite = Sprite3;
            }
            if (enemyhealth <= 0)
            {
                SoundManager.PlaySound("Explosion1");
                Instantiate(explode, transform.position, Quaternion.identity);
                Destroy(gameObject);

            }
        }
        if (other.CompareTag("destroyer"))
        {
            Destroy(gameObject);
        }
        //if (other.CompareTag("Player"))
        //{
        //    SoundManager.PlaySound("Explosion1");
        //    Instantiate(explode, transform.position, Quaternion.identity);
        //    Destroy(gameObject);
        //}


    }
}