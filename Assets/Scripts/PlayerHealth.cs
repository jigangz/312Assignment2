using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // 角色的最大血量
    private int currentHealth; // 角色的当前血量

    void Start()
    {
        currentHealth = maxHealth; // 在游戏开始时，设置当前血量为最大血量
    }

    void Update()
    {
        // 这里可以添加血量检测逻辑
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver"); // 当血量降至0或以下时，加载GameOver场景
        }
    }

    // 调用这个方法来减少血量
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // 检查血量是否低于0，可以在这里添加血量耗尽时的逻辑
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
