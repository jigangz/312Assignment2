using UnityEngine;

public class Meat : MonoBehaviour
{
    private bool isPlayerNearby = false; // ����Ƿ񿿽�ʳ��

    private void Update()
    {
        // �����ҿ������Ұ��¿ո��
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.Space))
        {
            EatFood();
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

    void EatFood()
    {
        RestoreEnergy(); // ���ûظ������ķ���
        Destroy(gameObject); // ��ҽ���������ʳ�����
    }

    void RestoreEnergy()
    {
        // ���������ظ��������߼�
        Debug.Log("Energy restored!"); // ����Ϊʾ������ʾ�����ѻظ�
    }
}

