using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInteracts : MonoBehaviour
{
    private string gameSceneName = "Game Scene";

    public void LoadGameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
