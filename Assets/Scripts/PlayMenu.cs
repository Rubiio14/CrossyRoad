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
    [SerializeField] TextMeshProUGUI m_CoinNeededText;
    [SerializeField] TextMeshProUGUI m_CoinText;
    [SerializeField] TextMeshProUGUI m_CoinText_Portait;
    public GameObject m_Niveles;
    public GameObject m_Niveles_Portait;
    public void Update()
    {
        if (Screen.width > Screen.height)
        {
            m_Niveles.SetActive(true);
            m_Niveles_Portait.SetActive(false);
            m_CoinText.gameObject.SetActive(true);
            m_CoinText_Portait.gameObject.SetActive(false);
            m_MainMenu.SetActive(false);

        }
        else
        {
            m_Niveles.SetActive(false);
            m_Niveles_Portait.SetActive(true);
            m_CoinText_Portait.gameObject.SetActive(true);
            m_CoinText.gameObject.SetActive(false);
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
            m_CoinNeededText.text = "Necesitas comprar la serpiente y el Desierto en la tienda";
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
            m_Canvas.SetActive(true);
            this.gameObject.SetActive(false);
            m_CoinNeededText.text = "Necesitas comprar el reno y la Nieve en la tienda";
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
            m_Canvas.SetActive(true);
            this.gameObject.SetActive(false);
            m_CoinNeededText.text = "Necesitas comprar el pájaro y CandyLand en la tienda";
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
            m_Canvas.SetActive(true);
            this.gameObject.SetActive(false);
            m_CoinNeededText.text = "Necesitas comprar el MonoEspecial y el modo Arcade en la tienda";
        }
    }

    public void VolverButton()
    {
        m_MainMenu.SetActive(true);
        m_CoinText.gameObject.SetActive(false);
        m_CoinText_Portait.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        m_ButtonSound.Play();
    }

    public void ContinueButton()
    {
        m_Canvas.SetActive(false);
        m_ButtonSound.Play();
        this.gameObject.SetActive(true);
    }
}
