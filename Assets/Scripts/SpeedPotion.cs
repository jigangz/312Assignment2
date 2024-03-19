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
                // 增加玩家速度
                controller.SetSpeed(controller.speed * speedMultiplier);

                // 启动倒计时
                TimerController timerController = FindObjectOfType<TimerController>();
                if (timerController != null)
                {
                    timerController.StartTimer();
                }
            }
        }

        Destroy(gameObject); // 消耗药水后销毁对象
    }
}
