using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject PauseSc;
    public GameObject OptionsSc;

    public GameObject SAHNE1;
    public GameObject SAHNE2;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScBTN(true);
        }
    }

    public void PauseScBTN(bool AÇKAPA)
    {
        if (AÇKAPA)
        {
            Time.timeScale = 0;
            PauseSc.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            PauseSc.SetActive(false);
        }

    }
    public void QuiqBTN()
    {
     //   Application.Quit();
        Time.timeScale = 1;
        Application.LoadLevel("MENU");
    }
    public void levelBTNcODE(string levelname) //for levels
    {
        Time.timeScale = 1;
        Application.LoadLevel(levelname);
    }
    public void OptScbtn(bool Açkapa)
    {
        OptionsSc.SetActive(Açkapa);
    }
    public void DevamBTN()
    {
        SAHNE2.SetActive(true);
        SAHNE1.SetActive(false);
    }
}
