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
   // private Character currentCharacter; // ��ǰ��ɫ����
    private bool isRecovering; // �Ƿ��ڻָ�����

    //public static event Action<int> OnPlayerHealthReduced;
    public event Action OnPlayerHealthReduced; // �¼�����
    
    private void Start()
    {
        UpdateHPDisplay();
        UpdateHealthBar((float)hpValue / 100); // �������HP��100
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
    //public void OnPowerChange(Character character)
   // {
       // isRecovering = true;
   //     currentCharacter = character;
    //}
}
