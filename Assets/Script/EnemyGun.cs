using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject enbullet;

    public float shootTimer;
    private bool isShooting;

    void Start()
    {

        isShooting = false;
        Invoke("FireEnemyBullet", 1f);

        float çarpan = Random.Range(1f, 1.8f);
        shootTimer = shootTimer * çarpan;
    }

    void Update()
    {
        if (isShooting == false)
        {
            StartCoroutine(Shoot());
        }


    }
    void FireEnemyBullet()
    {
        GameObject playership = GameObject.FindGameObjectWithTag("Player");
        if (playership != null)
        {
            SoundManager.PlaySound("EnemyBullet1");
            GameObject bullet = (GameObject)Instantiate(enbullet);
            bullet.transform.position = transform.position;

            Vector2 direction = playership.transform.position - bullet.transform.position;

            bullet.GetComponent<EnemyBullet>().SetDirection(direction);

        }
    }
    IEnumerator Shoot()
    {
        isShooting = true;



        yield return new WaitForSeconds(shootTimer);
        FireEnemyBullet();
      //  SoundManager.PlaySound("EnemyBullet0");
        isShooting = false;
    }
}

