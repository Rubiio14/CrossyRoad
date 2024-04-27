using UnityEngine;
using UnityEngine.UI;

public class ScreenOrientationManager : MonoBehaviour
{
    public Canvas m_PortraitCanvas;
    public Canvas m_LandscapeCanvas;

    void Start()
    {
        UpdateCanvas();
    }

    void Update()
    {
        if (Screen.width > Screen.height)
        {
            m_PortraitCanvas.gameObject.SetActive(false);
            m_LandscapeCanvas.gameObject.SetActive(true);
        }
        else
        {
            m_PortraitCanvas.gameObject.SetActive(true);
            m_LandscapeCanvas.gameObject.SetActive(false);
        }
    }

    void UpdateCanvas()
    {
        if (Screen.width > Screen.height)
        {
            m_PortraitCanvas.gameObject.SetActive(false);
            m_LandscapeCanvas.gameObject.SetActive(true);
        }
        else
        {
            m_PortraitCanvas.gameObject.SetActive(true);
            m_LandscapeCanvas.gameObject.SetActive(false);
        }
    }
}