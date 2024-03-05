using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueBack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ����Ƿ�����Ҳ����Ѿ���������һ��ֽ��
        if (other.CompareTag("Player") && GameManager.Instance.HasReadNote)
        {
            SceneManager.LoadScene("BlueAct"); // �������㣬������һ������
        }
        else
        {
            // ������������ӷ��������������Ҫ�ȶ�ֽ��
            Debug.Log("You must read the note before you can pass.");
        }
    }
}
