using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ���볡�����������ռ�

public class Boss : MonoBehaviour
{
    // ��Boss��������ʱ����
    void OnDestroy()
    {
        // ����Act6����
        SceneManager.LoadScene("Act6");
    }
}