using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCoches : MonoBehaviour
{
    //Waypoints
    public Transform[] m_Waypoints;
    //Velocidad
    public float m_CarSpeed = 0f;
    

    void Update()
    {
        if (transform.position != m_Waypoints[0].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_Waypoints[0].position, m_CarSpeed * PlayerBehaviour.instance.m_VelocidadProps * Time.deltaTime);
            
        }
        else
        {
            transform.position = m_Waypoints[1].position;
        }       
    }
}
