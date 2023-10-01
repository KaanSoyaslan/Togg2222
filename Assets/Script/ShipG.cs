using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class ShipG : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    private bool isShooting;
    public Transform shootPos1;
    public Transform shootPos2;
    public Transform shootPos3;
    public Transform shootPos4;
    public Transform shootPos5;
    public Transform shootPos6;
    public Transform shootPos7;
    public Transform shootPos8;
    public Transform shootPos9;

    public GameObject bullet;

    public float bulletSpeed;
    public float bulletWait;

    public int PlayerHealth;

    public SpriteRenderer spriteRenderer;
    public Image spriteRendererforPANEL;
    public Sprite[] PlayerSprites;
    public Color[] ShipStatusTXTColors;
    public string[] ShipStatusTXTstrings;
    public TMP_Text ShipStatusTXT;


    public Sprite[] WindowS;
    public Image WindowFoRdamage;

    public GameObject PauseSc;
    public GameObject OptionsSc;
    public GameObject DeadSc;
    public GameObject WinSc;

    public Button KurtarBTN;
    public TMP_Text KalanKurtarmaTXT;
    public static int kurtarM;


    public JoyStick movementJoystick;
    bool Mobile;

    public GameObject Joystick;
    public GameObject Buttons;

    void Start()
    {
        Application.targetFrameRate = 150;
        Cursor.visible = false;
        Time.timeScale = 1;

        if(PlayerPrefs.GetInt("ControlType") == 0)
        {
            Buttons.SetActive(true);
            Joystick.SetActive(false);
            Mobile = false;
        }
        else
        {
            Buttons.SetActive(false);
            Joystick.SetActive(true);
            Mobile = true;
        }
    }

    void Update()
    {
        
       
        if (Mobile)
        {
            Movement2();
        }
        else
        {
            Movement();
        }
       

        if ((Input.touchCount != 0|| Input.GetKey(KeyCode.Space) )&& isShooting == false)
        {
            StartCoroutine(Shoot());
        }
        if (PlayerHealth < 7)
        {
            spriteRenderer.sprite = PlayerSprites[PlayerHealth];
            spriteRendererforPANEL.sprite = PlayerSprites[PlayerHealth];
            WindowFoRdamage.sprite = WindowS[PlayerHealth];
            ShipStatusTXT.color = ShipStatusTXTColors[PlayerHealth];
            ShipStatusTXT.text = ShipStatusTXTstrings[PlayerHealth];
        }
      


        if(kurtarM < 4)
        {
            KurtarBTN.interactable = false;
            KalanKurtarmaTXT.text = (4 - kurtarM).ToString();
        }
        else
        {
            KalanKurtarmaTXT.text = ""; 
            KurtarBTN.interactable = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScBTN(true);
        }
    }
    private void Movement()
    {
      var deltaX = CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * speed;
   //   var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
  
        var deltaY = CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * speed;
       // var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;



        var newXpos = transform.position.x + deltaX;
        var newYpos = transform.position.y + deltaY;

        transform.position = new Vector2(newXpos, newYpos);
    }
    private void Movement2()
    {
     //   var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var deltaX = movementJoystick.joystickVec.x * Time.deltaTime * speed;
     //   var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        var deltaY = movementJoystick.joystickVec.y * Time.deltaTime * speed;


        var newXpos = transform.position.x + deltaX;
        var newYpos = transform.position.y + deltaY;

        transform.position = new Vector2(newXpos, newYpos);
    }

    IEnumerator Shoot()
    {
        isShooting = true;
        SoundManager.PlaySound("PlayerBullet");
        GameObject newBullet1 = Instantiate(bullet, shootPos1.position, Quaternion.identity);
        newBullet1.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, bulletSpeed * Time.fixedDeltaTime);
        GameObject newBullet2 = Instantiate(bullet, shootPos2.position, Quaternion.identity);
        newBullet2.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.8f, bulletSpeed * Time.fixedDeltaTime);
        GameObject newBullet3 = Instantiate(bullet, shootPos3.position, Quaternion.identity);
        newBullet3.GetComponent<Rigidbody2D>().velocity = new Vector2(0.8f, bulletSpeed * Time.fixedDeltaTime);
        GameObject newBullet4 = Instantiate(bullet, shootPos4.position, Quaternion.identity);
        newBullet4.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, bulletSpeed * Time.fixedDeltaTime);
        GameObject newBullet5 = Instantiate(bullet, shootPos5.position, Quaternion.identity);
        newBullet5.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.8f, bulletSpeed * Time.fixedDeltaTime);
        GameObject newBullet6 = Instantiate(bullet, shootPos6.position, Quaternion.identity);
        newBullet6.GetComponent<Rigidbody2D>().velocity = new Vector2(0.8f, bulletSpeed * Time.fixedDeltaTime);
        GameObject newBullet7 = Instantiate(bullet, shootPos7.position, Quaternion.identity);
        newBullet7.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, bulletSpeed * Time.fixedDeltaTime);
        GameObject newBullet8 = Instantiate(bullet, shootPos8.position, Quaternion.identity);
        newBullet8.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.8f, bulletSpeed * Time.fixedDeltaTime);
        GameObject newBullet9 = Instantiate(bullet, shootPos9.position, Quaternion.identity);
        newBullet9.GetComponent<Rigidbody2D>().velocity = new Vector2(0.8f, bulletSpeed * Time.fixedDeltaTime);

        yield return new WaitForSeconds(bulletWait);
        isShooting = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("enemy")|| other.CompareTag("boss"))
        {
            SoundManager.PlaySound("EnemyBullet0");
            if (PlayerHealth < 6)
            {
                PlayerHealth++;
            }
            else
            {
                Cursor.visible = true;
                Time.timeScale = 0;
                DeadSc.SetActive(true);
                Debug.Log("öldünm");
            }
           


            //if (PlayerHealth <= 2)
            //{
            //  ==  spriteRenderer.sprite = Sprite2;
            //}
            //if (PlayerHealth <= 1)
            //{
            // ==   spriteRenderer.sprite = Sprite3;
            //}
            //if (PlayerHealth <= 0)
            //{
              
            //    //öldük
            //        ////  SoundManager.PlaySound("Explosion1");
            //        //Instantiate(explode, transform.position, Quaternion.identity);
            //        //Destroy(gameObject);

                
            //}
            


        }
    }
    public void PauseScBTN(bool AÇKAPA)
    {
        if (AÇKAPA)
        {
            Cursor.visible = true;
            Time.timeScale = 0; 
            PauseSc.SetActive(true);
        }
        else
        {
            Cursor.visible = false;
            Time.timeScale = 1;
            PauseSc.SetActive(false);
        }
       
    }
    public void QuiqBTN()
    {
        //    Application.Quit();
        Time.timeScale = 1;
        Application.LoadLevel("MENU");
    }
    public void levelBTNcODE(string levelname)
    {
        Time.timeScale = 1;
        Application.LoadLevel(levelname);
    }
    public void Restart()
    {
        kurtarM++;
        Time.timeScale = 1;
        Application.LoadLevel(SceneManager.GetActiveScene().name);
    }
    
    public void OptScbtn(bool Açkapa)
    {
        OptionsSc.SetActive(Açkapa);
    }
    public void KurtarBTNmetot()
    {
        WinSc.SetActive(true);
        Ship.bölümDURUM++;
    }

}
