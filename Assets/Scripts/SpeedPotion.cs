using UnityEngine;

public class SpeedPotion : MonoBehaviour
{
    public float speedMultiplier = 2f; // ������ٱ���
    private bool isPlayerNearby = false; // �������Ƿ���ҩˮ����

    private void Update()
    {
        // �����ҿ������Ұ��¿ո��
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.Space))
        {
            ConsumePotion();
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

    void ConsumePotion()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            CharacterController2D controller = player.GetComponent<CharacterController2D>();
            if (controller != null)
            {
                // ʹ��SetSpeed����������ٶ����ӵ���ǰ�ٶȵı���
                controller.SetSpeed(controller.speed * speedMultiplier);
                // ע�⣺����speedMultiplier�Ǽ��ٱ������������Ҫ��CharacterController2D�ű���
                // �洢��ҵ�ԭʼ�ٶȣ��Ա�ҩˮЧ����������Իָ�ԭʼ�ٶ�
            }
        }

        Destroy(gameObject); // ����ҩˮ�����ٶ���
    }
}
