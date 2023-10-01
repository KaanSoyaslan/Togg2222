using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    Vector2 _direction;
    bool isready;

    void Awake()
    {
        isready = false;
    }

    void Start()
    {

    }
    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        isready = true;
    }

    void Update()
    {
        if (isready)
        {
            Vector2 position = transform.position;
            position += _direction * speed * Time.deltaTime;
            transform.position = position;
        }


    }

}
