using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneratorManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] m_Terrain;
    public int m_Nterrain;

    void Start()
    {
       ObjectPool.PreLoad(m_Terrain[0], m_Nterrain);
        //Pedir 3 trozos

    }


    void NewLevelZone()
    {
        //Pide a la pool
        GameObject m_Terrain_2 = ObjectPool.GetObject(m_Terrain[0]);
        m_Terrain_2.transform.position = m_Terrain[0].transform.position + Vector3.forward * 2;
        //Lo cocoloca
    }
  
}


/*
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject m_Terrain_2 = ObjectPool.GetObject(m_Terrain[0]);
            m_Terrain_2.transform.position = m_Terrain[0].transform.position + Vector3.forward * 2;
        }
    }
    */