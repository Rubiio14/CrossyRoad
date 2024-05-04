using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public CanvasGroup m_CanvasGroup;

    public GameObject m_HUD;
    [SerializeField]
    public TextMeshProUGUI newRecordLabel;
    
    public GameObject crownImage;
   
    
    [SerializeField]
    public GameObject gameEndingScreen;
   
    [SerializeField]
    public TextMeshProUGUI textEnding;


    public static GameUI instance;
    public bool m_NewRecord = false;

    //Audio
    public AudioSource m_ButtonSound;
    public AudioSource m_MenuPop;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

    }


    [SerializeField] public TextMeshProUGUI m_StepsText;
    [SerializeField] public TextMeshProUGUI m_CoinText;
    private int m_TotalCoins = 0;
    private int m_Record = 0;
    public int m_Coin = 0;
    public int m_Score = 0;
    public string m_MonedaNivel = "Plátanos: ";


    public void Start()
    {
        Debug.Log("Antes de sumar" + m_TotalCoins);
        m_TotalCoins = PlayerPrefs.GetInt("TotalCoins", m_TotalCoins);
        m_Score = PlayerPrefs.GetInt("Score", LevelBehaviour.instance.m_StepsCounter);
        m_Record = PlayerPrefs.GetInt("Record", LevelBehaviour.instance.m_Record);
        m_Coin = PlayerPrefs.GetInt("Plátanos", PlayerBehaviour.instance.m_Coin);
        LandsCapeUpdateStepText();
        LandsCapeUpdateCoinsText();
    }


    public void LandsCapeUpdateStepText()
    {
        m_StepsText.text = "Score: " + LevelBehaviour.instance.m_StepsCounter;
    }
    public void LandsCapeUpdateCoinsText()
    {
        m_CoinText.text = m_MonedaNivel + PlayerBehaviour.instance.m_Coin;
    }

    public void GameEnding()
    {
        
        //Set TotalCoins
        PlayerPrefs.SetInt("TotalCoins", m_TotalCoins + PlayerBehaviour.instance.m_Coin);
        PlayerPrefs.Save();
        Debug.Log("Después de sumar" + m_TotalCoins);
        //Set record
        if (LevelBehaviour.instance.m_StepsCounter > instance.m_Record)
        {
            m_NewRecord = true;
            m_Record = LevelBehaviour.instance.m_StepsCounter;
            PlayerPrefs.SetInt("Record", m_Record);
            PlayerPrefs.Save();
        }

        gameEndingScreen.SetActive(true);
        m_MenuPop.Play();
        textEnding.text = m_MonedaNivel + PlayerBehaviour.instance.m_Coin + "\nSteps: " + LevelBehaviour.instance.m_StepsCounter;
        m_HUD.SetActive(false);
        if (m_NewRecord)
        {
            newRecordLabel.text = "Record!: " + LevelBehaviour.instance.m_StepsCounter;
            crownImage.SetActive(true);
        }
        else
        {
            newRecordLabel.text = "Record: " + m_Record;
        }
    }

    public void ResetButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        m_ButtonSound.Play();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
        m_ButtonSound.Play();
    }
}
