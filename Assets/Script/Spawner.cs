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


    public int B�l�m�i�nmiktar;
    int Anl�kMiktar = 0;

    bool DurAl�m = false;

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
            if (Time.time > nextSpawn && !DurAl�m)
            {
                int i = Random.Range(0, enemyS.Length);
                enemy = enemyS[i];
                nextSpawn = Time.time + spawnRate;
                randX = Random.Range(-7.5f, 7.5f);
                whereToSpawn = new Vector2(randX, transform.position.y);
                Instantiate(enemy, whereToSpawn, Quaternion.identity);

                // enemy.GetComponent<Enemy>().babaBenSin�sCizcem = true;
                Anl�kMiktar++;

            }
            if (Anl�kMiktar >= B�l�m�i�nmiktar && !isShooting)
            {
                DurAl�m = true;
                StartCoroutine(Waiter(7f));

            }
        }
        else if(grup&&!gergin)
        {
            if (GameObject.FindGameObjectWithTag("enemy") == null)
            {
                grupSpawnTime = false;
            }
            if (Anl�kMiktar >= B�l�m�i�nmiktar && !isShooting && GameObject.FindGameObjectWithTag("enemy") == null)
            {
                DurAl�m = true;
                StartCoroutine(Waiter(0f));

            }
            if (grup && !grupSpawnTime && !DurAl�m)
            {
                grupSpawnTime = true;
                enemy = enemyS[Anl�kMiktar];
                // nextSpawn = Time.time + spawnRate;
                // randX = Random.Range(-7.5f, 7.5f);
                whereToSpawn = new Vector2(0, transform.position.y);
                Instantiate(enemy, whereToSpawn, Quaternion.identity);
                // enemy.GetComponent<Enemy>().babaBenSin�sCizcem = true;
                Anl�kMiktar++;
            }
            


        }
        else if(gergin && !grup)
        {
            if (GerginTarget == null)
            {
                DurAl�m = true;
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
            Ship.b�l�mDURUM++;
        }      
        isShooting = false;
    }
}
