using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public SwipeController m_SwipeController;

    //Movement Variables
    public float m_Offset = 100f;
    public float m_Duration = 1f;
    public int m_StepsBack = 0; 
    public GameObject m_Player;

    public bool m_choca = false;
    public bool m_CanJump = true;

    //Static Variables
    public static PlayerBehaviour instance;
    public static RaycastHit m_RaycastDirection;

    public GameUI m_GameUI;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(this);
        }

        m_Player = this.gameObject;
    }

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
        if (m_CanJump)
        {
            RaycastHit m_Hitinfo;
            Vector3 m_MoveDirection = m_Direction.normalized;

            
            if (Physics.Raycast(transform.position + new Vector3(0, 1f, 0), m_MoveDirection, out m_Hitinfo, 1f))
            {
                Debug.Log("Hit Something, Restricting Movement");

                m_RaycastDirection = m_Hitinfo;

                if (m_MoveDirection.x != 0)
                {
                    m_MoveDirection.x = 0;
                }
                m_choca = true;
                
            }

            if (m_MoveDirection != Vector3.zero)
            {
                if (m_MoveDirection.x > 0)
                {
                    transform.eulerAngles = new Vector3(0, -90f, 0);
                }
                else if (m_MoveDirection.x < 0)
                {
                    transform.eulerAngles = new Vector3(0, 90f, 0);
                }
                else if (m_MoveDirection.z > 0)
                {
                    transform.eulerAngles = new Vector3(0, 180f, 0);
                }
                else if (m_MoveDirection.z < 0)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }

                m_choca = false;
                LeanTween.move(m_Player, m_Player.transform.position + new Vector3(m_MoveDirection.x / 2, 0, 0) + Vector3.up / 2, m_Duration / 2).setEase(LeanTweenType.easeOutQuad).setOnComplete(() =>
                {
                    LeanTween.move(m_Player, m_Player.transform.position + new Vector3(m_MoveDirection.x / 2, 0, 0) - Vector3.up / 2, m_Duration / 2).setEase(LeanTweenType.easeOutQuad);
                });
                //Solo Puede dar 4 pasos hacia atás
                if (m_StepsBack < 4 && m_Direction.normalized.z <= 0)
                {
                    m_StepsBack++;
                    LeanTween.move(m_Player, m_Player.transform.position + new Vector3(m_MoveDirection.x / 2, 0, m_MoveDirection.z / 2) + Vector3.up / 2, m_Duration / 2).setEase(LeanTweenType.easeOutQuad).setOnComplete(() =>
                    {
                        LeanTween.move(m_Player, m_Player.transform.position + new Vector3(m_MoveDirection.x / 2, 0, m_MoveDirection.z / 2) - Vector3.up / 2, m_Duration / 2).setEase(LeanTweenType.easeOutQuad);
                    });
                }
                if (m_StepsBack != 0 && m_Direction.normalized.z >= 0)
                {
                    m_StepsBack--;
                    LeanTween.move(m_Player, m_Player.transform.position + new Vector3(m_MoveDirection.x / 2, 0, m_MoveDirection.z / 2) + Vector3.up / 2, m_Duration / 2).setEase(LeanTweenType.easeOutQuad).setOnComplete(() =>
                    {
                        LeanTween.move(m_Player, m_Player.transform.position + new Vector3(m_MoveDirection.x / 2, 0, m_MoveDirection.z / 2) - Vector3.up / 2, m_Duration / 2).setEase(LeanTweenType.easeOutQuad);
                    });
                }
                m_CanJump = false;
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain") || collision.gameObject.CompareTag("ProceduralTerrain"))
        {
            m_CanJump = true;
        }

       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            m_GameUI.m_Coin++;
            other.gameObject.SetActive(false);
        }
    }

}

