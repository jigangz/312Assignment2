using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class HealthManager : MonoBehaviour
{
    public Text hpValueText; // HP文本组件
    public Image healthImage; // 健康状态条
    public Image healthDelayImage; // 延迟更新的健康状态条
    public Image powerImage; // 能量状态条

    private int hpValue = 100; // 初始HP值
   // private Character currentCharacter; // 当前角色引用
    private bool isRecovering; // 是否在恢复能量

    //public static event Action<int> OnPlayerHealthReduced;
    public event Action OnPlayerHealthReduced; // 事件声明
    
    private void Start()
    {
        UpdateHPDisplay();
        UpdateHealthBar((float)hpValue / 100); // 假设最大HP是100
    }

    private void Update()
    {
        // 健康状态条延迟更新逻辑
        if (healthDelayImage.fillAmount > healthImage.fillAmount)
        {
            healthDelayImage.fillAmount -= Time.deltaTime * 0.1f;
        }

        // 能量恢复逻辑
        if (isRecovering)
        {
            //float percentage = currentCharacter.currentPower / currentCharacter.maxPower;
           // powerImage.fillAmount = percentage;

            //if (percentage >= 1)
            //{
                //isRecovering = false;
            //}
        }
    }

    public void ReduceHP(int damage)
    {
        // 减少HP逻辑
        // OnPlayerHealthReduced?.Invoke(damage);
        OnPlayerHealthReduced?.Invoke(); // 触发事件

        hpValue -= damage;
        UpdateHPDisplay();
        UpdateHealthBar((float)hpValue / 100); // 假设最大HP是100

        if (hpValue <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void UpdateHPDisplay()
    {
        if (hpValueText != null)
        {
            hpValueText.text = "HP: " + hpValue.ToString();
        }
    }

    public void UpdateHealthBar(float percentage)
    {
        healthImage.fillAmount = percentage;
    }

    // 假设有一个方法来更新当前角色的能量状态
    //public void OnPowerChange(Character character)
   // {
       // isRecovering = true;
   //     currentCharacter = character;
    //}
}
