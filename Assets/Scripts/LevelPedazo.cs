using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPedazo : MonoBehaviour
{
    public SwipeController m_Movement;

	public float m_Offset = 100f;
    public float m_Duration = 1f;
    public GameObject m_Terrain;

  
    void OnBecameInvisible()
    {
        Debug.Log("sale");
    }
    

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
		ObjectPool.RecicleObject(m_Terrain[0], m_Terrain_2);
	}

	void MoveTarget(Vector3 m_Direction)
    {
        LeanTween.move(m_Terrain, m_Terrain.transform.position  + new Vector3(0, 0, - m_Direction.z), m_Duration).setEase(LeanTweenType.easeOutQuad);
    }
}
