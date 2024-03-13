using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public Vector3 m_InictialClick;
    public Vector3 m_FinalClick;
    public float m_movementArea;
    public GameObject m_Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            m_InictialClick = Input.mousePosition;
        }

         if (Input.GetMouseButtonUp(0))
        {
            m_FinalClick = Input.mousePosition;
            Vector3 difference = m_FinalClick - m_InictialClick;
            Debug.Log(difference);
                if(difference.x < m_movementArea)
                {
                    Debug.Log("Se ha movido a la izq");
                    MoveTarget(- m_Player.GetComponent<Transform>().right);
                }
                if(difference.x > 0)
                {
                    Debug.Log("Se ha movido a la dcha");
                    MoveTarget(m_Player.GetComponent<Transform>().left);
                }
                if(difference.y > 0)
                {
                    Debug.Log("Se ha movido hacia arriba");
                    MoveTarget(m_Player.GetComponent<Transform>().left);
                }
                if(difference.y < 0)
                {
                    Debug.Log("Se ha movido abajo");
                }
                if(Mathf.Abs(difference.y) <= m_movementArea && Mathf.Abs(difference.x) <= m_movementArea)
                {
                    Debug.Log("No se ha movido");
                }
        }
    }
}
