using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class HealthManager : MonoBehaviour
{
    public Text hpValueText; // HP�ı����
    public Image healthImage; // ����״̬��
    public Image healthDelayImage; // �ӳٸ��µĽ���״̬��
    public Image powerImage; // ����״̬��

    private int hpValue = 100; // ��ʼHPֵ
    public event Action OnPlayerHealthReduced; // �¼�����

    private float powerValue = 100f; // ������ʼֵ
    private bool isRecovering = false;
    private float powerRecoveryRate = 20f; // �����ָ����ʣ�ÿ��ָ���
    private float powerDrainRate = 50f; // �����������ʣ�ÿ��������

    private void Start()
    {
        UpdateHPDisplay();
        UpdateHealthBar((float)hpValue / 100); // �������HP��100
        UpdatePowerBar(powerValue / 100f);
    }

    private void Update()
    {
        // ����״̬���ӳٸ����߼�
        if (healthDelayImage.fillAmount > healthImage.fillAmount)
        {
            healthDelayImage.fillAmount -= Time.deltaTime * 0.1f;
        }

        // �����ָ��߼�
        if (isRecovering)
        {
            RecoverPower();
        }
    }

    public void ReduceHP(int damage)
    {
        // ����HP�߼�
        // OnPlayerHealthReduced?.Invoke(damage);
        OnPlayerHealthReduced?.Invoke(); // �����¼�

        hpValue -= damage;
        UpdateHPDisplay();
        UpdateHealthBar((float)hpValue / 100); // �������HP��100

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

    // ������һ�����������µ�ǰ��ɫ������״̬

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
