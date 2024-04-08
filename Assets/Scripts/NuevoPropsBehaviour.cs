using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevoPropsBehaviour : MonoBehaviour
{

    public GameObject Position;
    private bool m_PlayerMoved = false;
    void Start()
    {
        if (PlayerBehaviour.instance == null)
        {
            enabled = false;
        }
    }


    void Update()
    {
        if (PlayerBehaviour.instance != null && !m_PlayerMoved && PlayerBehaviour.instance.m_CanJump == false && PlayerBehaviour.instance.m_StepsBack == 0)
        {
            m_PlayerMoved = true;
            RandomPrefab();
        }
        else if (PlayerBehaviour.instance != null && m_PlayerMoved && PlayerBehaviour.instance.m_CanJump)
        {
            m_PlayerMoved = false;
        }
    }

    
    void RandomPrefab ()
    {
        if (NuevoPropsGenerator.instance != null && Position != null)
        {
            int m_RandomIndex = Random.Range(0, NuevoPropsGenerator.instance.m_PrefabsToPool.Length);
            GameObject m_RandomPrefab = NuevoPropsGenerator.instance.m_PrefabsToPool[m_RandomIndex].m_Prefab;
            GameObject m_RandomPrefabSpawn = NuevoPropsGenerator.instance.GetObject(m_RandomPrefab);
            m_RandomPrefabSpawn.transform.position = Position.transform.position;
        }
        else
        {
            Debug.LogError("Position object is not assigned or is null.");
        }
    }
}
