using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PortalScript : MonoBehaviour
{
    public string targetSceneName = "BossScene"; // 目标场景的名称

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 直接加载目标场景，当前场景将被自动卸载
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
