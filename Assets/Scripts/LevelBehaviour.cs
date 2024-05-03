using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelBehaviour : MonoBehaviour
{
    
    
    public TerrainGeneratorManager m_TerrainGeneratorManager;

    //Store Record
    public int m_Record = 0;

    //TerrainMovementVaribales
    public float m_Offset = 100f;
    public float m_Duration = 1f;
    public GameObject m_Terrain;
    public int m_StepsCounter = 0;

    //PowerUps
    public int m_PowerUpSalto = 1;
    public int m_StopPropsSteps;

    //Boolean Variables
    public bool m_CanMove = true;
    private bool m_IsRecycled = false;

    //StepsCounter
    public int m_Counter = 0;

    //Static Variables
    public static LevelBehaviour instance;

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

        m_Terrain = this.gameObject;
    }

    
    public void Start()
    {
        SwipeController.instance.OnMovement += MoveTarget;
    }

    public void OnDisable()
    {
        SwipeController.instance.OnMovement -= MoveTarget;
    }


    void MoveTarget(Vector3 m_Direction)
    {
        RaycastHit m_Hitinfo = PlayerBehaviour.m_RaycastDirection;

        if (PlayerBehaviour.instance != null && PlayerBehaviour.instance.m_CanJump && m_CanMove)
        {
            
            if (Physics.Raycast(PlayerBehaviour.instance.transform.position + new Vector3(0, 1f, 0), m_Direction, out m_Hitinfo, 1f))
            {
                if (m_Hitinfo.collider.tag == "Object" && m_Hitinfo.collider.tag != "Car")
                {
                    if (m_Direction.z != 0)
                    {
                        m_Direction.z = 0;
                    }
                    if (m_Direction.x != 0)
                    {
                        m_Direction.x = 0;
                    }
                    if (m_Direction.y != 0)
                    {
                        m_Direction.y = 0;
                    }
                }
               

            }
            
            if(m_Direction.normalized.z >= 0 && PlayerBehaviour.instance.m_StepsBack == 0)
            {
                LeanTween.move(m_Terrain, m_Terrain.transform.position + new Vector3(0, 0, -m_Direction.normalized.z) * m_PowerUpSalto, m_Duration).setEase(LeanTweenType.easeOutQuad);
            }
               
            //Steps Counter
            
            if (PlayerBehaviour.instance.m_StepsBack == 0 && m_Direction.z >= 0 && Mathf.Abs(m_Direction.x) < Mathf.Abs(m_Direction.z))
            {
                if (PowerUps.instance.m_StopProps)
                {
                    PowerUps.instance.StopProps();
                    PowerUps.instance.m_PowerUpParticle.Stop();
                }
                m_StepsCounter++;
                //Steps Canvas
                PlayerPrefs.SetInt("Steps", m_StepsCounter);
                PlayerPrefs.Save();

                //UpdateStepsCanvas
                if (GameUI.instance != null)
                {
                    GameUI.instance.LandsCapeUpdateStepText();
                }

                if (GameUI_Portait.instance != null)
                {
                    GameUI_Portait.instance.PortaitUpdateStepText();
                }
                    
                if (Random.Range(0, 50) == Random.Range(0, 50))
                { 
                    PlayerBehaviour.instance.m_MonkeySound.Play();
                }
            }
            
        }    
    }

    public void Update()
    {
        if (m_Counter == 2 && m_IsRecycled == true)
        {
            m_Counter = 0;
            m_IsRecycled = false;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            m_CanMove = false;
        }
    }
}
