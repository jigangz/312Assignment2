using UnityEngine;

public class SpeedPotion : MonoBehaviour
{
    public float speedMultiplier = 2f; // 定义加速倍数
    private bool isPlayerNearby = false; // 检测玩家是否在药水附近

    private void Update()
    {
        // 如果玩家靠近并且按下空格键
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.Space))
        {
            ConsumePotion();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查是否是玩家进入触发区域
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 检查是否是玩家离开触发区域
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

    void ConsumePotion()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            CharacterController2D controller = player.GetComponent<CharacterController2D>();
            if (controller != null)
            {
                // 使用SetSpeed方法将玩家速度增加到当前速度的倍数
                controller.SetSpeed(controller.speed * speedMultiplier);
                // 注意：由于speedMultiplier是加速倍数，你可能需要在CharacterController2D脚本中
                // 存储玩家的原始速度，以便药水效果结束后可以恢复原始速度
            }
        }

        Destroy(gameObject); // 消耗药水后销毁对象
    }
}
