using UnityEngine;

public class Note : MonoBehaviour
{
    private bool hasInteracted = false; // 确保交互只发生一次
    private bool isPlayerNearby = false; // 玩家是否靠近笔记

    private void Update()
    {
        // 如果玩家靠近并按下空格键，并且之前没有进行过交互
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.Space) && !hasInteracted)
        {
            InteractWithNote();
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

    void InteractWithNote()
    {
        hasInteracted = true;
        // 在这里调用显示对话的逻辑，例如通过UIManager
        UIManager.Instance.ShowDialog("You found a mysterious note!\n" +
                                      "The note reads: 'Beware the depths of the cave, I think <color=#FF0000>genie</color>  has not been completely honest with me'\n" +
                                      "Feeling a chill down your spine, you wonder what secrets the cave holds.\n");
        // 交互后销毁笔记对象
        GameManager.Instance.HasReadNote = true;
        Destroy(gameObject);
    }
}
