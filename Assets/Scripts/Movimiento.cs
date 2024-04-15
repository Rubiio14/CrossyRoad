using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropMov : MonoBehaviour
{


    public float pm_Duration = 0.25f;

    [SerializeField] GameObject pm_Terrain;
    [SerializeField] GameObject pm_Player;

    public bool m_CanMove = true;

    public void Awake()
    {
        pm_Terrain = this.gameObject;
        pm_Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Start()
    {
        SwipeController.instance.OnMovement += MoveTarget;
    }

    public void OnDisable()
    {
        SwipeController.instance.OnMovement -= MoveTarget;
    }

    public void MoveTarget(Vector3 t_Direction)
    {
        RaycastHit t_HitInfo = PlayerBehaviour.m_RaycastDirection;

        Vector3 t_DirectionNormalized = t_Direction.normalized;

        if (PlayerBehaviour.instance.m_CanJump && m_CanMove)
        {
            if (Physics.Raycast(pm_Player.transform.position + new Vector3(0, 1f, 0), t_Direction, out t_HitInfo, 1f))
            {
                Debug.Log("Hit Something, Restricting Movement");
                if (t_HitInfo.collider.tag != "ProceduralTerrain")
                {
                    if (t_DirectionNormalized.z != 0)
                    {
                        t_DirectionNormalized.z = 0;
                    }
                }

                Debug.DrawRay(transform.position + new Vector3(0, 1f, 0), transform.forward * t_HitInfo.distance, Color.red);
            }

            if (t_DirectionNormalized.z >= 0 && PlayerBehaviour.instance.m_StepsBack == 0)
            {
                LeanTween.move(pm_Terrain, pm_Terrain.transform.position + new Vector3(0, 0, -t_DirectionNormalized.z), pm_Duration).setEase(LeanTweenType.easeOutQuad);
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
