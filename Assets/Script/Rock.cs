using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float MoveSpeed;
    public SpriteRenderer spriteRenderer;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public float enemyhealth;
    public float rotspeed;
    float iki;
    float ��;
    public Rigidbody2D rb;
    public GameObject explode;
    void Start()
    {
        iki = (enemyhealth / 3) * 2;
        �� = (enemyhealth / 3);
        float b�y�kl�k = Random.Range(1f, 2f);
        float �arpan = Random.Range(-1f, 1.8f);
        float h�z� = Random.Range(1f, 1.8f);
        rotspeed = rotspeed * �arpan;
        spriteRenderer.transform.localScale = new Vector2(spriteRenderer.transform.localScale.x * b�y�kl�k, spriteRenderer.transform.localScale.y * b�y�kl�k);
        MoveSpeed = MoveSpeed * h�z�;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, -MoveSpeed, 0); 
        transform.Rotate(0, 0, 2 * Time.deltaTime * rotspeed);
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
            if (enemyhealth <= ��)
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