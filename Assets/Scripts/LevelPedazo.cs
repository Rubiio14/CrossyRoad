using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPedazo : MonoBehaviour
{
    public SwipeController m_Movement;
    public TerrainGeneratorManager m_TerrainGeneratorManager;

    public float m_Offset = 100f;
    public float m_Duration = 1f;
    public GameObject m_Terrain;

    private bool m_IsRecycled = false;

    public void Awake()
    {
        m_Terrain = this.gameObject;
    }

    public void OnEnable()
    {
        m_Movement.OnMovement += MoveTarget;
    }

    public void OnDisable()
    {
        m_Movement.OnMovement -= MoveTarget;
    }

    void MoveTarget(Vector3 m_Direction)
    {
        LeanTween.move(m_Terrain, m_Terrain.transform.position + new Vector3(0, 0, -m_Direction.z), m_Duration).setEase(LeanTweenType.easeOutQuad);
    }
    public void OnBecameInvisible()
    {
        if (!m_IsRecycled)
        {
            m_TerrainGeneratorManager.RecycleTerrain(m_Terrain);
            m_IsRecycled = true;
            m_TerrainGeneratorManager.NewLevelZone();
        }
      
    }
}