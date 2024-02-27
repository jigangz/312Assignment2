using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Text hpValueText; // 通过Inspector指定，假定它是你InGameUI中的一个Text组件
    private int hpValue = 100; // 初始HP值

    private void Start()
    {
        UpdateHPDisplay();
    }

    public void ReduceHP(int damage)
    {
        hpValue -= damage; // 减少HP
        UpdateHPDisplay(); // 更新显示

        if (hpValue <= 0)
        {
            // HP小于等于0，加载GameOver场景
            SceneManager.LoadScene("GameOver");
        }
    }

    private void UpdateHPDisplay()
    {
        if (hpValueText != null)
        {
            hpValueText.text = "HP: " + hpValue.ToString(); // 更新文本显示HP值
        }
    }
}
