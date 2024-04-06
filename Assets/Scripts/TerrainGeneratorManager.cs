using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneratorManager : MonoBehaviour
{
    [SerializeField]
    public int m_Nterrain;
    public GameObject m_InicialTerrainSpawn;
    public GameObject m_ProceduralTerrainSpawn;
    public GameObject[] m_InicialTerrains;
    public GameObject[] m_ProceduralTerrains;
    public int m_RandomIndex;

    void Start()
    {
        m_RandomIndex = Random.Range(0, m_InicialTerrains.Length);
        m_InicialTerrains[m_RandomIndex].transform.position = m_InicialTerrainSpawn.transform.position;
        m_ProceduralTerrains[m_RandomIndex].transform.position = m_ProceduralTerrainSpawn.transform.position;
    }

    public void RecycleTerrain(GameObject m_Terrain)
    {
         
    }

}