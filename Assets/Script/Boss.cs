using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
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



    public float shootspeed, shootTimer;
    private bool isShooting = false;
    public int gunnum= 1;



    public Transform shootPos1;
    public Transform shootPos2;
    public Transform shootPos3;
    public Transform shootPos4;
    public Transform shootPos5;
    public Transform shootPos6;
    public Transform shootPos7;
    public Transform shootPos8;
    public Transform shootPos9;
    public Transform shootPos10;
    public Transform shootPos11;
    public Transform shootPos12;

    public GameObject bullet;
    public GameObject missile;

    public GameObject enbullet;
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


        if (isShooting == false)
        {
            StartCoroutine(Shoot());
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
                gunnum = 2;
            }
            if (enemyhealth <= ьз)
            {
                spriteRenderer.sprite = Sprite3;
                gunnum = 3;
            }
            if (enemyhealth <= 0)
            {
                gunnum = 4;
                SoundManager.PlaySound("Explosion2");
                Instantiate(explode, transform.position, Quaternion.identity);
                Destroy(gameObject);

            }
        }
    }
    IEnumerator Shoot()
    {
        isShooting = true;
        if (gunnum == 1)
        {
            for (int i = 0; i < 2; i++)
            {
                if (gunnum == 4)
                {
                    break;
                }
                SoundManager.PlaySound("Bosscreate");
                roket();
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(1);

            for (int i = 0; i < 5; i++)
            {
                if (gunnum == 2)
                {
                    break;
                }
                FireEnemyBullet();
                SoundManager.PlaySound("EnemyBullet0");

                yield return new WaitForSeconds(0.3f);
            }
            yield return new WaitForSeconds(1);
        }
        else if (gunnum == 2)
        {
            for (int i = 0; i < 50; i++)
            {
                if (gunnum == 3)
                {
                    break;
                }
                SoundManager.PlaySound("EnemyBullet1");
                GameObject newBullet1 = Instantiate(bullet, shootPos1.position, Quaternion.identity);
                newBullet1.GetComponent<Rigidbody2D>().velocity = new Vector2(0.3f, shootspeed * Time.fixedDeltaTime);
                GameObject newBullet2 = Instantiate(bullet, shootPos2.position, Quaternion.identity);
                newBullet2.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.3f, shootspeed * Time.fixedDeltaTime);
                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(1);
            for (int i = 0; i < 20; i++)
            {
                if (gunnum == 3)
                {
                    break;
                }
                yield return new WaitForSeconds(0.1f);
                FireEnemyBullet();
                SoundManager.PlaySound("EnemyBullet0");
            }
           

            //for (int i = 0; i < 2; i++)
            //{
            //    if (gunnum == 3)
            //    {
            //        break;
            //    }
            //    SoundManager.PlaySound("Bosscreate");
            //    roket();
            //    yield return new WaitForSeconds(0.7f);
            //}
            yield return new WaitForSeconds(3);
        }
        else if (gunnum == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                if (gunnum == 4)
                {
                    break;
                }
                Bomb();
                SoundManager.PlaySound("Explosion1");
                yield return new WaitForSeconds(0.3f);
            }
            for (int i = 0; i < 4; i++)
            {
                if (gunnum == 4)
                {
                    break;
                }
                SoundManager.PlaySound("Bosscreate");
                roket();
                yield return new WaitForSeconds(0.7f);
            }
            yield return new WaitForSeconds(3);

        }
        isShooting = false;
    }
    public void roket()
    {
        Instantiate(missile, gameObject.transform.position, Quaternion.identity);
    }
    private void Bomb()
    {
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
    void FireEnemyBullet()
    {
        GameObject playership = GameObject.FindGameObjectWithTag("Player");
        if (playership != null)
        {
            GameObject bullet = (GameObject)Instantiate(enbullet);
            bullet.transform.position = transform.position;

            Vector2 direction = playership.transform.position - bullet.transform.position;

            bullet.GetComponent<EnemyBullet>().SetDirection(direction);

        }
    }

}