using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRockDestroy : ToolHit
{
   
    public GameObject holePrefab;
    public GameObject HoneyPrefab;

    public AudioSource destroySound; // ����AudioSource���
    
    public bool isSuper = false;
    public bool isPot= false;



    public override void Hit()
    {
        if (destroySound != null)
        {
            destroySound.Play(); // �����ƻ�����
        }


      
        if (isSuper)
        {
            Instantiate(holePrefab, transform.position, Quaternion.identity);
        }
        if (isPot)
        {
            Instantiate(HoneyPrefab, transform.position, Quaternion.identity);
        }


        // ȷ������������Ϻ������ٶ���
        Destroy(gameObject, destroySound.clip.length);
    }
}
