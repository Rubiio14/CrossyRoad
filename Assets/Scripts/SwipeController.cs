using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{

    Vector3 m_ClickInicial;
    Vector3 m_AlSoltarClick;

    public float m_Offset = 100f;
    public float m_Duration = 1f;

    public GameObject m_Player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_ClickInicial = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            m_AlSoltarClick = Input.mousePosition;
            Vector3 m_Diferencia = m_AlSoltarClick - m_ClickInicial;
            Debug.Log(m_Diferencia);

            ///Si X es negativa, izq
            ///Si X es positiva, dch
            ///si y es negativa baja
            ///si y es positiva sube

            if (m_Diferencia.x < -m_Offset)
            {
                MoveTarget(-m_Player.GetComponent<Transform>().right);
            }
            if (m_Diferencia.y < -m_Offset)
            {
                MoveTarget(-m_Player.GetComponent<Transform>().forward);
            }
            if (m_Diferencia.x > m_Offset)
            {
                Debug.Log("Se ha movido hacia la dch");
                MoveTarget(m_Player.GetComponent<Transform>().right);

            }
            if (m_Diferencia.y > m_Offset)
            {
                Debug.Log("Se ha movido hacia arriba");
                MoveTarget(m_Player.GetComponent<Transform>().forward);
            }



        }
    }


    void MoveTarget(Vector3 m_Direction)
    {
        LeanTween.move(m_Player, m_Player.transform.position + m_Direction, m_Duration).setEase(LeanTweenType.easeOutQuad);
    }
}
