using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotDestroy : ToolHit
{
    public GameObject foodPrefab; // ʳ��Ԥ���������
    public AudioSource destroySound; // ����AudioSource���

    public override void Hit()
    {
        // ������������
        if (destroySound != null)
        {
            destroySound.Play();
        }

        // ʵ����ʳ��Ԥ�����ڵ�ǰ�չ�λ��
        Instantiate(foodPrefab, transform.position, Quaternion.identity);

        // ȷ������������Ϻ��������չ޶���
        Destroy(gameObject, destroySound.clip.length);
    }
}
