using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class BossHealth : MonoBehaviour
{

    public Image healthImage; // 健康状态条

    public int hpValue = 100; // 初始HP值
                               

    //public static event Action<int> OnPlayerHealthReduced;
    public event Action OnPlayerHealthReduced; // 事件声明

    private void Start()
    {
        UpdateHealthBar((float)hpValue / 100); // 假设最大HP是100
    }

    private void Update()
    {
       
    }

    public void ReduceHP(int damage)
    {
        // 减少HP逻辑
        // OnPlayerHealthReduced?.Invoke(damage);
        OnPlayerHealthReduced?.Invoke(); // 触发事件

        hpValue -= damage;
        UpdateHealthBar((float)hpValue / 100); // 假设最大HP是100

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