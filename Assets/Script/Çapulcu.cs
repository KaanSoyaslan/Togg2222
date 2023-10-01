using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Çapulcu : MonoBehaviour
{
    Transform target;

    public float speed = -3f;
    public float rotateSpeed = 200f;

    private Rigidbody2D rb;
    bool Durammı = false;

    void Start()
    {


        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null && !Durammı)
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

        if (other.CompareTag("Player"))
        {

            Durammı = true;
            rb.velocity = new Vector2(0f,0f);
            Destroy(gameObject.GetComponent<BoxCollider2D>());

        }
    }
}