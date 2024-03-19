using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
	
	public SwipeController m_SwipeController;

	public float m_Offset = 100f;
    public float m_Duration = 1f;
    public GameObject m_Player;
    public bool m_CanJump = true;
	Vector3 previousPosition;
    public void Awake()
	{
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
        if (m_CanJump == true)
        {
            if (m_Direction.x > 0)
            {
                transform.eulerAngles = new Vector3(0, -90f, 0);
            }
            else if (m_Direction.x < 0)
            {
                transform.eulerAngles = new Vector3(0, 90f, 0);
            }
            else if (m_Direction.z > 0)
            {
                transform.eulerAngles = new Vector3(0, 180f, 0);
            }
            else if (m_Direction.z < 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }

            LeanTween.move(m_Player, m_Player.transform.position + new Vector3(m_Direction.normalized.x / 2, 0, 0) + Vector3.up / 2, m_Duration / 2).setEase(LeanTweenType.easeOutQuad).setOnComplete(() =>
            {
                LeanTween.move(m_Player, m_Player.transform.position + new Vector3(m_Direction.normalized.x / 2, 0, 0) - Vector3.up / 2, m_Duration / 2).setEase(LeanTweenType.easeOutQuad);
            });
            m_CanJump = false;
        }
        

    }
    public void OnCollisionEnter(Collision collision)
    {
		if (collision.gameObject.tag == "Terrain" || collision.gameObject.tag == "ProceduralTerrain")
		{
            m_CanJump = true;
            Debug.Log("guarda posicion" + previousPosition);
            previousPosition = transform.position;
        }

        if (collision.gameObject.tag == "Object")
        {
         
            
            transform.position = previousPosition;
            Debug.Log("se movio hacia atras" + transform.position);
        }
    }
}
