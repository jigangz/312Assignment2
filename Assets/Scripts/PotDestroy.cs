using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotDestroy : ToolHit
{

    public GameObject MeatPrefab;
    

    public AudioSource destroySound; // 引用AudioSource组件

    
    public bool isPot = false;



    public override void Hit()
    {
        if (destroySound != null)
        {
            destroySound.Play(); // 播放破坏声音
        }



        
        if (isPot)
        {
            Instantiate(MeatPrefab, transform.position, Quaternion.identity);
        }


        // 确保声音播放完毕后再销毁对象
        Destroy(gameObject, destroySound.clip.length);
    }
}
