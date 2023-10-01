using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Button[] LevelBTNs;
    public GameObject[] QuestionsMarks;

    public GameObject KaanSc;
    public GameObject LevelsSC;
    public GameObject ContSC;
    void Start()
    {
        Application.targetFrameRate = 150;
        if (PlayerPrefs.GetInt("KaanSc") == 0)
        {
            PlayerPrefs.SetInt("KaanSc", 1);
            KaanSc.SetActive(true);


        }



        for (int i = 0; i < LevelBTNs.Length; i++)
        {
            if(i< PlayerPrefs.GetInt("BölümNum"))
            {
                LevelBTNs[i].interactable = true;
                QuestionsMarks[i].SetActive(false);
            }
            else
            {
                LevelBTNs[i].interactable = false;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DevamBTN(bool Onoff)
    {
        KaanSc.SetActive(Onoff);
    }
    public void LevelSc(bool Onoff)
    {
        LevelsSC.SetActive(Onoff);
    }
    public void ContSCBTN(bool Onoff)
    {
        ContSC.SetActive(Onoff);
    }
    public void ControllerChoose(int num)
    {
        PlayerPrefs.SetInt("ControlType", num);
    }
    public void levelBTNcODE(string levelname) //for levels
    {
        Time.timeScale = 1;
        Application.LoadLevel(levelname);
    }
    public void LevelOpen(int sayý)
    {
      //  End.SetActive(false);

        Ship.bölümDURUM = sayý;
        Application.LoadLevel("uzay");
        // Baþlangýç();
    }
}
