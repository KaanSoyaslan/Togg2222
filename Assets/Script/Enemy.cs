using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float rotspeed;

    public GameObject bullet;


    public GameObject explode;
//    public GameObject coin;
    public SpriteRenderer spriteRenderer;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public float enemyhealth;
    float iki;
    float üç;
    public float MoveSpeed;


    public int enemyname;


    public float hlchange;
    public float coinchance;

    public Rigidbody2D rb;
    //int a = 0;
    //bool b = false;










    float sinCentreX;
    public float amplitude = 2; //dalgaboyu
    public float frequency = 0.5f; // frekans
    public bool inverted;
    public bool babaBenSinüsCizcem;
    public bool babaBenBeklicem;
    public float WaitPoint = 1f; // bekleyeceði nokta
    public float WaitAmount = 1f; // bekleyeceði süre
    bool WaitAGAM = false;

    void Start()
    {
        //hlchange = 200;
        coinchance = 5000;

        //   enemyhealth = enemyhealth * Plife.enemyhealttimes;
        iki = (enemyhealth / 3) * 2;
        üç = (enemyhealth / 3);


        //bu kýsým sinüslü deneme þeysi
        sinCentreX = transform.position.x;
    }

    void Update()
    {

        if (!babaBenBeklicem)
        {
            rb.velocity = new Vector3(0, -MoveSpeed, 0);
        }
        if (babaBenBeklicem)
        {
            if (transform.position.y > WaitPoint && WaitAGAM == false)
            {
                rb.velocity = new Vector3(0, -MoveSpeed, 0);
            }
            else if (transform.position.y < WaitPoint && WaitAGAM == false)
            {
                rb.velocity = new Vector3(0, 0, 0);
                StartCoroutine(WaitAGGA());
            }
            else if (WaitAGAM == true)
            {
                rb.velocity = new Vector3(0, -MoveSpeed, 0);
            }
        }

        if (babaBenSinüsCizcem == true)
        {
            Vector2 pos = transform.position;
            float sin = Mathf.Sin(pos.y * frequency) * amplitude;
            if (inverted)
            {
                sin *= -1;
            }
            pos.x = sinCentreX + sin;
            transform.position = pos;
        }



        //enemy ismine göre hareket tipleri
        //if(enemyname == 3 )
        //{

        //    if (transform.position.y > 5 && WaitAGAM == false)
        //    {
        //        rb.velocity = new Vector3(0, -MoveSpeed, 0);
        //    }
        //    else if(transform.position.y < 5 && WaitAGAM == false)
        //    {
        //        rb.velocity = new Vector3(0, 0, 0);
        //        StartCoroutine(WaitAGGA());
        //    }
        //    else if (WaitAGAM == true)
        //    {
        //        rb.velocity = new Vector3(0, -MoveSpeed*1.5f, 0);
        //    }
        //}
        //if(enemyname == 1)
        //{

        //    //if(transform.position.y > 10)
        //    //{
        //    //    amplitude = 0.1f;
        //    //    rb.velocity = new Vector3(0, -MoveSpeed * 4, 0);
        //    //}
        //    //else if(transform.position.y > -4 && transform.position.y < 10)
        //    //{
        //    //    amplitude = 2f;
        //    //   rb.velocity = new Vector3(0, -MoveSpeed, 0);

        //    //}
        //    //else
        //    //{
        //    //    amplitude =  3;
        //    //    frequency = 1;
        //    //    rb.velocity = new Vector3(0, -MoveSpeed * 2, 0);
        //    //}

        //    if (transform.position.y > 10)
        //    {                
        //        rb.velocity = new Vector3(0, -MoveSpeed * 4, 0);
        //    }
        //    else if (transform.position.y > 8 && transform.position.y < 10 && WaitAGAM ==false)
        //    {
        //        StartCoroutine(WaitAGGA());
        //        amplitude = 2f;
        //        frequency = -3f;
        //        rb.velocity = new Vector3(0, 0, 0);

        //    }
        //    else if (transform.position.y < 10 && WaitAGAM == true)
        //    {

        //        amplitude = 2f;
        //        frequency = 1;
        //        rb.velocity = new Vector3(0, -MoveSpeed, 0);

        //    }
        //    //else
        //    //{
        //    //    amplitude = 3;
        //    //    frequency = 1;
        //    //    rb.velocity = new Vector3(0, -MoveSpeed * 2, 0);
        //    //}

        //    Vector2 pos = transform.position;
        //    float sin = Mathf.Sin(pos.y * frequency) * amplitude;
        //    if (inverted)
        //    {
        //        sin *= -1;
        //    }
        //    pos.x = sinCentreX + sin;
        //    transform.position = pos;




        //    //if (b == true && a > -666)
        //    //{
        //    //    a--;
        //    //    rb.velocity = new Vector3(-MoveSpeed, 0, 0);
        //    //}
        //    //else if (b == true && a < -666)
        //    //{
        //    //    b = false;
        //    //}

        //    //if (a < 666 && b == false)
        //    //{
        //    //    a++;
        //    //    rb.velocity = new Vector3(MoveSpeed, 0, 0);
        //    //}
        //    //else if (a > 666 && b == false)
        //    //{
        //    //    b = true;
        //    //}



        //    Debug.Log(a);
        //    Debug.Log(b);
        //}



        if (enemyname == 2)
        {
            transform.Rotate(0, 0, 2 * Time.deltaTime * rotspeed);
        }
        if (enemyname == 6)
        {
            transform.Rotate(0, 0, 2 * Time.deltaTime * rotspeed);
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
                if (enemyname != 2)
                {
                 //   Instantiate(coin, transform.position, Quaternion.identity);
                    //    while (ScoreCounter.scoreAmount > coinchance) //coin çoklayýcý
                    //    {
                    //        Instantiate(coin, transform.position, Quaternion.identity);
                    //        coinchance = coinchance + 5000;
                    //    }
                    //}
                    if (enemyname == 6)
                    {
                    //    Instantiate(coin, transform.position, Quaternion.identity);
                     //   Instantiate(coin, transform.position, Quaternion.identity);
                        //     SoundManager.PlaySound("Explosion2");
                        Bomb();
                    }

                    //  SoundManager.PlaySound("Explosion1");
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
                if (enemyname == 6)
                {
                    Bomb();
                }
                //  Plife.can--;
                //  SoundManager.PlaySound("Explosion1");
                Instantiate(explode, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
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

    IEnumerator WaitAGGA()
    {
        WaitAGAM = false;
        yield return new WaitForSeconds(WaitAmount);
        WaitAGAM = true;

    }
    
    
}
