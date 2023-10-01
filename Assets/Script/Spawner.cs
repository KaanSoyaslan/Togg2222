using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyS;
    Vector2 whereToSpawn;
    public float spawnRate = 1.75f;
    float nextSpawn = 0.0f;
    float randX;

    GameObject enemy;


    public int BölümÝiçnmiktar;
    int AnlýkMiktar = 0;

    bool DurAlým = false;

    public GameObject WinSc;
    public GameObject DeadSc;

    bool isShooting = false;

    public bool grup;
    bool grupSpawnTime = false;

    public bool gergin;
    public GameObject GerginTarget;

    GameObject EnemyTarget;
    void Start()
    {
        nextSpawn = 1f + Time.time + spawnRate;

        
     
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!grup && !gergin)
        {
            if (Time.time > nextSpawn && !DurAlým)
            {
                int i = Random.Range(0, enemyS.Length);
                enemy = enemyS[i];
                nextSpawn = Time.time + spawnRate;
                randX = Random.Range(-7.5f, 7.5f);
                whereToSpawn = new Vector2(randX, transform.position.y);
                Instantiate(enemy, whereToSpawn, Quaternion.identity);

                // enemy.GetComponent<Enemy>().babaBenSinüsCizcem = true;
                AnlýkMiktar++;

            }
            if (AnlýkMiktar >= BölümÝiçnmiktar && !isShooting)
            {
                DurAlým = true;
                StartCoroutine(Waiter(7f));

            }
        }
        else if(grup&&!gergin)
        {
            if (GameObject.FindGameObjectWithTag("enemy") == null)
            {
                grupSpawnTime = false;
            }
            if (AnlýkMiktar >= BölümÝiçnmiktar && !isShooting && GameObject.FindGameObjectWithTag("enemy") == null)
            {
                DurAlým = true;
                StartCoroutine(Waiter(0f));

            }
            if (grup && !grupSpawnTime && !DurAlým)
            {
                grupSpawnTime = true;
                enemy = enemyS[AnlýkMiktar];
                // nextSpawn = Time.time + spawnRate;
                // randX = Random.Range(-7.5f, 7.5f);
                whereToSpawn = new Vector2(0, transform.position.y);
                Instantiate(enemy, whereToSpawn, Quaternion.identity);
                // enemy.GetComponent<Enemy>().babaBenSinüsCizcem = true;
                AnlýkMiktar++;
            }
            


        }
        else if(gergin && !grup)
        {
            if (GerginTarget == null)
            {
                DurAlým = true;
                StartCoroutine(Waiter(2f));

            }
        }
        

   

        

    }

    IEnumerator Waiter(float bekleyici)
    {
        isShooting = true;

        yield return new WaitForSeconds(bekleyici);

        if (!DeadSc.activeInHierarchy && !WinSc.activeInHierarchy)
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            WinSc.SetActive(true);
            Ship.bölümDURUM++;
        }      
        isShooting = false;
    }
}
