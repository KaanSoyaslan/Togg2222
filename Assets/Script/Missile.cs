using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Missile : MonoBehaviour
{
    Transform target;

    public float speed = -3f;
    public float rotateSpeed = 200f;


    private Rigidbody2D rb;



    public SpriteRenderer spriteRenderer;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public float enemyhealth;
    float iki;
    float üç;
    public GameObject explode;


    void Start()
    {
        iki = (enemyhealth / 3) * 2;
        üç = (enemyhealth / 3);
        float hızÇ = Random.Range(1f, 1.8f);
        speed = speed * hızÇ;

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotateAmount * rotateSpeed;
            rb.velocity = transform.up * speed;
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
        if (other.CompareTag("enemy"))
        {
            SoundManager.PlaySound("Explosion1");
            Instantiate(explode, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }
}
