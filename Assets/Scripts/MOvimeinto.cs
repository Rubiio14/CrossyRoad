using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOvimeinto : MonoBehaviour
{
    public SwipeController m_SwipeController;
    public PlayerBehaviour m_PlayerBehaviour;
    
    public void Start()
    {
        m_SwipeController.OnMovement += MoveTarget;
    }


    public void OnDisable()
    {
        m_SwipeController.OnMovement -= MoveTarget;
    }
    

    void MoveTarget(Vector3 m_Direction)
    {
        if (m_PlayerBehaviour != null && !m_PlayerBehaviour.m_CanJump)
        {        
          LeanTween.move(gameObject, gameObject.transform.position + new Vector3(0, 0, -m_Direction.normalized.z), 0.25f).setEase(LeanTweenType.easeOutQuad); 
        }
    }

}
