using UnityEngine;

public class Note : MonoBehaviour
{
    private bool hasInteracted = false; // ȷ������ֻ����һ��
    private bool isPlayerNearby = false; // ����Ƿ񿿽��ʼ�

    private void Update()
    {
        // �����ҿ��������¿ո��������֮ǰû�н��й�����
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.Space) && !hasInteracted)
        {
            InteractWithNote();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ����Ƿ�����ҽ��봥������
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // ����Ƿ�������뿪��������
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

    void InteractWithNote()
    {
        hasInteracted = true;
        // �����������ʾ�Ի����߼�������ͨ��UIManager
        UIManager.Instance.ShowDialog("You found a mysterious note!\n" +
                                      "The note reads: 'Beware the depths of the cave, I think <color=#FF0000>genie</color>  has not been completely honest with me'\n" +
                                      "Feeling a chill down your spine, you wonder what secrets the cave holds.\n");
        // ���������ٱʼǶ���
        GameManager.Instance.HasReadNote = true;
        Destroy(gameObject);
    }
}
