using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBekleyen : MonoBehaviour
{
    public float MoveSpeed;
    public SpriteRenderer spriteRenderer;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public float enemyhealth;
    public float rotspeed;
    float iki;
    float üç;
    public Rigidbody2D rb;
    public GameObject explode;

    public GameObject bullet;


    public float WaitPoint = 1f; // bekleyeceði nokta


    void Start()
    {
        iki = (enemyhealth / 3) * 2;
        üç = (enemyhealth / 3);
        float hýzÇ = Random.Range(1f, 1.8f);
        MoveSpeed = MoveSpeed * hýzÇ;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > WaitPoint )
        {
            rb.velocity = new Vector3(0, -MoveSpeed, 0);
        }
        else if (transform.position.y < WaitPoint)
        {
            rb.velocity = new Vector3(0, 0, 0);
       
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
            if (enemyhealth <= üç)
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
        if (other.CompareTag("Player"))
        {
            SoundManager.PlaySound("Explosion1");
            Instantiate(explode, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }


    }
}
