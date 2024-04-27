using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI_Portait : MonoBehaviour
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


    public static GameUI_Portait instance;
    public bool m_NewRecord = false;

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


    [SerializeField] TextMeshProUGUI m_StepsText;
    [SerializeField] TextMeshProUGUI m_CoinText;

    private int m_Record = 0;
    public int m_Coin = 0;
    public int m_Score = 0;

    public void Start()
    {
        m_Score = PlayerPrefs.GetInt("Score", LevelBehaviour.instance.m_StepsCounter);
        m_Record = PlayerPrefs.GetInt("Record", LevelBehaviour.instance.m_Record);
        m_Coin = PlayerPrefs.GetInt("Monedas", PlayerBehaviour.instance.m_Coin);
        UpdateStepText();
    }

    public void Update()
    {
        PlayerPrefs.SetInt("Steps", LevelBehaviour.instance.m_StepsCounter);
        PlayerPrefs.Save();

        if (LevelBehaviour.instance.m_StepsCounter > m_Record)
        {
            m_NewRecord = true;
            m_Record = LevelBehaviour.instance.m_StepsCounter;
            PlayerPrefs.SetInt("Record", m_Record);
            PlayerPrefs.Save();
        }
        PlayerPrefs.SetInt("Coins", PlayerBehaviour.instance.m_Coin);
        PlayerPrefs.Save();
        UpdateStepText();
    }


    private void UpdateStepText()
    {
        m_StepsText.text = "Score: " + LevelBehaviour.instance.m_StepsCounter;
        m_CoinText.text = "Coins: " + PlayerBehaviour.instance.m_Coin;
    }
    
    public void GameEnding()
    {
        gameEndingScreen.SetActive(true);
        textEnding.text = "Coins: " + PlayerBehaviour.instance.m_Coin + "\nSteps: " + LevelBehaviour.instance.m_StepsCounter;
        m_HUD.SetActive(false);
        if (m_NewRecord)
        {
            newRecordLabel.text = "Record " + LevelBehaviour.instance.m_StepsCounter;
            crownImage.SetActive(true);
        }
        else
        {
            newRecordLabel.text = "Record " + LevelBehaviour.instance.m_StepsCounter;
        }
    }

    public void ResetButton()
    {
        SceneManager.LoadScene(0);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
