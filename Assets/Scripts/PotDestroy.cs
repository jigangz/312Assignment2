using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotDestroy : ToolHit
{
    public GameObject foodPrefab; // 食物预制体的引用
    public AudioSource destroySound; // 引用AudioSource组件

    public override void Hit()
    {
        // 播放破碎声音
        if (destroySound != null)
        {
            destroySound.Play();
        }

        // 实例化食物预制体在当前陶罐位置
        Instantiate(foodPrefab, transform.position, Quaternion.identity);

        // 确保声音播放完毕后再销毁陶罐对象
        Destroy(gameObject, destroySound.clip.length);
    }
}
