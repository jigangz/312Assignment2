using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueBack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查是否是玩家并且已经读过至少一条纸条
        if (other.CompareTag("Player") && GameManager.Instance.HasReadNote)
        {
            SceneManager.LoadScene("BlueAct"); // 条件满足，加载下一个场景
        }
        else
        {
            // 可以在这里添加反馈，告诉玩家需要先读纸条
            Debug.Log("You must read the note before you can pass.");
        }
    }
}
