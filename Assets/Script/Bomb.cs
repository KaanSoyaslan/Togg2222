using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
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

    void Start()
    {
        iki = (enemyhealth / 3) * 2;
        üç = (enemyhealth / 3);
        float büyüklük = Random.Range(1f, 1.2f);
        float çarpan = Random.Range(-1f, 1.8f);
        float hýzÇ = Random.Range(1f, 1.8f);
        rotspeed = rotspeed * çarpan;
        spriteRenderer.transform.localScale = new Vector2(spriteRenderer.transform.localScale.x * büyüklük, spriteRenderer.transform.localScale.y * büyüklük);
        MoveSpeed = MoveSpeed * hýzÇ;
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
            if (enemyhealth <= üç)
            {
                spriteRenderer.sprite = Sprite3;
            }
            if (enemyhealth <= 0)
            {
                BombPatla();
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
            BombPatla();
            Instantiate(explode, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }


    }
    private void BombPatla()
    {
        SoundManager.PlaySound("Explosion2");
        GameObject newBullet1 = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        newBullet1.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 500 * Time.fixedDeltaTime);
        GameObject newBullet2 = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        newBullet2.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -500 * Time.fixedDeltaTime);

        GameObject newBullet3 = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        newBullet3.GetComponent<Rigidbody2D>().velocity = new Vector2(500 * Time.fixedDeltaTime, 0f);
        GameObject newBullet4 = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        newBullet4.GetComponent<Rigidbody2D>().velocity = new Vector2(-500 * Time.fixedDeltaTime, 0f);

        GameObject newBullet5 = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        newBullet5.GetComponent<Rigidbody2D>().velocity = new Vector2(350 * Time.fixedDeltaTime, 350 * Time.fixedDeltaTime);
        GameObject newBullet6 = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        newBullet6.GetComponent<Rigidbody2D>().velocity = new Vector2(-350 * Time.fixedDeltaTime, -350 * Time.fixedDeltaTime);

        GameObject newBullet7 = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        newBullet7.GetComponent<Rigidbody2D>().velocity = new Vector2(-350 * Time.fixedDeltaTime, 350 * Time.fixedDeltaTime);
        GameObject newBullet8 = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        newBullet8.GetComponent<Rigidbody2D>().velocity = new Vector2(350 * Time.fixedDeltaTime, -350 * Time.fixedDeltaTime);




        GameObject newBullet9 = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        newBullet9.GetComponent<Rigidbody2D>().velocity = new Vector2(461 * Time.fixedDeltaTime, 191 * Time.fixedDeltaTime);
        GameObject newBullet10 = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        newBullet10.GetComponent<Rigidbody2D>().velocity = new Vector2(461 * Time.fixedDeltaTime, -191 * Time.fixedDeltaTime);


        GameObject newBullet11 = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        newBullet11.GetComponent<Rigidbody2D>().velocity = new Vector2(-461 * Time.fixedDeltaTime, 191 * Time.fixedDeltaTime);
        GameObject newBullet12 = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        newBullet12.GetComponent<Rigidbody2D>().velocity = new Vector2(-461 * Time.fixedDeltaTime, -191 * Time.fixedDeltaTime);


        GameObject newBullet13 = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        newBullet13.GetComponent<Rigidbody2D>().velocity = new Vector2(-191 * Time.fixedDeltaTime, 461 * Time.fixedDeltaTime);
        GameObject newBullet14 = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        newBullet14.GetComponent<Rigidbody2D>().velocity = new Vector2(191 * Time.fixedDeltaTime, -461 * Time.fixedDeltaTime);


        GameObject newBullet15 = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        newBullet15.GetComponent<Rigidbody2D>().velocity = new Vector2(-191 * Time.fixedDeltaTime, -461 * Time.fixedDeltaTime);
        GameObject newBullet16 = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        newBullet16.GetComponent<Rigidbody2D>().velocity = new Vector2(191 * Time.fixedDeltaTime, 461 * Time.fixedDeltaTime);

    }
}