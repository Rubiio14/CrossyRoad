using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelPedazo : MonoBehaviour
{
    //Scripts variables
    //public SwipeController m_SwipeController;
    public TerrainGeneratorManager m_TerrainGeneratorManager;
    public PlayerBehaviour m_PlayerBehaviour;

    //TerrainMovementVaribales
    public float m_Offset = 100f;
    public float m_Duration = 1f;
    public GameObject m_Terrain;
    public int m_StepsCounter;

    //Boolean Variables
    public bool m_CanMove = true;
    private bool m_IsRecycled = false;

    //StepsCounter
    public int m_Counter = 0;
    

    public void Awake()
    {
        m_Terrain = this.gameObject;
    }

    
    public void Start()
    {
        SwipeController.instance.OnMovement += MoveTarget;
    }

    public void OnDisable()
    {
        SwipeController.instance.OnMovement -= MoveTarget;
    }


    void MoveTarget(Vector3 m_Direction)
    {
        RaycastHit m_Hitinfo = PlayerBehaviour.m_RaycastDirection;

        if (m_PlayerBehaviour != null && m_PlayerBehaviour.m_CanJump && m_CanMove)
        {
            
            if (Physics.Raycast(m_PlayerBehaviour.transform.position + new Vector3(0, 1f, 0), m_Direction, out m_Hitinfo, 1f))
            {
                if (m_Hitinfo.collider.tag != "ProceduralTerrain")
                {
                    if (m_Direction.z != 0)
                    {
                        m_Direction.z = 0;
                    }
                }
               

            }
            
            if(m_Direction.normalized.z >= 0 && m_PlayerBehaviour.m_StepsBack == 0)
            {
                LeanTween.move(m_Terrain, m_Terrain.transform.position + new Vector3(0, 0, -m_Direction.normalized.z), m_Duration).setEase(LeanTweenType.easeOutQuad);
            }
               
            //Steps Counter
            
            if (m_PlayerBehaviour.m_StepsBack == 0 && m_Direction.z >= 0 && Mathf.Abs(m_Direction.x) < Mathf.Abs(m_Direction.z))
            {
                m_StepsCounter++;
            }
            
        }    
    }

    public void Update()
    {
        if (m_Counter == 2 && m_IsRecycled == true)
        {
            m_Counter = 0;
            m_IsRecycled = false;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            m_CanMove = false;
        }
    }
    
}
