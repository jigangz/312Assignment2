using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Text hpValueText; // ͨ��Inspectorָ�����ٶ�������InGameUI�е�һ��Text���
    private int hpValue = 100; // ��ʼHPֵ

    private void Start()
    {
        UpdateHPDisplay();
    }

    public void ReduceHP(int damage)
    {
        hpValue -= damage; // ����HP
        UpdateHPDisplay(); // ������ʾ

        if (hpValue <= 0)
        {
            // HPС�ڵ���0������GameOver����
            SceneManager.LoadScene("GameOver");
        }
    }

    private void UpdateHPDisplay()
    {
        if (hpValueText != null)
        {
            hpValueText.text = "HP: " + hpValue.ToString(); // �����ı���ʾHPֵ
        }
    }
}
