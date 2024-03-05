using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public void SkipCutscene()
    {
        
        SceneManager.LoadScene("MainScene");
    }
}
