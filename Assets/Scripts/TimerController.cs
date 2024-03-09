using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public Text timerText;
    public float totalTime = 60f; // Total time

    private float timeRemaining; // lefttime

    void Start()
    {
        timeRemaining = totalTime;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "Time: " + timeRemaining.ToString("F2");
        }
        else
        {
            SceneManager.LoadScene("GameOver"); // load gameover scene
        }
    }

    public void PlayerReachedExit()
    {
        SceneManager.LoadScene("Boss"); // player go to boss room
    }
}
