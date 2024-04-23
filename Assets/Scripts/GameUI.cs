using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject m_HUD;
    [SerializeField]
    public TextMeshProUGUI newRecordLabel;
    
    public GameObject crownImage;
   
    
    [SerializeField]
    public GameObject gameEndingScreen;
   
    [SerializeField]
    public TextMeshProUGUI textEnding;


    public static GameUI instance;
    public LevelBehaviour m_LevelBehaviour;
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
   

    public void Start()
    {
        m_LevelBehaviour.m_StepsCounter = PlayerPrefs.GetInt("Score", 0);
        m_Record = PlayerPrefs.GetInt("Record", 0);
        m_Coin = PlayerPrefs.GetInt("Monedas", 0);

        UpdateStepText();
    }

    public void Update()
    {
        PlayerPrefs.SetInt("Steps", m_LevelBehaviour.m_StepsCounter);
        PlayerPrefs.Save();

        if (m_LevelBehaviour.m_StepsCounter > m_Record)
        {
            m_NewRecord = true;
            m_Record = m_LevelBehaviour.m_StepsCounter;
            PlayerPrefs.SetInt("Record", m_Record);
            PlayerPrefs.Save();
        }
        PlayerPrefs.SetInt("Coins", m_Coin);
        PlayerPrefs.Save();
        UpdateStepText();
    }


    private void UpdateStepText()
    {
        m_StepsText.text = "Score: " + m_LevelBehaviour.m_StepsCounter;
        m_CoinText.text = "Coins: " + m_Coin;
    }
    
    public void GameEnding()
    {
        gameEndingScreen.SetActive(true);
        textEnding.text = "Coins: " + m_Coin + "\nSteps: " + m_LevelBehaviour.m_StepsCounter;
        m_HUD.SetActive(false);
        if (m_NewRecord)
        {
            newRecordLabel.text = "Record!: " + m_LevelBehaviour.m_StepsCounter;
            crownImage.SetActive(true);
        }
        else
        {
            newRecordLabel.text = "Record: " + m_LevelBehaviour.m_StepsCounter;
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
