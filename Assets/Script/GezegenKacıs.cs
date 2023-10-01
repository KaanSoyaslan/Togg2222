using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GezegenKacıs : MonoBehaviour
{
    public GameObject Gezegen;
    public GameObject Hedef;
    public float speed;
    public float küçültmeMiktarı;

    bool Varıldı = false;
    bool küçültüüc;
    void Start()
    {

    }
    private void FixedUpdate()
    {
        


        if (Vector2.Distance(Gezegen.transform.position, Hedef.transform.position) < 0.01f)
        {
         

        }
        else
        {
            Gezegen.transform.position = Vector2.MoveTowards(Gezegen.transform.position, Hedef.transform.position, speed * Time.deltaTime);
        }

        if(!küçültüüc && !Varıldı)
        {
            StartCoroutine(küçült());
        }

    }
    IEnumerator küçült()
    {
        küçültüüc = true;

        if(Gezegen.transform.localScale.x > 1)
        {
            Gezegen.transform.localScale = new Vector2(Gezegen.transform.localScale.x - küçültmeMiktarı, Gezegen.transform.localScale.y - küçültmeMiktarı);
        }
        else
        {
            Varıldı = true;


        }
        yield return new WaitForSeconds(0.2f);

        küçültüüc = false;
    }
}