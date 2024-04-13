using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static SwipeController;

public class Movimiento : MonoBehaviour
{
    Vector3 m_ClickInicial;
    Vector3 m_AlSoltarClick;
    public float m_Offset = 100f;
    

    public PlayerBehaviour pb_PlayerBehaviour;
    public SwipeController m_SwipeController;

    [SerializeField] GameObject m_Player;
    [SerializeField] GameObject m_Prop;
    

    public float pb_Duration = 0.25f;
    public void Awake()
    {
        m_Prop = this.gameObject;
    }
    private void Update()
    {
        RaycastHit m_Hitinfo = PlayerBehaviour.m_RaycastDirection;
        if (Input.GetMouseButtonDown(0))
        {
            m_ClickInicial = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            m_AlSoltarClick = Input.mousePosition;
            Vector3 m_Diferencia = m_AlSoltarClick - m_ClickInicial;
            if (Mathf.Abs(m_Diferencia.magnitude) > m_Offset)
            {
                m_Diferencia = m_Diferencia.normalized;
                m_Diferencia.z = m_Diferencia.y;

                if (Mathf.Abs(m_Diferencia.x) > Mathf.Abs(m_Diferencia.z))
                {
                    m_Diferencia.z = 0.0f;
                }
                else
                {
                    m_Diferencia.x = 0.0f;
                }

                m_Diferencia.y = 0.0f;
                //Pararlo si el eprsonaje choca
                if (Physics.Raycast(PlayerBehaviour.instance.transform.position + new Vector3(0, 1f, 0), m_Diferencia, out m_Hitinfo, 1f))
                {
                    if (m_Hitinfo.collider.tag != "ProceduralTerrain")
                    {
                        if (m_Diferencia.z != 0)
                        {
                            m_Diferencia.z = 0;
                        }
                    }


                }
                //Movimiento hacia adelante
                if (m_Diferencia.normalized.z >= 0)
                {
                    LeanTween.move(m_Prop, m_Prop.transform.position + new Vector3(0, 0, -m_Diferencia.normalized.z), 0.25f).setEase(LeanTweenType.easeOutQuad);
                }
                //Movimiento hacia atrás
                if (m_Diferencia.normalized.z < 0 && PlayerBehaviour.instance.m_StepsBack < 4)
                {
                    LeanTween.move(m_Prop, m_Prop.transform.position + new Vector3(0, 0, -m_Diferencia.normalized.z), 0.25f).setEase(LeanTweenType.easeOutQuad);
                }
                
            }
        }
        
    }
}

/*
    private void Update()
    {
        // Mover el objeto hacia atrás continuamente
        MoveTarget();
    }

    void MoveTarget()
    {
        // Mover el objeto en dirección negativa del eje Z
        transform.position -= Vector3.forward * Time.deltaTime;
    }    
    */
