using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropBehaviour : MonoBehaviour
{
    public SwipeController m_SwipeController;
    public PlayerBehaviour m_PlayerBehaviour;
    public PropsGenerator m_PropsGenerator;



    public void OnEnable()
    {
        m_SwipeController.OnMovement += MoveTarget;
    }

    public void OnDisable()
    {
        m_SwipeController.OnMovement -= MoveTarget;
    }

    void MoveTarget(Vector3 m_Direction)
    {
        RaycastHit m_Hitinfo = PlayerBehaviour.m_RaycastDirection;

        if (m_PlayerBehaviour != null && m_PlayerBehaviour.m_CanJump)
        {

            if (Physics.Raycast(m_PlayerBehaviour.transform.position + new Vector3(0, 1f, 0), m_Direction, out m_Hitinfo, 1f))
            {
                Debug.Log("Hit Something, Restricting Movement");

                if (m_Direction.z != 0)
                {
                    m_Direction.z = 0;
                }
            }

            if (m_PlayerBehaviour != null && m_PlayerBehaviour.m_CanJump)
            {
                GameObject propObject = m_PropsGenerator.GenerateProps();
                if (propObject != null)
                {
                    
                    //PropsGenerator.m_PropGenerated = true;
                    
                    LeanTween.move(propObject, propObject.transform.position + new Vector3(0, 0, -m_Direction.normalized.z), m_PlayerBehaviour.m_Duration).setEase(LeanTweenType.easeOutQuad);
                }    
            }

            GameObject[] props = GameObject.FindGameObjectsWithTag("Prop");
            foreach (GameObject prop in props)
            {
                LeanTween.move(prop, prop.transform.position + new Vector3(0, 0, -m_Direction.normalized.z), m_PlayerBehaviour.m_Duration).setEase(LeanTweenType.easeOutQuad);
            }
        }
    }
}
