using UnityEngine;

public class Letter : MonoBehaviour
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
"The note reads: 'It's too late to get out now. I should have gone <color=#FF0000>back</color> when I had the chance. This <color=#FF0000>liar</color>!'\n" +
"Reading these words, a wave of urgency and betrayal washes over you, leaving you to question your next move.\n");
        // ���������ٱʼǶ���
        GameManager.Instance.HasReadNote = true;
        Destroy(gameObject);

    }
}