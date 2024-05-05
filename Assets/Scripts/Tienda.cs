using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;


public class Tienda : MonoBehaviour
{
    //Bloqueos de zona
    public int m_BloqueoDesierto = 50;
    public int m_BloqueoNieve = 100;
    public int m_BloqueoCandyLand = 200;
    public int m_BloqueoArcade = 300;

    //Bloqueos Animales
    public int m_Serpiente = 50;
    public int m_Reno = 100;
    public int m_Pajaro = 200;
    public int m_MonoEspecial = 300;

    //Audio
    public AudioSource m_ButtonSound;

    //Canvas
    [SerializeField] GameObject m_Escena;
    [SerializeField] TextMeshProUGUI m_CoinText;
    [SerializeField] TextMeshProUGUI m_CoinText_Portait;
    public GameObject m_Tienda;
    public GameObject m_Tienda_Portait;

    public void Update()
    {
        if (Screen.width > Screen.height)
        {
            m_Tienda.SetActive(true);
            m_Tienda_Portait.SetActive(false);
            m_CoinText.gameObject.SetActive(true);
            m_CoinText_Portait.gameObject.SetActive(false);
            

        }
        else
        {
            m_Tienda.SetActive(false);
            m_Tienda_Portait.SetActive(true);
            m_CoinText_Portait.gameObject.SetActive(true);
            m_CoinText.gameObject.SetActive(false);
            

        }
    }
    public void Serpiente()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= m_Serpiente && PlayerPrefs.GetInt("IsSerpiente") == 0)
        {
            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - m_Serpiente);
            m_CoinText.text = "Monedas: " + PlayerPrefs.GetInt("TotalCoins").ToString();
            Debug.Log("Has Desbloqueado la Serpiente");
            PlayerPrefs.SetInt("IsSerpiente", 1);
        }
        else if (PlayerPrefs.GetInt("IsSerpiente") == 1)
        {
            Debug.Log("Ya tienes éste animal");
        }
        else
        {
            Debug.Log("No Tienes Suficientes Monedas");
        }
    }
    public void Reno()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= m_Reno && PlayerPrefs.GetInt("IsReno") == 0)
        {
            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - m_Reno);
            m_CoinText.text = "Monedas: " + PlayerPrefs.GetInt("TotalCoins").ToString();
            Debug.Log("Has Desbloqueado el reno");
            PlayerPrefs.SetInt("IsReno", 1);
        }
        else if (PlayerPrefs.GetInt("IsReno") == 1)
        {
            Debug.Log("Ya tienes éste animal");
        }
        else
        {
            Debug.Log("No Tienes Suficientes Monedas");
        }
    }
    public void Pajaro()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= m_Pajaro && PlayerPrefs.GetInt("IsPajaro") == 0)
        {
            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - m_Pajaro);
            m_CoinText.text = "Monedas: " + PlayerPrefs.GetInt("TotalCoins").ToString();
            Debug.Log("Has Desbloqueado el pájaro");
            PlayerPrefs.SetInt("IsPajaro", 1);
        }
        else if (PlayerPrefs.GetInt("IsPajaro") == 1)
        {
            Debug.Log("Ya tienes éste animal");
        }
        else
        {
            Debug.Log("No Tienes Suficientes Monedas");
        }
    }
    public void MonoEspecial()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= m_MonoEspecial && PlayerPrefs.GetInt("IsMonoEspecial") == 0)
        {
            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - m_MonoEspecial);
            m_CoinText.text = "Monedas: " + PlayerPrefs.GetInt("TotalCoins").ToString();
            Debug.Log("Has Desbloqueado el mono especial");
            PlayerPrefs.SetInt("IsMonoEspecial", 1);
        }
        else if (PlayerPrefs.GetInt("IsMonoEspecial") == 1)
        {
            Debug.Log("Ya tienes éste animal");
        }
        else
        {
            Debug.Log("No Tienes Suficientes Monedas");
        }
    }

    public void Desierto()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= m_BloqueoDesierto && PlayerPrefs.GetInt("IsDesierto") == 0)
        {
            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - m_BloqueoDesierto);
            m_CoinText.text = "Monedas: " + PlayerPrefs.GetInt("TotalCoins").ToString();
            Debug.Log("Has Desbloqueado el desierto");
            PlayerPrefs.SetInt("IsDesierto", 1);
        }
        else if (PlayerPrefs.GetInt("IsDesierto") == 1)
        {
            Debug.Log("Ya tienes éste Nivel");
        }
        else
        {
            Debug.Log("No Tienes Suficientes Monedas");
        }
    }
    public void Nieve()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= m_BloqueoNieve && PlayerPrefs.GetInt("IsNieve") == 0)
        {
            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - m_BloqueoNieve);
            m_CoinText.text = "Monedas: " + PlayerPrefs.GetInt("TotalCoins").ToString();
            Debug.Log("Has Desbloqueado la nieve");
        PlayerPrefs.SetInt("IsNieve", 1);
        }
        else if (PlayerPrefs.GetInt("IsNieve") == 1)
        {
            Debug.Log("Ya tienes éste Nivel");
        }
        else
        {
            Debug.Log("No Tienes Suficientes Monedas");
        }
    }
    public void Candyland()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= m_BloqueoCandyLand && PlayerPrefs.GetInt("IsCandyLand") == 0)
        {
            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - m_BloqueoCandyLand);
            m_CoinText.text = "Monedas: " + PlayerPrefs.GetInt("TotalCoins").ToString();
            Debug.Log("Has Desbloqueado CandyLand");
            PlayerPrefs.SetInt("IsCandyLand", 1);
        }
        else if (PlayerPrefs.GetInt("IsCandyLand") == 1)
        {
            Debug.Log("Ya tienes éste Nivel");
        }
        else
        {
            Debug.Log("No Tienes Suficientes Monedas");
        }
    }
    public void Arcade()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= m_BloqueoArcade && PlayerPrefs.GetInt("IsArcade") == 0)
        {
            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - m_BloqueoArcade);
            m_CoinText.text = "Monedas: " + PlayerPrefs.GetInt("TotalCoins").ToString();
            Debug.Log("Has Desbloqueado el modo Arcade");
            PlayerPrefs.SetInt("IsArcade", 1);
        }
        else if (PlayerPrefs.GetInt("IsArcade") == 1)
        {
            Debug.Log("Ya tienes éste Nivel");
        }
        else
        {
            Debug.Log("No Tienes Suficientes Monedas");
        }
    }

    public void ContinueButton()
    {
        m_Escena.SetActive(true);
        m_ButtonSound.Play();
        this.gameObject.SetActive(false);
        m_CoinText.gameObject.SetActive(false);
        m_CoinText_Portait.gameObject.SetActive(false);
    }

    public void sumarMonedas()
    {
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + 100);
        m_CoinText.text = "Monedas: " + PlayerPrefs.GetInt("TotalCoins").ToString();
    }
}
