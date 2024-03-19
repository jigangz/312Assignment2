using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDestroy : ToolHit
{
    public GameObject lampPrefab;
    public GameObject cavePrefab;
    public GameObject holePrefab;
    public GameObject NotePrefab;
    public GameObject PaperPrefab;
    public GameObject LetterPrefab;
    public GameObject CherryPrefab;
    public GameObject BreadrPrefab;
    public GameObject ApplePrefab;
    public AudioSource destroySound; // ����AudioSource���
    public bool isSpecial = false;
    public bool isSuper = false;
    public bool isSpicy = false;
    public bool isNote = false;
    public bool isPaper = false;
    public bool isLetter = false;
    public bool isCherry = false;
    public bool isBread = false;
    public bool isApple = false;

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
        if (isNote)
        {
            Instantiate(NotePrefab, transform.position, Quaternion.identity);
        }
        if (isPaper)
        {
            Instantiate(PaperPrefab, transform.position, Quaternion.identity);
        }
        if (isLetter)
        {
            Instantiate(LetterPrefab, transform.position, Quaternion.identity);
        }
        if (isCherry)
        {
            Instantiate(CherryPrefab, transform.position, Quaternion.identity);

        }
        if (isBread)
        {
            Instantiate(BreadrPrefab, transform.position, Quaternion.identity);
        }
        if (isApple)
        {
            Instantiate(ApplePrefab, transform.position, Quaternion.identity);
        }

        // ȷ������������Ϻ������ٶ���
        Destroy(gameObject, destroySound.clip.length);
    }
}
