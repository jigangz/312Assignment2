using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // ��ɫ�����Ѫ��
    private int currentHealth; // ��ɫ�ĵ�ǰѪ��

    void Start()
    {
        currentHealth = maxHealth; // ����Ϸ��ʼʱ�����õ�ǰѪ��Ϊ���Ѫ��
    }

    void Update()
    {
        // ����������Ѫ������߼�
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver"); // ��Ѫ������0������ʱ������GameOver����
        }
    }

    // �����������������Ѫ��
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // ���Ѫ���Ƿ����0���������������Ѫ���ľ�ʱ���߼�
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
