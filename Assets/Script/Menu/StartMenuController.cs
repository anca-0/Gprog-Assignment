using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public void OnStartClicked()
    {
        SceneManager.LoadScene("mainlvl");
    }

    public void OnControlsClicked()
    {
        SceneManager.LoadScene("Controls");
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }

    public void OnBackClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnBackToMenuClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
