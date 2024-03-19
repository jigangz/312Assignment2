using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotDestroy : ToolHit
{

    public GameObject MeatPrefab;
    

    public AudioSource destroySound; // ����AudioSource���

    
    public bool isPot = false;



    public override void Hit()
    {
        if (destroySound != null)
        {
            destroySound.Play(); // �����ƻ�����
        }



        
        if (isPot)
        {
            Instantiate(MeatPrefab, transform.position, Quaternion.identity);
        }


        // ȷ������������Ϻ������ٶ���
        Destroy(gameObject, destroySound.clip.length);
    }
}
