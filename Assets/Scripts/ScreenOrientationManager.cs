using UnityEngine;
using UnityEngine.UI;

public class ScreenOrientationManager : MonoBehaviour
{
    public Canvas m_PortraitCanvas;
    public Canvas m_LandscapeCanvas;
    public Canvas m_PortraitPowerUpsCanvas;
    public Canvas m_LandscapePowerUpsCanvas;
    public bool m_Selected = false;
    //Audio
    public AudioSource m_MenuPop;


    public static ScreenOrientationManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Corrected the destruction of duplicate instances
        }
    }

    void Start()
    {
        UpdateCanvas();
    }

    void Update()
    {
        UpdateCanvas();
    }

    void UpdateCanvas()
    {
        if (Screen.width > Screen.height)
        {
            m_PortraitCanvas.gameObject.SetActive(false);
            m_LandscapeCanvas.gameObject.SetActive(true);
          
            if (!m_Selected)
            {
                m_PortraitPowerUpsCanvas.gameObject.SetActive(false);
                m_LandscapePowerUpsCanvas.gameObject.SetActive(true);
                
            }
            // Corrected the spelling of "Camera"
            Camara.instance.LandScapeCamara(); // Assuming LandScapeCamara is a method in your Camera script
        }
        else
        {
            if (!m_Selected)
            {
                m_PortraitPowerUpsCanvas.gameObject.SetActive(true);
                m_LandscapePowerUpsCanvas.gameObject.SetActive(false);
         

            }
            m_PortraitCanvas.gameObject.SetActive(true);
            m_LandscapeCanvas.gameObject.SetActive(false);
           

            // Corrected the spelling of "Camera"
            Camara.instance.PortaitCamara(); // Assuming PortaitCamara is a method in your Camera script
        }
    }
}

