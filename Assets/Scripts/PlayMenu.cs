using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayMenu : MonoBehaviour
{
    //Bloqueos de zona
    public int m_BloqueoDesierto = 50;
    public int m_BloqueoNieve = 100;
    public int m_BloqueoCandyLand = 200;
    public int m_BloqueoArcade = 300;
    //Audio
    public AudioSource m_ButtonSound;
    //Canvas
    [SerializeField] GameObject m_MainMenu;
    [SerializeField] GameObject m_Canvas;
    [SerializeField] GameObject m_CanvasPortait;
    [SerializeField] TextMeshProUGUI m_CoinNeededTextLandscape;
    [SerializeField] TextMeshProUGUI m_CoinNeededTextPortait;
    public GameObject m_Niveles;
    public GameObject m_Niveles_Portait;
    public void Update()
    {
        if (Screen.width > Screen.height)
        {
            m_Niveles.SetActive(true);
            m_Niveles_Portait.SetActive(false);
            m_MainMenu.SetActive(false);

        }
        else
        {
            m_Niveles.SetActive(false);
            m_Niveles_Portait.SetActive(true);
            m_MainMenu.SetActive(false);

        }
    }

    public void CéspedMode()
    {
        SceneManager.LoadScene(1);
        m_ButtonSound.Play();
    }
    public void DesiertoMode()
    {
        if (PlayerPrefs.GetInt("IsSerpiente") == 1 && PlayerPrefs.GetInt("IsDesierto") == 1)
        {
            SceneManager.LoadScene(2);
            m_ButtonSound.Play();
        }
        else 
        {
            if (Screen.width > Screen.height)
            {
                m_Canvas.SetActive(true);
                m_CanvasPortait.SetActive(false);
            }
            else
            {
                m_Canvas.SetActive(false);
                m_CanvasPortait.SetActive(true);
            }
            
            this.gameObject.SetActive(false);
            m_CoinNeededTextLandscape.text = "You need to buy the snake and the Desert in the store";
            m_CoinNeededTextPortait.text = "You need to buy the snake and the Desert in the store";
        }
    }
    public void NieveMode()
    {
        if (PlayerPrefs.GetInt("IsReno") == 1 && PlayerPrefs.GetInt("IsNieve") == 1)
        {
            SceneManager.LoadScene(3);
            m_ButtonSound.Play();
        }
        else
        {
            if (Screen.width > Screen.height)
            {
                m_Canvas.SetActive(true);
                m_CanvasPortait.SetActive(false);
            }
            else
            {
                m_Canvas.SetActive(false);
                m_CanvasPortait.SetActive(true);
            }

            this.gameObject.SetActive(false);
            m_CoinNeededTextLandscape.text = "You need to buy the reindeer and the snowy terrain in the store.";
            m_CoinNeededTextPortait.text = "You need to buy the reindeer and the snowy terrain in the store.";
        }
    }
    public void CandyLandMode()
    {
        if (PlayerPrefs.GetInt("IsPajaro") == 1 && PlayerPrefs.GetInt("IsCandyLand") == 1)
        {
            SceneManager.LoadScene(4);
            this.gameObject.SetActive(false);
            m_ButtonSound.Play();
        }
        else
        {
            if (Screen.width > Screen.height)
            {
                m_Canvas.SetActive(true);
                m_CanvasPortait.SetActive(false);
            }
            else
            {
                m_Canvas.SetActive(false);
                m_CanvasPortait.SetActive(true);
            }

            this.gameObject.SetActive(false);
            m_CoinNeededTextLandscape.text = "You need to buy the bird and CandyLand in the store";
            m_CoinNeededTextPortait.text = "You need to buy the bird and CandyLand in the store";
        }
    }
    public void ArcadeMode()
    {
        if (PlayerPrefs.GetInt("IsMonoEspecial") == 1 && PlayerPrefs.GetInt("IsArcade") == 1)
        {
            SceneManager.LoadScene(5);
            this.gameObject.SetActive(false);
            m_ButtonSound.Play();
        }
        else
        {
            if (Screen.width > Screen.height)
            {
                m_Canvas.SetActive(true);
                m_CanvasPortait.SetActive(false);
            }
            else
            {
                m_Canvas.SetActive(false);
                m_CanvasPortait.SetActive(true);
            }

            this.gameObject.SetActive(false);
            m_CoinNeededTextLandscape.text = "You need to buy the golden monkey and the golden terrain in the store";
            m_CoinNeededTextPortait.text = "You need to buy the golden monkey and the golden terrain in the store";
        }
    }

    public void VolverButton()
    {
        m_MainMenu.SetActive(true);
        this.gameObject.SetActive(false);
        m_ButtonSound.Play();
    }

    public void ContinueButton()
    {
        m_Canvas.SetActive(false);
        m_CanvasPortait.SetActive(false);
        m_ButtonSound.Play();
        this.gameObject.SetActive(true);
    }
}
