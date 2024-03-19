using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public Text timerText; // 倒计时文本组件
    public Text warningText; // 警告文本组件
    public float totalTime = 60f; // 总计时间

    private float timeRemaining; // 剩余时间
    private bool timerIsRunning = false; // 计时器是否正在运行的标志

    void Start()
    {
        // 游戏开始时，确保倒计时文本和警告文本都不显示
        timerText.enabled = false;
        warningText.enabled = false;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timerText.text = "Time: " + timeRemaining.ToString("F2");
                timerText.enabled = true; // 确保倒计时文本是可见的
            }
            else
            {
                timerIsRunning = false;
                SceneManager.LoadScene("GameOver"); // 剩余时间耗尽时，加载游戏结束场景
                timerText.enabled = false; // 可选：时间耗尽时隐藏倒计时文本
            }
        }
    }

    public void StartTimer()
    {
        timeRemaining = totalTime;
        timerIsRunning = true; // 激活计时器
        timerText.enabled = true; // 显示倒计时文本
        warningText.text = "Hurry, the cave is collapsing! Get out now!"; // 设置并显示警告文本
        warningText.enabled = true;
        Invoke("HideWarningText", 2); // 5秒后隐藏警告文本
    }

    // 用于隐藏警告文本的方法
    void HideWarningText()
    {
        warningText.enabled = false;
    }

    public void PlayerReachedExit()
    {
        SceneManager.LoadScene("Boss"); // 玩家到达出口时，加载Boss房间场景
    }
}
