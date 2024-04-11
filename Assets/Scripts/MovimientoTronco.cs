using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTronco : MonoBehaviour
{
    public float m_Speed = 2f;
    void Update()
    {
        Vector3 direction = (ObjectPoolTroncos.instance.m_Despawn_Point.transform.position - transform.position).normalized;

        
        float distanceToMove = m_Speed * Time.deltaTime;

        // Mueve el objeto hacia el punto objetivo
        transform.Translate(direction * distanceToMove);

        // Si el objeto ha llegado al punto objetivo, desactiva este script
        if (Vector3.Distance(transform.position, ObjectPoolTroncos.instance.m_Despawn_Point.transform.position) < 0.1f)
        {
            ObjectPoolTroncos.instance.RecycleObject(gameObject);
        }
    }
}
