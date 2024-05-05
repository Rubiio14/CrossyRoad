using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    //Audio
    public AudioSource m_ButtonSound;
    //Canvas 
    public GameObject m_Niveles;
    public GameObject m_Niveles_Portait;
    public GameObject m_Tienda;
    public GameObject m_Tienda_Portait;
    [SerializeField] TextMeshProUGUI m_CoinText;
    [SerializeField] TextMeshProUGUI m_CoinText_Portait;

    private void Start()
    {
        m_CoinText.text = "Monedas: " + PlayerPrefs.GetInt("TotalCoins").ToString();
        PlayerPrefs.SetInt("IsSerpiente", PlayerPrefs.GetInt("IsSerpiente"));
        PlayerPrefs.SetInt("IsReno", PlayerPrefs.GetInt("IsReno"));
        PlayerPrefs.SetInt("IsPajaro", PlayerPrefs.GetInt("IsPajaro"));
        PlayerPrefs.SetInt("IsMonoEspecial", PlayerPrefs.GetInt("IsMonoEspacial"));
        PlayerPrefs.SetInt("IsDesierto", PlayerPrefs.GetInt("IsDesierto"));
        PlayerPrefs.SetInt("IsNieve", PlayerPrefs.GetInt("IsNieve"));
        PlayerPrefs.SetInt("IsCandyLand", PlayerPrefs.GetInt("IsCandyLand"));
        PlayerPrefs.SetInt("IsArcade", PlayerPrefs.GetInt("IsArcade"));
    }
    public void ExitButton()
    {  
        Application.Quit();
        m_ButtonSound.Play();    
    }

    public void NivelesButton()
    {
        if (Screen.width > Screen.height)
        {
            m_Niveles.SetActive(true);
            m_CoinText.gameObject.SetActive(true);
            m_CoinText_Portait.gameObject.SetActive(false);
            m_ButtonSound.Play();
        }
        else
        {
            m_Niveles_Portait.SetActive(true);
            m_CoinText.gameObject.SetActive(false);
            m_CoinText_Portait.gameObject.SetActive(true);
            m_ButtonSound.Play();
        }
    }

    public void TiendaButton()
    {
        if (Screen.width > Screen.height)
        {
            m_Tienda.SetActive(true);
            m_CoinText.gameObject.SetActive(true);
            m_ButtonSound.Play();
        }
        else
        {
            m_Tienda_Portait.SetActive(true);
            m_CoinText.gameObject.SetActive(true);
            m_ButtonSound.Play();
        }
    }
}   
