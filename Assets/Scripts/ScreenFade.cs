using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 1.0f;

    void Start()
    {
        fadeImage.color = new Color(0, 0, 0, 1); 
        StartCoroutine(FadeFromBlack()); 
    }


    public IEnumerator FadeToBlack()
    {
        float alpha = fadeImage.color.a;

        while (alpha < 1f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }

    public IEnumerator FadeFromBlack()
    {
        float alpha = fadeImage.color.a;

        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
  

}
