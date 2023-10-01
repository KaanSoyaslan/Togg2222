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


    public Transform[] B�l�mKoordinatlar�;

    public bool Duramm� = false;

    public GameObject kaya;
    public GameObject �apulcu;
    public GameObject gerginG;
    public GameObject Ordu;




    public Transform TKaya;
    public Transform TGezegenD���;
    public Transform T�apulcuSonras�;
    public Transform TgerginSonras�;



    public GameObject Panel;
    public GameObject m1Trigger;
    public GameObject m2Trigger;
    public GameObject m3Trigger;
    public GameObject m4Trigger;
    public GameObject m5Trigger;


    //b�l�mdurum i�in olaylar
    //
    //0  en ba�
    //1 kayaya deydik
    //2 kayay� yendik
    //3 gezegene vard�k
    //4 gezegeni yendik
    //5
    //6
    //7
    //8
    //9
    //10
    //11



    public static int b�l�mDURUM;
    public GameObject m1Panel; //kaya
    public GameObject m2Panel; //gezene var��
    public GameObject m2Panel1; //gezene var��
    public GameObject m2Panel2; //gezene var��
    public GameObject m3Panel; //k�t� cevap
    public GameObject m4Panel; //iyi cevap
    public GameObject m4Panel1; //iyi cevap
    public GameObject m4Panel2; //iyi cevap
    public GameObject m5Panel; //gerginG adam
    public GameObject m5Panel1; //gerginG adam
    public GameObject m5Panel2; //gerginG adam
    public GameObject m6Panel; //Filo komutan�
    public GameObject m6Panel1; //Filo komutan�
    public GameObject m6Panel2; //Filo komutan�



    public GameObject Yaz�salPanel; //yaz�yla anlat�m i�in kaya sonras�
    public TMP_Text Yaz�salPanelTXT; //yaz�yla anlat�m i�in kaya sonras�



    public GameObject Rg1;
    public GameObject Rg2;
    public GameObject Rg3;
    public GameObject Fg1;
    public GameObject Fg2;
    public GameObject Fg3;



    public static int Ba�lang�cDURUM;
    public GameObject Ba�lang�cPanel;
    public TMP_Text Ba�lang��TXT;

    public GameObject End;



    //B�l�mNum 0 bo�
    //1 kayalar
    //    2 gez ka���
    //    3 �apulcu
    //    4gergin g�r�n��l�
    //    5 yarma
    //    6 boss
    //    7 end

    void Start()
    {
        Application.targetFrameRate = 150;
        Ba�lang��();
    }
    public void Ba�lang��()
    {
        if (Ba�lang�cDURUM == 0 && b�l�mDURUM == 0)
        {
            Ba�lang�cDURUM++;
            Ba�lang�cPanel.SetActive(true);
            Ba�lang��TXT.text = "Y�l: 2222 \nKimlik: K11a1a2n22 \nMeslek: Togg2222 nin kaptan�\n\nT�rkiye art�k sadece d�nyada s�per g�� olmakla kalmam�� t�m evrende s�per g�� olmu�tur. Haliyle t�m evren T�rk�e konu�maktad�r.";
        }




        Trails.SetActive(false);



        if (b�l�mDURUM == 0)
        {
            Rg1.SetActive(true);
            Rg2.SetActive(false);
            Rg3.SetActive(false);
            Fg1.SetActive(false);
            Fg2.SetActive(true);
            Fg3.SetActive(true);
        }
        if (b�l�mDURUM != 0)
        {
            m1Trigger.SetActive(false);
        }

        if (b�l�mDURUM == 1) //kaya sonras�
        {
            Rg1.SetActive(true);
            Rg2.SetActive(false);
            Rg3.SetActive(false);
            Fg1.SetActive(false);
            Fg2.SetActive(true);
            Fg3.SetActive(true);



            m1Trigger.SetActive(false);
            Yaz�salPanel.SetActive(true);
            Yaz�salPanelTXT.text = "Kayalar� temizledin �imdi yola devam etme vakti.";
            gameObject.transform.position = TKaya.position;

            if (PlayerPrefs.GetInt("B�l�mNum") < 2)
            {
                PlayerPrefs.SetInt("B�l�mNum", 2);
            }
        }

        if (b�l�mDURUM == 4) //gezegenden ka��ld�
        {
            Rg1.SetActive(false);
            Rg2.SetActive(true);
            Rg3.SetActive(false);
            Fg1.SetActive(true);
            Fg2.SetActive(false);
            Fg3.SetActive(true);





            m2Trigger.SetActive(false);
            Yaz�salPanel.SetActive(true);
            Yaz�salPanelTXT.text = "Gezegenden ka�may� ba�ard�n. Hemen en yak�n di�er gezene ilerleyip takip edilmedi�inden emin ol.";
            gameObject.transform.position = TGezegenD���.position;

            if (PlayerPrefs.GetInt("B�l�mNum") < 3)
            {
                PlayerPrefs.SetInt("B�l�mNum", 3);
            }

        }

        if (b�l�mDURUM == 6) //�apulcular yenildi
        {
            Rg1.SetActive(false);
            Rg2.SetActive(true);
            Rg3.SetActive(false);
            Fg1.SetActive(true);
            Fg2.SetActive(false);
            Fg3.SetActive(true);




            m3Trigger.SetActive(false);
            Yaz�salPanel.SetActive(true);
            Yaz�salPanelTXT.text = "Uzay �apulcular�n�n b�y�k k�sm�n� yok ettin. Kalanlarda h�zla senden ka��yor.";
            gameObject.transform.position = T�apulcuSonras�.position;
            m4Trigger.SetActive(true);

            if (PlayerPrefs.GetInt("B�l�mNum") < 4)
            {
                PlayerPrefs.SetInt("B�l�mNum", 4);
            }
        }

        if (b�l�mDURUM == 8) //gergin �ld�r�ld�
        {
            Rg1.SetActive(false);
            Rg2.SetActive(false);
            Rg3.SetActive(true);
            Fg1.SetActive(true);
            Fg2.SetActive(true);
            Fg3.SetActive(false);



            m4Trigger.SetActive(false);
            Yaz�salPanel.SetActive(true);
            Yaz�salPanelTXT.text = "Tutsa�� (Gergin g�r�n��l� adam�) �ld�rd�n. Canl� olarak ele ge�irmeliydin. Bir daha rdppr ye yakla�mamal�s�n.\n (Ayn� zamanda) D�nyadan yard�m �a�r�s� al�yoruz, hemen d�nyaya do�ru yola ��k.";
            gameObject.transform.position = TgerginSonras�.position;
            m5Trigger.SetActive(true);

            if (PlayerPrefs.GetInt("B�l�mNum") < 5)
            {
                PlayerPrefs.SetInt("B�l�mNum", 5);
            }

        }
        if (b�l�mDURUM == 10) //Boss F�GHT
        {
            Yaz�salPanel.SetActive(true);
            Yaz�salPanelTXT.text = "Filoyu yararak d��man komuta gemisine ula�t�n. Filo komutan� seninle g�r��mek istiyor.";

            if (PlayerPrefs.GetInt("B�l�mNum") < 6)
            {
                PlayerPrefs.SetInt("B�l�mNum", 6);
            }

        }
        if (b�l�mDURUM == 12) //boss fight kazan�ld�
        {
            Yaz�salPanel.SetActive(true);
            Yaz�salPanelTXT.text = "Komuta gemisini yoketmeyi ba�ard�n. T�m filo, komuta gemisine bunu yapan bize neler yapmaz d���ncesiyle h�zl�ca ka����yor. Tebrikler d�nyay� kurtard�n.";

            if (PlayerPrefs.GetInt("B�l�mNum") < 7)
            {
                PlayerPrefs.SetInt("B�l�mNum", 7);
            }
        }
    }

    void Update()
    {

        if (Target != null && !Duramm�)
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
            Duramm� = true;
            kaya.SetActive(true);


            StartCoroutine(Waiter());

        }
        if (other.CompareTag("m2"))
        {
            Yaz�salPanel.SetActive(true);
            Yaz�salPanelTXT.text = "Gezegene ula�t�n ve yetkililerle g�r��meye gidiyorsun. Burdaki canl�lar�n tipleri komi�ine gidiyor (Fark�nda olmadan alayc� �ekilde konu�acaks�n).";
            b�l�mDURUM++;
            m2Trigger.SetActive(false);
            Duramm� = true;


        }
        if (other.CompareTag("m3"))
        {
            �apulcu.SetActive(true);
        }

        if (other.CompareTag("�apulcu"))
        {
            Debug.Log("�apulcu");
            Duramm� = true;
            StartCoroutine(Waiter�apulcu());

            //Yaz�salPanel.SetActive(true);
            //Yaz�salPanelTXT.text = "Gezegene ula�t�n ve yetkililerle g�r��meye gidiyorsun.";
            //b�l�mDURUM++;
            //m2Trigger.SetActive(false);
            //Duramm� = true;
        }

        if (other.CompareTag("m4")) //gezegen
        {
            Yaz�salPanel.SetActive(true);
            Yaz�salPanelTXT.text = "B�y�k k�z�l gezegene sonunda ula�t�n. B�y�k bir kalabal�kla birlikte bu geli�mi� gezegenin ba�kan�yla g�r��meye gidiyorsun.";
            b�l�mDURUM++;//7
            m4Trigger.SetActive(false);
        }

        if (other.CompareTag("gergin"))
        {
            Duramm� = true;
            m5Panel.SetActive(true);

        }

        if (other.CompareTag("m5")) //gezegen
        {
            Duramm� = true;
            Ordu.SetActive(true);
            StartCoroutine(WaiterBordu());

        }

    }
    IEnumerator Waiter()
    {
        if (PlayerPrefs.GetInt("B�l�mNum") < 1)
        {
            PlayerPrefs.SetInt("B�l�mNum", 1);
        }
        yield return new WaitForSeconds(2f);
        m1Panel.SetActive(true);
    }
    IEnumerator Waiter�apulcu()
    {
        yield return new WaitForSeconds(2f);
        Yaz�salPanel.SetActive(true);
        Yaz�salPanelTXT.text = "Etraf�n� uzay �apulcular� sard�. Bir zaman sonra liderleri seninle g�r��me talebinde bulunuyor.";
        b�l�mDURUM++; //5
    }
    IEnumerator WaiterBordu()
    {
        yield return new WaitForSeconds(2f);
        Yaz�salPanel.SetActive(true);
        Yaz�salPanelTXT.text = "D�nyaya do�ru olduk�a b�y�k bir sava� filosu ilerliyor. T�m filoyu tek ba��na yoketmen imkans�z gibi ama filonun tam ortas�nda kumanda gemisinin oldu�unu fark ediyorsun. Komuta gemisi bertaraf edilebilirse t�m filo da��labilir ve sava� ba�lamadan biter. Komuta gemisine ula�mak " +
            "i�in d��man hatlar�n� yararak ge�meyi denemelisin.";
        b�l�mDURUM++;//9
        m5Trigger.SetActive(false);
    }

    public void yAZISALpANELKAPA()
    {


        if (b�l�mDURUM == 2)
        {
            m2Panel.SetActive(true);
        }
        if (b�l�mDURUM == 3)
        {
            m2Panel2.SetActive(false);
            m2Panel.SetActive(false);
            m2Panel1.SetActive(false);
            Time.timeScale = 1;
            ShipG.kurtarM = 0;
            Application.LoadLevel("2");
        }
        if (b�l�mDURUM == 5)
        {
            m3Panel.SetActive(true);
        }
        if (b�l�mDURUM == 7)
        {
            m4Panel.SetActive(true);
        }
        if (b�l�mDURUM == 9) //orduya kar�� ilk sava� 
        {
            Time.timeScale = 1;
            ShipG.kurtarM = 0;
            Application.LoadLevel("5");

        }
        if (b�l�mDURUM == 10) //orduya kar�� ilk sava� kazan�ld� filo lideri ile g�r��me
        {
            m6Panel.SetActive(true);

        }
        if (b�l�mDURUM == 11) //bossFight
        {
            m6Panel2.SetActive(false);
            m6Panel1.SetActive(false);
            m6Panel.SetActive(false);
            Debug.Log("bossFight");
            ShipG.kurtarM = 0;
            Application.LoadLevel("6");

        }
        if(b�l�mDURUM == 12)
        {
            //oyun btmi� aga

            End.SetActive(true);
        }


        Yaz�salPanel.SetActive(false);
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
        Yaz�salPanel.SetActive(true);
        Yaz�salPanelTXT.text = "Y�netici bir �sl�kla etraf�na binlerce ki�iyi toplad�. Yenemeyece�in bir sava� oldu�unu fark ediyorsun ve gezengenden ka�mak i�in hemen Togg2222 ye atl�yorsun.";
        b�l�mDURUM++;//3
    }
    public void m2BTN21()
    {
        Yaz�salPanel.SetActive(true);
        Yaz�salPanelTXT.text = "Y�netici �ok garip birisi. Etraf�na yava� yava� toplanmaya ba�lad�lar ve bunun sonucunda sana sald�rmay� planlad�klar�n� anl�yorsun. Yenemeyece�in bir sava� oldu�unu fark ediyorsun ve gezengenden ka�mak i�in hemen Togg2222 ye atl�yorsun.";
        b�l�mDURUM++;//3
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
        Yaz�salPanel.SetActive(true);
        Yaz�salPanelTXT.text = "Tebrikler anime k�z�na kanmad�n. �imdi sald�rman�n tam s�ras�.";
        b�l�mDURUM++;//11
    }
    public void m6BTN21()
    {
        Yaz�salPanel.SetActive(true);
        Yaz�salPanelTXT.text = "Tebrikler anime k�z�na kanm�� gibi rol yapmak g�zel fikirdi. �imdi sald�rman�n tam s�ras�.";
        b�l�mDURUM++;//11
    }
    public void LevelOpen(int say�)
    {
        End.SetActive(false);

        b�l�mDURUM = say�;
        Application.LoadLevel(SceneManager.GetActiveScene().name);
       // Ba�lang��();
    }

    public void Ba�lang��BTNmetot()
    {
        if (Ba�lang�cDURUM == 1)
        {
            Ba�lang�cDURUM++;
            Ba�lang�cPanel.SetActive(true);
            Ba�lang��TXT.text = "Kontroller:\n\nHaritadayken:\nGitmek istedi�iniz gezenin �zerine t�klayarak ilerleyin. Esc ile oyunu durdurabilirsiniz.\n\nSava� Alan�nda:\nWASD veya ok tu�lar�yla hareket edebilir Space ile ate� edebilirsiniz. Esc ile oyunu durdurabilirsiniz.";
        }
        else if (Ba�lang�cDURUM == 2)
        {
            Ba�lang�cDURUM++;
            Ba�lang�cPanel.SetActive(true);
            Ba�lang��TXT.text = "Not1: Oyunu tam manas�yla deneyimlemeniz i�in sonuna dek gelmeniz tavsiye olunur.\n\nNot2: E�erki ge�emedi�iniz b�l�m olursa diye _Kurtar Beni_ butonunu ekledim. Bu buton her b�l�m i�in 5 kez �l�nd�kten sonra a��l�r ve b�l�m� pas ge�mek isterseniz kullanabilirsiniz.";
        }
        else if (Ba�lang�cDURUM == 3)
        {
            Ba�lang�cDURUM++;
            Ba�lang�cPanel.SetActive(true);
            Ba�lang��TXT.text = "G�revin:\n\nG�nl�k devriyeni yapmak �zere A3x54 gezegenine do�ru yola ��k.\n\n(Unutma ki geminin radar� ar�zal� sadece yak�ndaki nesneleri veya b�y�k gezegenleri g�rebilirsin.)";
        }
        else if (Ba�lang�cDURUM == 4)
        {
            Ba�lang�cPanel.SetActive(false);
        }
    }

}