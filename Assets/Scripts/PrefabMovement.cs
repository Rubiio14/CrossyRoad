using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabMovement : MonoBehaviour
{
    /*
    public float m_Duration = 0.25f;
    public PlayerBehaviour m_PlayerBehaviour;
    public SwipeController m_SwipeController;
    public NuevoPropsBehaviour m_NuevoPropsBehaviour;
    bool m_CanMove = true;

    void Update()
    {
        if(m_CanMove == true)
        {
            MoveTarget();
            m_CanMove = false;
        
        }
    }

    void MoveTarget()
    {
        GameObject m_RandomPrefabSpawnabCopy = NuevoPropsBehaviour.m_RandomPrefabSpawn;
        Debug.Log(m_PlayerBehaviour);
        if (m_PlayerBehaviour != null && m_PlayerBehaviour.m_CanJump)
        {
            
            LeanTween.move(m_RandomPrefabSpawnabCopy, m_RandomPrefabSpawnabCopy.transform.position + new Vector3(0, 0, -1), m_Duration).setEase(LeanTweenType.easeOutQuad);   
        }    
    }
    IEnumerator Delay(float m_time)
    {
        yield return new WaitForSeconds(m_time);
        m_CanMove = true;
    }
    */
}
