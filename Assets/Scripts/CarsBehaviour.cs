using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsBehaviour : MonoBehaviour
{
    public LevelPedazo m_Levelpedazo;
    //public EnemiesGenerator m_EnemiesGenerator;
    public float m_CarSpeed;
    public GameObject m_WaypointTarget;


    private void Update()
    {

        Vector3 m_WaypointDirection = (this.m_WaypointTarget.transform.position - this.transform.position).normalized;
        this.transform.position += m_WaypointDirection * m_CarSpeed * Time.deltaTime;
    }
    /*
    public void OnBecameInvisible()
    {
        m_EnemiesGenerator.RecycleEnemy(this.gameObject);
    }
    */

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ReturnWaypoint"))
        {
            //m_EnemiesGenerator.RecycleEnemy(this.gameObject);

        }

    }
}
