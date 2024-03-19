using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public Text timerText; // ����ʱ�ı����
    public Text warningText; // �����ı����
    public float totalTime = 60f; // �ܼ�ʱ��

    private float timeRemaining; // ʣ��ʱ��
    private bool timerIsRunning = false; // ��ʱ���Ƿ��������еı�־

    void Start()
    {
        // ��Ϸ��ʼʱ��ȷ������ʱ�ı��;����ı�������ʾ
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
                timerText.enabled = true; // ȷ������ʱ�ı��ǿɼ���
            }
            else
            {
                timerIsRunning = false;
                SceneManager.LoadScene("GameOver"); // ʣ��ʱ��ľ�ʱ��������Ϸ��������
                timerText.enabled = false; // ��ѡ��ʱ��ľ�ʱ���ص���ʱ�ı�
            }
        }
    }

    public void StartTimer()
    {
        timeRemaining = totalTime;
        timerIsRunning = true; // �����ʱ��
        timerText.enabled = true; // ��ʾ����ʱ�ı�
        warningText.text = "Hurry, the cave is collapsing! Get out now!"; // ���ò���ʾ�����ı�
        warningText.enabled = true;
        Invoke("HideWarningText", 2); // 5������ؾ����ı�
    }

    // �������ؾ����ı��ķ���
    void HideWarningText()
    {
        warningText.enabled = false;
    }

    public void PlayerReachedExit()
    {
        SceneManager.LoadScene("Boss"); // ��ҵ������ʱ������Boss���䳡��
    }
}
