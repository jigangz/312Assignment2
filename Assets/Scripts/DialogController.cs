using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogController : MonoBehaviour
{
    public GameObject dialogPanel; // �Ի������
    public Text dialogText; // ��ʾ�Ի��ı���UI���
    public Image dialogueImage; // ��ʾ�Ի�ͼƬ��UI���
    public Button nextButton; // ����һ������ť
    public ScreenFade screenFade; // ��Ļ���뵭������
    public string[] dialogLines; // �洢�Ի����ݵ�����
    public Sprite[] dialogueSprites; // �洢ÿ�жԻ���Ӧ��ͼƬ����
    private int currentLineIndex; // ��ǰ��ʾ�ĶԻ�������
    public string nextSceneName; // ��Ҫ���صĳ�������

    IEnumerator Start()
    {
        dialogueImage.color = Color.black;
        // ȷ���Ի����ͼƬ��ʼ����
        dialogPanel.SetActive(false);
        currentLineIndex = 0;

        
        yield return StartCoroutine(screenFade.FadeFromBlack());
        dialogueImage.color = Color.white;
        ShowDialog(true);
    }

    public void ShowDialog(bool show)
    {
        dialogPanel.SetActive(show); // ��ʾ�����ضԻ���
        if (show && currentLineIndex < dialogLines.Length)
        {
            UpdateDialogText(dialogLines[currentLineIndex]); // ��ʾ��ǰ�еĶԻ�
            UpdateDialogueImage(currentLineIndex); // ��ʾ��Ӧ�ĶԻ�ͼƬ
        }
    }

    public void OnNextButton()
    {
        if (currentLineIndex < dialogLines.Length - 1)
        {
            currentLineIndex++; // �ƶ�����һ�жԻ�
            UpdateDialogText(dialogLines[currentLineIndex]);
            UpdateDialogueImage(currentLineIndex);
        }
        else
        {
            StartCoroutine(EndDialogSequence()); // ���жԻ���ʾ��ϣ���ʼ��������
        }
    }

    IEnumerator EndDialogSequence()
    {
        ShowDialog(false); // ���ضԻ���
        yield return StartCoroutine(screenFade.FadeToBlack()); // ���뵽��ɫ
        SceneManager.LoadScene(nextSceneName); // ʹ�ñ����еĳ��������س���
    }

    void UpdateDialogText(string text)
    {
        dialogText.text = text; // ���¶Ի����ı�
    }

    void UpdateDialogueImage(int index)
    {
        if (index < dialogueSprites.Length)
        {
            dialogueImage.sprite = dialogueSprites[index]; // ���¶Ի�ͼƬ
        }
    }
}

