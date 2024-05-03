using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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


    public void Serpiente()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= m_Serpiente)
        {
            Debug.Log("Has Desbloqueado la Serpiente");
        }
        else
        {
            Debug.Log("No Tienes Suficientes Monedas");
        }
    }
    public void Reno()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= m_Reno)
        {
            Debug.Log("Has Desbloqueado la Serpiente");
        }
        else
        {
            Debug.Log("No Tienes Suficientes Monedas");
        }
    }
    public void Pajaro()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= m_Pajaro)
        {
            Debug.Log("Has Desbloqueado la Serpiente");
        }
        else
        {
            Debug.Log("No Tienes Suficientes Monedas");
        }
    }
    public void MonoEspecial()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= m_MonoEspecial)
        {
            Debug.Log("Has Desbloqueado la Serpiente");
        }
        else
        {
            Debug.Log("No Tienes Suficientes Monedas");
        }
    }

    public void Desierto()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= m_BloqueoDesierto)
        {
            Debug.Log("Has Desbloqueado la Serpiente");
        }
        else
        {
            Debug.Log("No Tienes Suficientes Monedas");
        }
    }
    public void Nieve()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= m_BloqueoNieve)
        {
            Debug.Log("Has Desbloqueado la Serpiente");
        }
        else
        {
            Debug.Log("No Tienes Suficientes Monedas");
        }
    }
    public void Candyland()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= m_BloqueoCandyLand)
        {
            Debug.Log("Has Desbloqueado la Serpiente");
        }
        else
        {
            Debug.Log("No Tienes Suficientes Monedas");
        }
    }
    public void Arcade()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= m_BloqueoArcade)
        {
            Debug.Log("Has Desbloqueado la Serpiente");
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
    }
}
