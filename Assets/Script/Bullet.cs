using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  //  public int ammoname;
    public string name;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (ammoname == 2)
        //{
        //    transform.Rotate(0, 0, 2 * Time.deltaTime * 250);
        //}
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("destroyer"))
        {
            Destroy(gameObject);
        }
        if (name == "player")
        {
            if (other.CompareTag("enemy") || other.CompareTag("boss"))
            {
                Destroy(gameObject);
            }
            //if (other.CompareTag("boss"))
            //{
            //    Destroy(gameObject);
            //}
        }
        if (name == "enemy")
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
              //  Plife.can--;
            }
        }
    }
}
