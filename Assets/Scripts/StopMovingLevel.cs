using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
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
        if (collision.gameObject.CompareTag("BackSpawnProps"))
        {
            Debug.Log("No se mueve");
            m_LevelPedazo.gameObject.SetActive(false);
        }
    }
}