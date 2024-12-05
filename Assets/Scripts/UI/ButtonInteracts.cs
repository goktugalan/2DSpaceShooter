using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInteracts : MonoBehaviour
{
    private string gameSceneName = "Game Scene";
    private string mainMenuSceneName = "Main Menu";

    public void LoadGameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenuSceneName);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
