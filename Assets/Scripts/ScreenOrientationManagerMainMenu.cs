using UnityEngine;
using UnityEngine.UI;

public class ScreenOrientationManagerMainMenu : MonoBehaviour
{
    public static ScreenOrientationManagerMainMenu instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
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
       
            Camara.instance.LandScapeCamara();
        }
        else
        {
            Camara.instance.PortaitCamara();
        }
    }
}

