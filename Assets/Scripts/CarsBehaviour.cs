using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SwipeController;

public class CarsBehaviour : MonoBehaviour
{
    public EnemiesGenerator m_EnemiesGenerator;
    public float m_CarSpeed;


    private void Update()
    {
        
        transform.position += transform.forward * m_CarSpeed * Time.deltaTime;
        
    }

    public void OnBecameInvisible()
    {
        m_EnemiesGenerator.RecycleEnemy(this.gameObject);
    }
}
