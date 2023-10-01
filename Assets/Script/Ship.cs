using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    public Camera cam;

    public int speed;
    public static GameObject Target;

    public float rotationModifier;
    public GameObject Trails;


    public Transform[] BölümKoordinatlarý;

    public bool Durammý = false;

    public GameObject kaya;
    public GameObject çapulcu;
    public GameObject gerginG;
    public GameObject Ordu;




    public Transform TKaya;
    public Transform TGezegenDýþý;
    public Transform TçapulcuSonrasý;
    public Transform TgerginSonrasý;



    public GameObject Panel;
    public GameObject m1Trigger;
    public GameObject m2Trigger;
    public GameObject m3Trigger;
    public GameObject m4Trigger;
    public GameObject m5Trigger;


    //bölümdurum için olaylar
    //
    //0  en baþ
    //1 kayaya deydik
    //2 kayayý yendik
    //3 gezegene vardýk
    //4 gezegeni yendik
    //5
    //6
    //7
    //8
    //9
    //10
    //11



    public static int bölümDURUM;
    public GameObject m1Panel; //kaya
    public GameObject m2Panel; //gezene varýþ
    public GameObject m2Panel1; //gezene varýþ
    public GameObject m2Panel2; //gezene varýþ
    public GameObject m3Panel; //kötü cevap
    public GameObject m4Panel; //iyi cevap
    public GameObject m4Panel1; //iyi cevap
    public GameObject m4Panel2; //iyi cevap
    public GameObject m5Panel; //gerginG adam
    public GameObject m5Panel1; //gerginG adam
    public GameObject m5Panel2; //gerginG adam
    public GameObject m6Panel; //Filo komutaný
    public GameObject m6Panel1; //Filo komutaný
    public GameObject m6Panel2; //Filo komutaný



    public GameObject YazýsalPanel; //yazýyla anlatým için kaya sonrasý
    public TMP_Text YazýsalPanelTXT; //yazýyla anlatým için kaya sonrasý



    public GameObject Rg1;
    public GameObject Rg2;
    public GameObject Rg3;
    public GameObject Fg1;
    public GameObject Fg2;
    public GameObject Fg3;



    public static int BaþlangýcDURUM;
    public GameObject BaþlangýcPanel;
    public TMP_Text BaþlangýçTXT;

    public GameObject End;



    //BölümNum 0 boþ
    //1 kayalar
    //    2 gez kaçýþ
    //    3 çapulcu
    //    4gergin görünüþlü
    //    5 yarma
    //    6 boss
    //    7 end

    void Start()
    {
        Application.targetFrameRate = 150;
        Baþlangýç();
    }
    public void Baþlangýç()
    {
        if (BaþlangýcDURUM == 0 && bölümDURUM == 0)
        {
            BaþlangýcDURUM++;
            BaþlangýcPanel.SetActive(true);
            BaþlangýçTXT.text = "Yýl: 2222 \nKimlik: K11a1a2n22 \nMeslek: Togg2222 nin kaptaný\n\nTürkiye artýk sadece dünyada süper güç olmakla kalmamýþ tüm evrende süper güç olmuþtur. Haliyle tüm evren Türkçe konuþmaktadýr.";
        }




        Trails.SetActive(false);



        if (bölümDURUM == 0)
        {
            Rg1.SetActive(true);
            Rg2.SetActive(false);
            Rg3.SetActive(false);
            Fg1.SetActive(false);
            Fg2.SetActive(true);
            Fg3.SetActive(true);
        }
        if (bölümDURUM != 0)
        {
            m1Trigger.SetActive(false);
        }

        if (bölümDURUM == 1) //kaya sonrasý
        {
            Rg1.SetActive(true);
            Rg2.SetActive(false);
            Rg3.SetActive(false);
            Fg1.SetActive(false);
            Fg2.SetActive(true);
            Fg3.SetActive(true);



            m1Trigger.SetActive(false);
            YazýsalPanel.SetActive(true);
            YazýsalPanelTXT.text = "Kayalarý temizledin þimdi yola devam etme vakti.";
            gameObject.transform.position = TKaya.position;

            if (PlayerPrefs.GetInt("BölümNum") < 2)
            {
                PlayerPrefs.SetInt("BölümNum", 2);
            }
        }

        if (bölümDURUM == 4) //gezegenden kaçýldý
        {
            Rg1.SetActive(false);
            Rg2.SetActive(true);
            Rg3.SetActive(false);
            Fg1.SetActive(true);
            Fg2.SetActive(false);
            Fg3.SetActive(true);





            m2Trigger.SetActive(false);
            YazýsalPanel.SetActive(true);
            YazýsalPanelTXT.text = "Gezegenden kaçmayý baþardýn. Hemen en yakýn diðer gezene ilerleyip takip edilmediðinden emin ol.";
            gameObject.transform.position = TGezegenDýþý.position;

            if (PlayerPrefs.GetInt("BölümNum") < 3)
            {
                PlayerPrefs.SetInt("BölümNum", 3);
            }

        }

        if (bölümDURUM == 6) //çapulcular yenildi
        {
            Rg1.SetActive(false);
            Rg2.SetActive(true);
            Rg3.SetActive(false);
            Fg1.SetActive(true);
            Fg2.SetActive(false);
            Fg3.SetActive(true);




            m3Trigger.SetActive(false);
            YazýsalPanel.SetActive(true);
            YazýsalPanelTXT.text = "Uzay çapulcularýnýn büyük kýsmýný yok ettin. Kalanlarda hýzla senden kaçýyor.";
            gameObject.transform.position = TçapulcuSonrasý.position;
            m4Trigger.SetActive(true);

            if (PlayerPrefs.GetInt("BölümNum") < 4)
            {
                PlayerPrefs.SetInt("BölümNum", 4);
            }
        }

        if (bölümDURUM == 8) //gergin öldürüldü
        {
            Rg1.SetActive(false);
            Rg2.SetActive(false);
            Rg3.SetActive(true);
            Fg1.SetActive(true);
            Fg2.SetActive(true);
            Fg3.SetActive(false);



            m4Trigger.SetActive(false);
            YazýsalPanel.SetActive(true);
            YazýsalPanelTXT.text = "Tutsaðý (Gergin görünüþlü adamý) öldürdün. Canlý olarak ele geçirmeliydin. Bir daha rdppr ye yaklaþmamalýsýn.\n (Ayný zamanda) Dünyadan yardým çaðrýsý alýyoruz, hemen dünyaya doðru yola çýk.";
            gameObject.transform.position = TgerginSonrasý.position;
            m5Trigger.SetActive(true);

            if (PlayerPrefs.GetInt("BölümNum") < 5)
            {
                PlayerPrefs.SetInt("BölümNum", 5);
            }

        }
        if (bölümDURUM == 10) //Boss FÝGHT
        {
            YazýsalPanel.SetActive(true);
            YazýsalPanelTXT.text = "Filoyu yararak düþman komuta gemisine ulaþtýn. Filo komutaný seninle görüþmek istiyor.";

            if (PlayerPrefs.GetInt("BölümNum") < 6)
            {
                PlayerPrefs.SetInt("BölümNum", 6);
            }

        }
        if (bölümDURUM == 12) //boss fight kazanýldý
        {
            YazýsalPanel.SetActive(true);
            YazýsalPanelTXT.text = "Komuta gemisini yoketmeyi baþardýn. Tüm filo, komuta gemisine bunu yapan bize neler yapmaz düþüncesiyle hýzlýca kaçýþýyor. Tebrikler dünyayý kurtardýn.";

            if (PlayerPrefs.GetInt("BölümNum") < 7)
            {
                PlayerPrefs.SetInt("BölümNum", 7);
            }
        }
    }

    void Update()
    {

        if (Target != null && !Durammý)
        {
            Trails.SetActive(true);
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);


            Vector3 vectorToTarget = Target.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier + 270;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);

            if (Vector2.Distance(transform.position, Target.transform.position) < 0.01f)
            {
                Target = null;

            }
        }
        else
        {
            Trails.SetActive(false);
        }




    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("m1"))
        {

            m1Trigger.SetActive(false);
            Durammý = true;
            kaya.SetActive(true);


            StartCoroutine(Waiter());

        }
        if (other.CompareTag("m2"))
        {
            YazýsalPanel.SetActive(true);
            YazýsalPanelTXT.text = "Gezegene ulaþtýn ve yetkililerle görüþmeye gidiyorsun. Burdaki canlýlarýn tipleri komiðine gidiyor (Farkýnda olmadan alaycý þekilde konuþacaksýn).";
            bölümDURUM++;
            m2Trigger.SetActive(false);
            Durammý = true;


        }
        if (other.CompareTag("m3"))
        {
            çapulcu.SetActive(true);
        }

        if (other.CompareTag("çapulcu"))
        {
            Debug.Log("çapulcu");
            Durammý = true;
            StartCoroutine(WaiterÇapulcu());

            //YazýsalPanel.SetActive(true);
            //YazýsalPanelTXT.text = "Gezegene ulaþtýn ve yetkililerle görüþmeye gidiyorsun.";
            //bölümDURUM++;
            //m2Trigger.SetActive(false);
            //Durammý = true;
        }

        if (other.CompareTag("m4")) //gezegen
        {
            YazýsalPanel.SetActive(true);
            YazýsalPanelTXT.text = "Büyük kýzýl gezegene sonunda ulaþtýn. Büyük bir kalabalýkla birlikte bu geliþmiþ gezegenin baþkanýyla görüþmeye gidiyorsun.";
            bölümDURUM++;//7
            m4Trigger.SetActive(false);
        }

        if (other.CompareTag("gergin"))
        {
            Durammý = true;
            m5Panel.SetActive(true);

        }

        if (other.CompareTag("m5")) //gezegen
        {
            Durammý = true;
            Ordu.SetActive(true);
            StartCoroutine(WaiterBordu());

        }

    }
    IEnumerator Waiter()
    {
        if (PlayerPrefs.GetInt("BölümNum") < 1)
        {
            PlayerPrefs.SetInt("BölümNum", 1);
        }
        yield return new WaitForSeconds(2f);
        m1Panel.SetActive(true);
    }
    IEnumerator WaiterÇapulcu()
    {
        yield return new WaitForSeconds(2f);
        YazýsalPanel.SetActive(true);
        YazýsalPanelTXT.text = "Etrafýný uzay çapulcularý sardý. Bir zaman sonra liderleri seninle görüþme talebinde bulunuyor.";
        bölümDURUM++; //5
    }
    IEnumerator WaiterBordu()
    {
        yield return new WaitForSeconds(2f);
        YazýsalPanel.SetActive(true);
        YazýsalPanelTXT.text = "Dünyaya doðru oldukça büyük bir savaþ filosu ilerliyor. Tüm filoyu tek baþýna yoketmen imkansýz gibi ama filonun tam ortasýnda kumanda gemisinin olduðunu fark ediyorsun. Komuta gemisi bertaraf edilebilirse tüm filo daðýlabilir ve savaþ baþlamadan biter. Komuta gemisine ulaþmak " +
            "için düþman hatlarýný yararak geçmeyi denemelisin.";
        bölümDURUM++;//9
        m5Trigger.SetActive(false);
    }

    public void yAZISALpANELKAPA()
    {


        if (bölümDURUM == 2)
        {
            m2Panel.SetActive(true);
        }
        if (bölümDURUM == 3)
        {
            m2Panel2.SetActive(false);
            m2Panel.SetActive(false);
            m2Panel1.SetActive(false);
            Time.timeScale = 1;
            ShipG.kurtarM = 0;
            Application.LoadLevel("2");
        }
        if (bölümDURUM == 5)
        {
            m3Panel.SetActive(true);
        }
        if (bölümDURUM == 7)
        {
            m4Panel.SetActive(true);
        }
        if (bölümDURUM == 9) //orduya karþý ilk savaþ 
        {
            Time.timeScale = 1;
            ShipG.kurtarM = 0;
            Application.LoadLevel("5");

        }
        if (bölümDURUM == 10) //orduya karþý ilk savaþ kazanýldý filo lideri ile görüþme
        {
            m6Panel.SetActive(true);

        }
        if (bölümDURUM == 11) //bossFight
        {
            m6Panel2.SetActive(false);
            m6Panel1.SetActive(false);
            m6Panel.SetActive(false);
            Debug.Log("bossFight");
            ShipG.kurtarM = 0;
            Application.LoadLevel("6");

        }
        if(bölümDURUM == 12)
        {
            //oyun btmiþ aga

            End.SetActive(true);
        }


        YazýsalPanel.SetActive(false);
    }

    public void m1BTN()
    {
        Time.timeScale = 1;
        ShipG.kurtarM = 0;
        Application.LoadLevel("1");
    }
    public void m2BTN1()
    {
        m2Panel1.SetActive(true);
    }
    public void m2BTN2()
    {
        m2Panel2.SetActive(true);
    }
    public void m2BTN11()
    {
        YazýsalPanel.SetActive(true);
        YazýsalPanelTXT.text = "Yönetici bir ýslýkla etrafýna binlerce kiþiyi topladý. Yenemeyeceðin bir savaþ olduðunu fark ediyorsun ve gezengenden kaçmak için hemen Togg2222 ye atlýyorsun.";
        bölümDURUM++;//3
    }
    public void m2BTN21()
    {
        YazýsalPanel.SetActive(true);
        YazýsalPanelTXT.text = "Yönetici çok garip birisi. Etrafýna yavaþ yavaþ toplanmaya baþladýlar ve bunun sonucunda sana saldýrmayý planladýklarýný anlýyorsun. Yenemeyeceðin bir savaþ olduðunu fark ediyorsun ve gezengenden kaçmak için hemen Togg2222 ye atlýyorsun.";
        bölümDURUM++;//3
    }
    public void m3BTN()
    {
        Time.timeScale = 1;
        ShipG.kurtarM = 0;
        Application.LoadLevel("3");
    }

    public void m4BTN1()
    {
        
        m4Panel1.SetActive(true);
        m4Panel.SetActive(false);

    }
    public void m4BTN2()
    {
        m4Panel2.SetActive(true);
        m4Panel.SetActive(false);

    }

    public void m4BTN3()
    {
        m4Panel1.SetActive(false);
        m4Panel2.SetActive(false);
        m4Panel.SetActive(false);
        gerginG.SetActive(true);


    }
    public void m5BTN1()
    {
        m5Panel1.SetActive(true);
    }
    public void m5BTN2()
    {
        m5Panel2.SetActive(true);
    }
    public void m5BTN3()
    {
        Time.timeScale = 1;
        ShipG.kurtarM = 0;
        Application.LoadLevel("4");

    }
    public void m6BTN1()
    {
        m6Panel2.SetActive(false);
        m6Panel1.SetActive(true);

    }
    public void m6BTN2()
    {
        m6Panel1.SetActive(false);
        m6Panel2.SetActive(true);

    }
    public void m6BTN22()
    {
        YazýsalPanel.SetActive(true);
        YazýsalPanelTXT.text = "Tebrikler anime kýzýna kanmadýn. Þimdi saldýrmanýn tam sýrasý.";
        bölümDURUM++;//11
    }
    public void m6BTN21()
    {
        YazýsalPanel.SetActive(true);
        YazýsalPanelTXT.text = "Tebrikler anime kýzýna kanmýþ gibi rol yapmak güzel fikirdi. Þimdi saldýrmanýn tam sýrasý.";
        bölümDURUM++;//11
    }
    public void LevelOpen(int sayý)
    {
        End.SetActive(false);

        bölümDURUM = sayý;
        Application.LoadLevel(SceneManager.GetActiveScene().name);
       // Baþlangýç();
    }

    public void BaþlangýçBTNmetot()
    {
        if (BaþlangýcDURUM == 1)
        {
            BaþlangýcDURUM++;
            BaþlangýcPanel.SetActive(true);
            BaþlangýçTXT.text = "Kontroller:\n\nHaritadayken:\nGitmek istediðiniz gezenin üzerine týklayarak ilerleyin. Esc ile oyunu durdurabilirsiniz.\n\nSavaþ Alanýnda:\nWASD veya ok tuþlarýyla hareket edebilir Space ile ateþ edebilirsiniz. Esc ile oyunu durdurabilirsiniz.";
        }
        else if (BaþlangýcDURUM == 2)
        {
            BaþlangýcDURUM++;
            BaþlangýcPanel.SetActive(true);
            BaþlangýçTXT.text = "Not1: Oyunu tam manasýyla deneyimlemeniz için sonuna dek gelmeniz tavsiye olunur.\n\nNot2: Eðerki geçemediðiniz bölüm olursa diye _Kurtar Beni_ butonunu ekledim. Bu buton her bölüm için 5 kez ölündükten sonra açýlýr ve bölümü pas geçmek isterseniz kullanabilirsiniz.";
        }
        else if (BaþlangýcDURUM == 3)
        {
            BaþlangýcDURUM++;
            BaþlangýcPanel.SetActive(true);
            BaþlangýçTXT.text = "Görevin:\n\nGünlük devriyeni yapmak üzere A3x54 gezegenine doðru yola çýk.\n\n(Unutma ki geminin radarý arýzalý sadece yakýndaki nesneleri veya büyük gezegenleri görebilirsin.)";
        }
        else if (BaþlangýcDURUM == 4)
        {
            BaþlangýcPanel.SetActive(false);
        }
    }

}