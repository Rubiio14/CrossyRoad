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
    [SerializeField] TextMeshProUGUI m_CoinNeededText;
    [SerializeField] TextMeshProUGUI m_CoinText;

    private void Start()
    {
        m_CoinText.text = "Monedas: " + PlayerPrefs.GetInt("TotalCoins").ToString();
    }
    public void CéspedMode()
    {
        SceneManager.LoadScene(1);
        m_ButtonSound.Play();
    }
    public void DesiertoMode()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= m_BloqueoDesierto)
        {
            SceneManager.LoadScene(2);
            m_ButtonSound.Play();
        }
        else 
        {
            m_Canvas.SetActive(true);
            this.gameObject.SetActive(false);
            m_CoinNeededText.text = "Necesitas " + m_BloqueoDesierto + " monedas para desbloquear ésta zona";
        }
    }
    public void NieveMode()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= m_BloqueoNieve)
        {
            SceneManager.LoadScene(3);
            m_ButtonSound.Play();
        }
        else
        {
            m_Canvas.SetActive(true);
            this.gameObject.SetActive(false);
            m_CoinNeededText.text = "Necesitas " + m_BloqueoNieve + " monedas para desbloquear ésta zona";
        }
    }
    public void CandyLandMode()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= m_BloqueoCandyLand)
        {
            SceneManager.LoadScene(4);
            this.gameObject.SetActive(false);
            m_ButtonSound.Play();
        }
        else
        {
            m_Canvas.SetActive(true);
            this.gameObject.SetActive(false);
            m_CoinNeededText.text = "Necesitas " + m_BloqueoCandyLand + " monedas para desbloquear ésta zona";
        }
    }
    public void ArcadeMode()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= m_BloqueoArcade)
        {
            SceneManager.LoadScene(5);
            this.gameObject.SetActive(false);
            m_ButtonSound.Play();
        }
        else
        {
            m_Canvas.SetActive(true);
            this.gameObject.SetActive(false);
            m_CoinNeededText.text = "Necesitas " + m_BloqueoArcade + " monedas para desbloquear ésta zona";
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
        m_ButtonSound.Play();
        this.gameObject.SetActive(true);
    }
}
