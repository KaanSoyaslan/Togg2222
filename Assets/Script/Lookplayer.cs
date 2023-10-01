using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Lookplayer : MonoBehaviour
{
    
    public float rotateSpeed = 200f;

    private Rigidbody2D rb;
    Transform target;

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
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Vector2 direction = (Vector2)target.position - rb.position ;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            //rotateAmount += 180;
            rb.angularVelocity = -rotateAmount * rotateSpeed;
        }

        
    }
   
    
}
