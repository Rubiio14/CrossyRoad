using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneratorManager : MonoBehaviour
{
    [SerializeField]
    public GameObject m_InicialTerrainSpawn;
    public GameObject[] m_InicialTerrains;
    
    public int m_RandomIndex;

    //Genera un terreno inicial de una lista al empezar el juego en el spawn que se le pase
    void Start()
    {
        m_RandomIndex = Random.Range(0, m_InicialTerrains.Length);
        m_InicialTerrains[m_RandomIndex].transform.position = m_InicialTerrainSpawn.transform.position;
    }
}