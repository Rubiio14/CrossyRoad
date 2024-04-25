using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    //Movement Variables
    public float m_Offset = 100f;
    public float m_Duration = 1f;
    public int m_StepsBack = 0; 
    public GameObject m_Player;

    public bool m_CanJump = false;

    //Static Variables
    public static PlayerBehaviour instance;
    public static RaycastHit m_RaycastDirection;

    //Canvas
    public CanvasGroup m_CanvasGroup;
    //Audio
    [SerializeField]
    AudioSource m_AudioSource;
    [SerializeField]
    AudioSource m_carBeep;
    [SerializeField]
    AudioSource m_PlayerDeath;
    [SerializeField]
    AudioSource m_WaterPlop;
    [SerializeField]
    public AudioSource m_MonkeySound;

    //Animations && Effects
    private Animator anim;
    public ParticleSystem m_Particles;
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
        SwipeController.instance.OnMovement += MoveTarget;
        anim = GetComponent<Animator>();
    }


    public void OnDisable()
    {
        SwipeController.instance.OnMovement -= MoveTarget;
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
                
                
            }

            if (m_MoveDirection != Vector3.zero)
            {
                if (m_MoveDirection.x > 0)
                {
                    transform.eulerAngles = new Vector3(0, 90f, 0);
                }
                else if (m_MoveDirection.x < 0)
                {
                    transform.eulerAngles = new Vector3(0, -90f, 0);
                }
                else if (m_MoveDirection.z > 0)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else if (m_MoveDirection.z < 0)
                {
                    transform.eulerAngles = new Vector3(0, 180f, 0);
                }

                
                LeanTween.move(m_Player, m_Player.transform.position + new Vector3(m_MoveDirection.x / 2, 0, 0) + Vector3.up / 2, m_Duration / 2).setEase(LeanTweenType.easeOutQuad).setOnComplete(() =>
                {
                    LeanTween.move(m_Player, m_Player.transform.position + new Vector3(m_MoveDirection.x / 2, 0, 0) - Vector3.up / 2, m_Duration / 2).setEase(LeanTweenType.easeOutQuad);
                });
                
                //Solo Puede dar 4 pasos hacia atás
                if (m_StepsBack < 4 && m_Direction.normalized.z <= 0)
                {
                    if (Physics.Raycast(transform.position + new Vector3(0, 1f, 0), m_MoveDirection, out m_Hitinfo, 1f))
                    {
                        if (m_Direction.z != 0)
                        {
                            m_Direction.z = 0;
                        }
                    }
                    m_StepsBack++;
                    m_CanJump = false;
                    LeanTween.move(m_Player, m_Player.transform.position + new Vector3(m_MoveDirection.x / 2, 0, m_MoveDirection.z / 2) + Vector3.up / 2, m_Duration / 2).setEase(LeanTweenType.easeOutQuad).setOnComplete(() =>
                    {
                        LeanTween.move(m_Player, m_Player.transform.position + new Vector3(m_MoveDirection.x / 2, 0, m_MoveDirection.z / 2) - Vector3.up / 2, m_Duration / 2).setEase(LeanTweenType.easeOutQuad);
                    });
                    
                }
                if (m_StepsBack != 0 && m_Direction.normalized.z >= 0)
                {
                    if (Physics.Raycast(transform.position + new Vector3(0, 1f, 0), m_MoveDirection, out m_Hitinfo, 1f))
                    {
                        if (m_Direction.z != 0)
                        {
                            m_Direction.z = 0;
                        }
                    }
                    m_StepsBack--;
                    m_CanJump = false;
                    LeanTween.move(m_Player, m_Player.transform.position + new Vector3(m_MoveDirection.x / 2, 0, m_MoveDirection.z / 2) + Vector3.up / 2, m_Duration / 2).setEase(LeanTweenType.easeOutQuad).setOnComplete(() =>
                    {
                        LeanTween.move(m_Player, m_Player.transform.position + new Vector3(m_MoveDirection.x / 2, 0, m_MoveDirection.z / 2) - Vector3.up / 2, m_Duration / 2).setEase(LeanTweenType.easeOutQuad);
                    });
                    
                }
                

            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Terrain"))
        {
   
            m_CanJump = true;
            anim.SetBool("IsJumping", false);
        }

        if (collision.gameObject.CompareTag("Death"))
        {
 
            GameUI.instance.GameEnding();
            m_Player.SetActive(false);
            SwipeController.instance.enabled = false;
        }

        if (collision.gameObject.CompareTag("Car"))
        {
            
            anim.SetBool("IsDead", true);
            StartCoroutine(AnimationDelay());
            m_carBeep.Play();
            m_PlayerDeath.Play();
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            
            m_Particles.transform.position = m_Player.transform.position;
            m_Particles.Play();
            m_WaterPlop.Play();
            m_Player.transform.localScale = Vector3.zero;
            StartCoroutine(AnimationWaterDelay());
            
            
            
        }

    }

    public void OnCollisionExit(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Terrain"))
        {
            m_CanJump = false;
            anim.SetBool("IsJumping", true);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            GameUI.instance.m_Coin++;
            LeanTween.cancel(m_CanvasGroup.gameObject);
            LeanTween.alphaCanvas(m_CanvasGroup, 1f, m_Duration * 4).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
            {
                LeanTween.alphaCanvas(m_CanvasGroup, 0f, m_Duration * 4).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
                {
                    m_CanvasGroup.alpha = 0f;
                });
            });
            m_AudioSource.Play();
            other.gameObject.SetActive(false);
        }
    }
    IEnumerator AnimationDelay()
    { 
        yield return new WaitForSeconds(1f);
        GameUI.instance.GameEnding();
        m_Player.SetActive(false);
        SwipeController.instance.enabled = false;
    }
    IEnumerator AnimationWaterDelay()
    {
        yield return new WaitForSeconds(1f);
        m_Player.SetActive(false);
        GameUI.instance.GameEnding();
        SwipeController.instance.enabled = false;
    }
}

