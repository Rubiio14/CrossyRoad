using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevoPropsBehaviour : MonoBehaviour
{
    
    public NuevoPropsGenerator m_NuevoPropsBehaviour;
    public PlayerBehaviour m_PlayerBehaviour;
    GameObject m_RandomPrefabSpawn;
    private bool m_PlayerMoved = false;
    public float m_Duration = 0.25f;
    void Start()
    {
        if (m_PlayerBehaviour == null)
        {
            enabled = false;
        }
    }


    void Update()
    {
        if (m_PlayerBehaviour != null && !m_PlayerMoved && m_PlayerBehaviour.m_CanJump == false)
        {
            m_PlayerMoved = true;
            RandomPrefab();
        }
        else if (m_PlayerBehaviour != null && m_PlayerMoved && m_PlayerBehaviour.m_CanJump)
        {
            m_PlayerMoved = false;
        }
    }

    
    void RandomPrefab ()
    {
        if (m_NuevoPropsBehaviour != null)
        {
            int m_RandomIndex = Random.Range(0, m_NuevoPropsBehaviour.m_PrefabsToPool.Length);
            GameObject m_RandomPrefab = m_NuevoPropsBehaviour.m_PrefabsToPool[m_RandomIndex].m_Prefab;
            GameObject m_RandomPrefabSpawn = m_NuevoPropsBehaviour.GetObject(m_RandomPrefab);          
        }
    }
}
