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
    public AudioSource destroySound; // 引用AudioSource组件
    public bool isSpecial = false;
    public bool isSuper = false;
    public bool isSpicy = false;
    public bool isNote = false;
    public bool isPaper = false;
    public bool isLetter = false;

    public override void Hit()
    {
        if (destroySound != null)
        {
            destroySound.Play(); // 播放破坏声音
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

        // 确保声音播放完毕后再销毁对象
        Destroy(gameObject, destroySound.clip.length);
    }
}
