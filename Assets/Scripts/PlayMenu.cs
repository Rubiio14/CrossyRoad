using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayMenu : MonoBehaviour
{

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
