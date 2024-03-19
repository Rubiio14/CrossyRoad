using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StopMovingLevel : MonoBehaviour
{
    public LevelPedazo m_LevelPedazo;
    private void Start()
    {
        
        m_LevelPedazo = GameObject.FindObjectOfType<LevelPedazo>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BackSpawnProps")
        {
            Debug.Log("No se mueve");
            GameObject m_Variable = m_LevelPedazo.gameObject;
            m_Variable.SetActive(false);
        }
    }
}
