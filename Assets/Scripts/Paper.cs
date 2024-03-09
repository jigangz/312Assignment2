using UnityEngine;

public class Paper : MonoBehaviour
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
        UIManager.Instance.ShowDialog("You found a note!\n" +
                    "The note reads: 'Finding the <color=#FF0000>genie</color> really made me happy, but I feel that something dangerous lies ahead. Maybe I should head <color=#FF0000>back</color>.'\n" +
                     "With a sense of unease, you contemplate the potential dangers that lie in wait and whether you should continue forward or not.\n");
        // ���������ٱʼǶ���
        GameManager.Instance.HasReadNote = true;
        Destroy(gameObject);

    }
}
