using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTroncos : MonoBehaviour
{
    //Waypoints
    public Transform[] m_Waypoints;
    //Velocidad
    public float m_LogSpeed = 0f;


    void Update()
    {
        if (transform.position != m_Waypoints[0].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_Waypoints[0].position, m_LogSpeed * PlayerBehaviour.instance.m_VelocidadProps * Time.deltaTime);           
        }
        else
        {
            transform.position = m_Waypoints[1].position;
        }
    }

    /// <summary>
    /// Hace al jugador hijo de los troncos cuadnoo entra, cuando sale se quita el parent 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
            float m_Center = transform.position.z;

            

            Vector3 m_PlayerPosition = collision.transform.position;
            m_PlayerPosition.z = m_Center;
            collision.transform.position = m_PlayerPosition;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);      
        }
    }
}
