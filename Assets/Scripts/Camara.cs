using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform m_PlayerTransform;
    public float m_SmoothSpeed = 0.125f;
    public Vector3 m_Offset;
    public static Camara instance;
    public bool m_Disable = true;
    //Posiciones Camara
    public GameObject m_PortaitPosition;
    public GameObject m_LandscapePosition;

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

    public void LandScapeCamara()
    {
        Vector3 m_LastPosition = new Vector3(m_PlayerTransform.position.x + m_Offset.x, m_LandscapePosition.transform.position.y, m_LandscapePosition.transform.position.z);
        Vector3 m_SmoothedPosition = Vector3.Lerp(transform.position, m_LastPosition, m_SmoothSpeed * Time.deltaTime);
        transform.position = m_SmoothedPosition;
    }

    public void PortaitCamara()
    {
        Vector3 m_LastPosition = new Vector3(m_PlayerTransform.position.x + m_Offset.x, m_PortaitPosition.transform.position.y, m_PortaitPosition.transform.position.z);
        Vector3 m_SmoothedPosition = Vector3.Lerp(transform.position, m_LastPosition, m_SmoothSpeed * Time.deltaTime);
        transform.position = m_SmoothedPosition;
    }
}
