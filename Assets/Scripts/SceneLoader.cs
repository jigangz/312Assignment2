using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene("Intro"); 
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Intro");
    }
    public void LoadBackGroundScene()
    {
        SceneManager.LoadScene("VideoIntro");
    }
    public void LoadMainGameScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
