using UnityEngine;

public class PropMov : MonoBehaviour
{
    //Duracion LeanTween
    public float m_Duration = 0.25f;

    
    [SerializeField] GameObject m_Terrain;
    [SerializeField] GameObject m_Player;

    public bool m_CanMove = true;

    public void Awake()
    {
        m_Terrain = this.gameObject;
        m_Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Start()
    {
        SwipeController.instance.OnMovement += MoveTarget;
    }

    public void OnDisable()
    {
        SwipeController.instance.OnMovement -= MoveTarget;
    }

    public void MoveTarget(Vector3 m_Direction)
    {
        RaycastHit m_HitInfo = PlayerBehaviour.m_RaycastDirection;

        Vector3 m_DirectionNormalized = m_Direction.normalized;

        if (PlayerBehaviour.instance.m_CanJump && m_CanMove)
        {
            if (Physics.Raycast(m_Player.transform.position + new Vector3(0, 1f, 0), m_Direction, out m_HitInfo, 1f))
            {
                //Debug.Log("Hit Something, Restricting Movement");
                if (m_HitInfo.collider.tag != "ProceduralTerrain")
                {
                    if (m_DirectionNormalized.z != 0)
                    {
                        m_DirectionNormalized.z = 0;
                    }
                }

                //Debug.DrawRay(transform.position + new Vector3(0, 1f, 0), transform.forward * m_HitInfo.distance, Color.red);
            }

            if (m_DirectionNormalized.z >= 0 && PlayerBehaviour.instance.m_StepsBack == 0)
            {
                LeanTween.move(m_Terrain, m_Terrain.transform.position + new Vector3(0, 0, -m_DirectionNormalized.z) * LevelBehaviour.instance.m_PowerUpSalto, m_Duration).setEase(LeanTweenType.easeOutQuad);
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerBehaviour.instance.m_CanJump = true;
        }
    }
}
