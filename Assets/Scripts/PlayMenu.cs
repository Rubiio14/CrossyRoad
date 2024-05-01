using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayMenu : MonoBehaviour
{
    //Audio
    public AudioSource m_ButtonSound;
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
        m_ButtonSound.Play();
    }
    public void QuitButton()
    {
        Application.Quit();
        m_ButtonSound.Play();
    }
}
