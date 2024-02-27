using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PortalScript : MonoBehaviour
{
    public string targetSceneName = "BossScene"; // Ŀ�곡��������

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ֱ�Ӽ���Ŀ�곡������ǰ���������Զ�ж��
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
