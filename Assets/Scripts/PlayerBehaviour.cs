using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //Coins Counter
    public int m_Coin = 0;
    public int m_ValorMoneda = 1;

    //Movement Variables
    public float m_Offset = 100f;
    public float m_Duration = 1f;
    public int m_StepsBack = 0; 
    public GameObject m_Player;
    public bool m_CanJump = false;

    //PowerUps
    public int m_Invulnerabilidad = 1;
    public float m_VelocidadProps = 1f;

    //Static Variables
    public static PlayerBehaviour instance;
    public static RaycastHit m_RaycastDirection;

    //Canvas
    //public CanvasGroup m_CanvasGroup;
    //Audio
    [SerializeField]
    AudioSource m_AudioSource;
    [SerializeField]
    AudioSource m_carBeep;
    [SerializeField]
    AudioSource m_CarSound;
    [SerializeField]
    AudioSource m_PlayerDeath;
    [SerializeField]
    AudioSource m_WaterPlop;
    [SerializeField]
    public AudioSource m_MonkeySound;
    bool m_IsSoundPlaying;

    //Animations && Effects
    public Animator anim;
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

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3f))
        {
            // Verificar si el objeto tiene la etiqueta "Car"
            if (hit.collider.CompareTag("Car") && !m_IsSoundPlaying)
            {
                // Reproducir el sonido
                m_CarSound.transform.position = hit.collider.transform.position;
                m_CarSound.Play();
                m_IsSoundPlaying = true;
                StartCoroutine(ResetSoundState());
            }
        }
    }

        void MoveTarget(Vector3 m_Direction)
    {
        if (m_CanJump)
        {
            RaycastHit m_Hitinfo;
            Vector3 m_MoveDirection = m_Direction.normalized;

            
            if (Physics.Raycast(transform.position + new Vector3(0, 1f, 0), m_MoveDirection, out m_Hitinfo, 1f))
            {

                //Debug.Log("Hit Something, Restricting Movement");

                m_RaycastDirection = m_Hitinfo;
                if (m_Hitinfo.collider.tag == "Object")
                {
                    if (m_MoveDirection.x != 0)
                    {
                        m_MoveDirection.x = 0;
                    }
                    if (m_MoveDirection.y != 0)
                    {
                        m_MoveDirection.y = 0;
                    }
                    if (m_MoveDirection.z != 0)
                    {
                        m_MoveDirection.z = 0;
                    }
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

                
                LeanTween.move(m_Player, m_Player.transform.position + new Vector3(m_MoveDirection.x / 2, 0, 0) + Vector3.up / 2, m_Duration / 2 ).setEase(LeanTweenType.easeOutQuad).setOnComplete(() =>
                {
                    LeanTween.move(m_Player, m_Player.transform.position + new Vector3(m_MoveDirection.x / 2, 0, 0) - Vector3.up / 2, m_Duration / 2 ).setEase(LeanTweenType.easeOutQuad);
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

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Terrain"))
        {
            m_CanJump = true;
            anim.SetBool("IsJumping", false);
            if (PowerUps.instance.m_MonoSentado)
            {
                PowerUps.instance.MonoSentado();
                PowerUps.instance.m_PowerUpParticle.Stop();
            }
          
        }

        if (collision.gameObject.CompareTag("Death"))
        {
            //LandScape
            if (GameUI.instance != null)
            {
                GameUI.instance.GameEnding();
            }
            //Portait
            if (GameUI_Portait.instance != null)
            {
                GameUI_Portait.instance.GameEnding();
            }           
            Camara.instance.m_Disable = false;
            m_Player.SetActive(false);
            SwipeController.instance.enabled = false;
        }

        if (collision.gameObject.CompareTag("Car"))
        {
            m_Invulnerabilidad--;
            if (m_Invulnerabilidad == 0)
            {
                anim.SetBool("IsDead", true);
                Camara.instance.m_Disable = false;
                StartCoroutine(AnimationDelay());
                m_carBeep.Play();
                SwipeController.instance.enabled = false;
                m_PlayerDeath.Play();
            }    
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            m_Particles.transform.position = m_Player.transform.position;
            m_Particles.Play();
            m_WaterPlop.Play();
            m_Player.transform.localScale = Vector3.zero;
            SwipeController.instance.enabled = false;
            Camara.instance.m_Disable = false;
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
            m_Coin += m_ValorMoneda;
            if (GameUI.instance != null) 
            {
                //Landscape
                LeanTween.cancel(GameUI.instance.m_CanvasGroup.gameObject);
                LeanTween.alphaCanvas(GameUI.instance.m_CanvasGroup, 1f, m_Duration * 4).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
                {
                    LeanTween.alphaCanvas(GameUI.instance.m_CanvasGroup, 0f, m_Duration * 4).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
                    {
                        GameUI.instance.m_CanvasGroup.alpha = 0f;
                    });
                });
            }
            if (GameUI_Portait.instance != null)
            {
                //Portait
                LeanTween.cancel(GameUI_Portait.instance.m_CanvasGroup.gameObject);
                LeanTween.alphaCanvas(GameUI_Portait.instance.m_CanvasGroup, 1f, m_Duration * 4).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
                {
                    LeanTween.alphaCanvas(GameUI_Portait.instance.m_CanvasGroup, 0f, m_Duration * 4).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
                    {
                        GameUI_Portait.instance.m_CanvasGroup.alpha = 0f;
                    });
                });
            }
            m_AudioSource.Play();
            other.gameObject.SetActive(false);
        }
    }

    IEnumerator ResetSoundState()
    {
        yield return new WaitForSeconds(1.5f);
        m_IsSoundPlaying = false;
    }
    IEnumerator AnimationDelay()
    { 
        yield return new WaitForSeconds(1f);
        if (GameUI.instance != null)
        {
            GameUI.instance.GameEnding();
            m_Player.SetActive(false);
        }
        if (GameUI_Portait.instance != null)
        {
            GameUI_Portait.instance.GameEnding();
            m_Player.SetActive(false);
        }
    }
    IEnumerator AnimationWaterDelay()
    {
        yield return new WaitForSeconds(1f);
        m_Player.SetActive(false);
        if (GameUI.instance != null)
        {
            GameUI.instance.GameEnding();
        }
        if (GameUI_Portait.instance != null)
        {
            GameUI_Portait.instance.GameEnding();
        }

    }
}

