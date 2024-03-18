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
    public event Action OnPlayerHealthReduced; // 事件声明

    private float powerValue = 100f; // 能量初始值
    private bool isRecovering = false;
    private float powerRecoveryRate = 20f; // 能量恢复速率，每秒恢复量
    private float powerDrainRate = 50f; // 能量消耗速率，每秒消耗量

    private void Start()
    {
        UpdateHPDisplay();
        UpdateHealthBar((float)hpValue / 100); // 假设最大HP是100
        UpdatePowerBar(powerValue / 100f);
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
            RecoverPower();
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

    public void DrainPower()
    {
        powerValue -= powerDrainRate * Time.deltaTime;
        powerValue = Mathf.Clamp(powerValue, 0, 100);
        UpdatePowerBar(powerValue / 100f);
        isRecovering = powerValue > 0;
    }

    public void RecoverPower()
    {
        powerValue += powerRecoveryRate * Time.deltaTime;
        powerValue = Mathf.Clamp(powerValue, 0, 100);
        UpdatePowerBar(powerValue / 100f);
    }

    private void UpdatePowerBar(float percentage)
    {
        powerImage.fillAmount = percentage;
    }

}
