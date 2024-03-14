using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneratorManager : MonoBehaviour
{
    [SerializeField]
    public GameObject m_TerrainPrefab;
    public int m_Nterrain;
    public Vector3 m_TerrainSpawn;

    void Start()
    {
        ObjectPool.PreLoad(m_TerrainPrefab, m_Nterrain);
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        // Calcular la posición de generación de terreno una vez
        m_TerrainSpawn = m_TerrainPrefab.transform.position;

        for (int i = 0; i < 2; i++)
        {
            // Generar terrenos en la posición calculada
            GameObject m_Terrain = ObjectPool.GetObject(m_TerrainPrefab);
            m_Terrain.transform.position = m_TerrainSpawn + Vector3.forward * i * m_TerrainPrefab.GetComponent<Renderer>().bounds.size.z;
        }
    }
    public void RecycleTerrain(GameObject m_Terrain)
    {
        // Reciclar el terreno utilizando el ObjectPool
        ObjectPool.RecicleObject(m_TerrainPrefab, m_Terrain);
    }

    public void NewLevelZone()
    {
        GameObject m_Terrain = ObjectPool.GetObject(m_TerrainPrefab);
        m_Terrain.transform.position = m_TerrainSpawn + Vector3.forward * m_TerrainPrefab.GetComponent<Renderer>().bounds.size.z;
    }
}