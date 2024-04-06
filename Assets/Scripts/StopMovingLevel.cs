using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovingLevel : MonoBehaviour
{
    public NuevoPropsGenerator m_NuevoPropsGenerator;

    private void Start()
    {
    
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Prop"))
        {
            m_NuevoPropsGenerator.RecycleObject(collision.gameObject);
            Debug.Log(collision.gameObject);
        }
    }
}