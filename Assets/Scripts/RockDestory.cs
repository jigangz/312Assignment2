using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDestroy : ToolHit
{
    public GameObject lampPrefab;
    public GameObject cavePrefab;
    public GameObject holePrefab;
    public AudioSource destroySound; // ����AudioSource���
    public bool isSpecial = false;
    public bool isSuper = false;
    public bool isSpicy = false;

    public override void Hit()
    {
        if (destroySound != null)
        {
            destroySound.Play(); // �����ƻ�����
        }

        if (isSpecial)
        {
            Instantiate(lampPrefab, transform.position, Quaternion.identity);
        }
        if (isSuper)
        {
            Instantiate(cavePrefab, transform.position, Quaternion.identity);
        }
        if (isSpicy)
        {
            Instantiate(holePrefab, transform.position, Quaternion.identity);
        }

        // ȷ������������Ϻ������ٶ���
        Destroy(gameObject, destroySound.clip.length);
    }
}
