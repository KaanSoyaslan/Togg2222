using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public SpriteRenderer renderer;
    bool Se�ildim = false;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Se�ildim)
        {
            Ship.Target = gameObject;
        }
    }
    private void OnMouseEnter()
    {
        renderer.color = Color.grey;
        Se�ildim = true;

    }
    private void OnMouseExit()
    {
        renderer.color = Color.white; 
        Se�ildim = false;
    }

}

