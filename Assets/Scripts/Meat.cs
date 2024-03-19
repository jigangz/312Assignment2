using UnityEngine;

public class Meat : MonoBehaviour
{
    private bool isPlayerNearby = false; // 玩家是否靠近食物

    private void Update()
    {
        // 如果玩家靠近并且按下空格键
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.Space))
        {
            EatFood();
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

    void EatFood()
    {
        RestoreEnergy(); // 调用回复精力的方法
        Destroy(gameObject); // 玩家交互后，销毁食物对象
    }

    void RestoreEnergy()
    {
        // 在这里加入回复精力的逻辑
        Debug.Log("Energy restored!"); // 仅作为示例，表示精力已回复
    }
}

