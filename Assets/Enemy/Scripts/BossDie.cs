using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 引入场景管理命名空间

public class Boss : MonoBehaviour
{
    // 当Boss对象被销毁时调用
    void OnDestroy()
    {
        // 加载Act6场景
        SceneManager.LoadScene("Act6");
    }
}