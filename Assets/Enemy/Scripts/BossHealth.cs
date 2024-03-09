using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class BossHealth : MonoBehaviour
{

    public Image healthImage; // ����״̬��

    public int hpValue = 100; // ��ʼHPֵ
                               

    //public static event Action<int> OnPlayerHealthReduced;
    public event Action OnPlayerHealthReduced; // �¼�����

    private void Start()
    {
        UpdateHealthBar((float)hpValue / 100); // �������HP��100
    }

    private void Update()
    {
       
    }

    public void ReduceHP(int damage)
    {
        // ����HP�߼�
        // OnPlayerHealthReduced?.Invoke(damage);
        OnPlayerHealthReduced?.Invoke(); // �����¼�

        hpValue -= damage;
        UpdateHealthBar((float)hpValue / 100); // �������HP��100

        if (hpValue <= 0)
        {
            SceneManager.LoadScene("Act6");
        }
    }


    public void UpdateHealthBar(float percentage)
    {
        healthImage.fillAmount = percentage;
    }




}