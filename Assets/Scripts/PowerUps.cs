using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    //ActivarProps
    public bool m_DobleMonedas = false;
    public bool m_SaltoLargo = false;
    public bool m_Invulnerabilidad = false;
    public bool m_StopProps = false;
    public bool m_MonoSentado = false;
    public bool m_Iman = false;

    //Iman
    public int m_RangoAtraccion = 10;
    public float m_VelocidadAtraccion = 1.5f;

    //StopProps
    public int m_Pasos = 10;
    public float m_SlowSpeedProps = 0.5f;
    public float m_NormalSpeedProps = 1f;
    public float m_RestoreSpeedTime = 5f;

    //MonoSentado
    public float m_TimeToSit = 10f;

    //Invulnerabilidad
    public int m_Lifes = 2;

    //SaltoLargo
    public int m_CasillasSalto = 2;

    //DobleMoneda
    public int m_CoinValue = 2;

    //Canvas
    public GameObject m_CanvasCartasLandscape;
    public List<GameObject> m_BotonesLandscape;

    public GameObject m_CanvasCartasPortait;
    public List<GameObject> m_BotonesPortait;

    //Audio
    public AudioSource m_PowerUpSound;

    //VFX
    public ParticleSystem m_PowerUpParticle;

    public static PowerUps instance;
    void Awake()
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

    private void Start()
    {
        SwipeController.instance.enabled = false;

        int count = m_BotonesLandscape.Count;

        int m_RandomIndex_1 = Random.Range(0, count);
        int m_RandomIndex_2 = Random.Range(0, count - 1);

        // Ajusta el segundo índice si es igual al primero
        if (m_RandomIndex_2 >= m_RandomIndex_1)
            m_RandomIndex_2++;

        

        // Landscape
        m_BotonesLandscape[m_RandomIndex_1].SetActive(true);
        m_BotonesLandscape[m_RandomIndex_2].SetActive(true);

        // Portrait
        m_BotonesPortait[m_RandomIndex_1].SetActive(true);
        m_BotonesPortait[m_RandomIndex_2].SetActive(true);
    }
    void LateUpdate()
    {
        if (m_Iman == true)
        {
            Iman();
        }
    } 

    public void StopProps()
    {
        if (LevelBehaviour.instance.m_StepsCounter % m_Pasos == 0 && LevelBehaviour.instance.m_StepsCounter != 0)
        {
            PlayerBehaviour.instance.m_VelocidadProps = m_SlowSpeedProps;
            StartCoroutine(RestorePropsSpeed());
        }
    }

    public void Iman()
    {
        GameObject[] m_Monedas = GameObject.FindGameObjectsWithTag("Coin");

        // Iterar sobre cada moneda y atraerla hacia el jugador si está dentro del rango
        foreach (GameObject m_Moneda in m_Monedas)
        {
            // Calcular la distancia entre la moneda y el jugador
            float m_Distancia = Vector3.Distance(PlayerBehaviour.instance.transform.position, m_Moneda.transform.position);

            // Si la moneda está dentro del rango
            if (m_Distancia <= m_RangoAtraccion)
            {
                // Calcular la dirección hacia el jugador
                Vector3 m_Direccion = (PlayerBehaviour.instance.transform.position - m_Moneda.transform.position).normalized;

                // Mover la moneda hacia el jugador con una cierta velocidad
                m_Moneda.transform.position += m_Direccion * m_VelocidadAtraccion * Time.deltaTime;
            }
        }
    }
    public void MonoSentado()
    {
        StartCoroutine(MonoSentadoTimer());
    }
    void Invulnerabilidad()
    {
        PlayerBehaviour.instance.m_Invulnerabilidad = m_Lifes;
    }
    void DobleMonedas()
    {
        PlayerBehaviour.instance.m_ValorMoneda = m_CoinValue;
    }

    void SaltoLargo()
    {
        LevelBehaviour.instance.m_PowerUpSalto = m_CasillasSalto;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (m_DobleMonedas == true)
            {
                DobleMonedas();
                m_PowerUpParticle.Stop();
            }
            if (m_SaltoLargo == true)
            {
                SaltoLargo();
                m_PowerUpParticle.Stop();
            }
            if (m_Invulnerabilidad == true)
            {
                Invulnerabilidad();
                m_PowerUpParticle.Stop();
            }
            if (m_Iman == true)
            {
                Iman();
                m_PowerUpParticle.Stop();
            }
        }
    }

    public void DobleMonedasActive()
    {
        m_DobleMonedas = true;
        m_CanvasCartasLandscape.SetActive(false);
        m_CanvasCartasPortait.SetActive(false);
        ScreenOrientationManager.instance.m_Selected = true;
        SwipeController.instance.enabled = true;
        m_PowerUpSound.Play();
        m_PowerUpParticle.Play();
        
    }
    public void SaltoLargoActive()
    {
        m_SaltoLargo = true;
        m_CanvasCartasLandscape.SetActive(false);
        m_CanvasCartasPortait.SetActive(false);
        ScreenOrientationManager.instance.m_Selected = true;
        SwipeController.instance.enabled = true;
        m_PowerUpSound.Play();
        m_PowerUpParticle.Play();
        
    }
    public void InvulnerabilidadActive()
    {
        m_Invulnerabilidad = true;
        m_CanvasCartasLandscape.SetActive(false);
        m_CanvasCartasPortait.SetActive(false);
        ScreenOrientationManager.instance.m_Selected = true;
        SwipeController.instance.enabled = true;
        m_PowerUpSound.Play();
        m_PowerUpParticle.Play();
        
    }
    public void StopPropsActive()
    {
        m_StopProps = true;
        m_CanvasCartasLandscape.SetActive(false);
        m_CanvasCartasPortait.SetActive(false);
        ScreenOrientationManager.instance.m_Selected = true;
        SwipeController.instance.enabled = true;
        m_PowerUpSound.Play();
        m_PowerUpParticle.Play();
        
    }
    public void MonoSentadoActive()
    {
        m_MonoSentado = true;
        m_CanvasCartasLandscape.SetActive(false);
        m_CanvasCartasPortait.SetActive(false);
        ScreenOrientationManager.instance.m_Selected = true;
        SwipeController.instance.enabled = true;
        m_PowerUpSound.Play();
        m_PowerUpParticle.Play();
        
    }
    public void ImanActive()
    {
        m_Iman = true;
        m_CanvasCartasLandscape.SetActive(false);
        m_CanvasCartasPortait.SetActive(false);
        ScreenOrientationManager.instance.m_Selected = true;
        SwipeController.instance.enabled = true;
        m_PowerUpSound.Play();
        m_PowerUpParticle.Play();
        
    }


    IEnumerator RestorePropsSpeed()
    {
        yield return new WaitForSeconds(m_RestoreSpeedTime);
        PlayerBehaviour.instance.m_VelocidadProps = m_NormalSpeedProps;
    }
    IEnumerator MonoSentadoTimer()
    {
        PlayerBehaviour.instance.anim.SetBool("IsSit", false);
        yield return new WaitForSeconds(m_TimeToSit);
        PlayerBehaviour.instance.anim.SetBool("IsSit", true);

    }

}
