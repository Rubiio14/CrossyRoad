using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform m_PlayerTransform;
    public float m_SmoothSpeed = 0.125f;
    public Vector3 m_Offset;
    public static Camara instance;
    public bool m_Disable = true;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    
    private void LateUpdate()
    {
        if (m_PlayerTransform != null && m_Disable)
        {
            Vector3 m_LastPosition = new Vector3(m_PlayerTransform.position.x + m_Offset.x, transform.position.y, transform.position.z);
            Vector3 m_SmoothedPosition = Vector3.Lerp(transform.position, m_LastPosition, m_SmoothSpeed * Time.deltaTime);
            transform.position = m_SmoothedPosition;
        }
    }
}
