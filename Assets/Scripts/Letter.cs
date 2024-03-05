using UnityEngine;

public class Letter : MonoBehaviour
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
        UIManager.Instance.ShowDialog("You found a note!\n" +
"The note reads: 'It's too late to get out now. I should have gone <color=#FF0000>back</color> when I had the chance. This <color=#FF0000>liar</color>!'\n" +
"Reading these words, a wave of urgency and betrayal washes over you, leaving you to question your next move.\n");
        // 交互后销毁笔记对象
        GameManager.Instance.HasReadNote = true;
        Destroy(gameObject);

    }
}