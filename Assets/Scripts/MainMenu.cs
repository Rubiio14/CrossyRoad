using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //Audio
    public AudioSource m_ButtonSound;
    //Canvas 
    public GameObject m_Niveles;
    public GameObject m_Tienda;

    public void ExitButton()
    {  
        Application.Quit();
        m_ButtonSound.Play();    
    }

    public void NivelesButton()
    {
        m_Niveles.SetActive(true);
        this.gameObject.SetActive(false);
        m_ButtonSound.Play();
    }

    public void TiendaButton()
    {
        m_Tienda.SetActive(true);
        m_ButtonSound.Play();
    }
}   
