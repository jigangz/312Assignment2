using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Add this line

public class SlimTalk : MonoBehaviour
{
    public Button nextButton; // ���ڲ����ı��İ�ť
    public Text dialogueText; // ��ʾ�Ի��ı���UIԪ��
    public GameObject backGate; // ������õ���Ϸ����

    private string[] dialogues; // �洢���жԻ��ı�������
    private string[] buttonLabels; // ��ť����ʾ���ı�����
    private int currentDialogueIndex = 0; // ��ǰ��ʾ�ĶԻ�����

    void Start()
    {
        // ��ʼ���Ի��ı�����������滻Ϊ��ĶԻ�����
        dialogues = new string[] {
            "*cough*...you...you must be the last victim of Genie.",
            "He is full of lies. We, slimes, are the souls of the humans Genie killed...",
            "As your power, you can definitely defeat him!",
            "The back gate shall now be opened for you."
        };

        // ��ʼ����ť�ı���ȷ�����鳤����dialogues��ƥ��
        buttonLabels = new string[] {
            "The victim?", // ��Ӧ��һ�ζԻ�
            "What?", // ��Ӧ�ڶ��ζԻ�
            "I just wanna go...", // ��Ӧ�ڶ��ζԻ�
            "Thank you." // ��Ӧ���һ�ζԻ�
        };

        // ��ʼ��ʱ��ʾ��һ�ζԻ��Ͱ�ť�ı�
        if (dialogueText != null && dialogues.Length > 0)
        {
            dialogueText.text = dialogues[0];
        }
        if (nextButton != null && buttonLabels.Length > 0)
        {
            nextButton.GetComponentInChildren<Text>().text = buttonLabels[0];
            nextButton.onClick.AddListener(NextDialogue);
        }

        // Ĭ������£�backGate������
        if (backGate != null)
        {
            backGate.SetActive(false);
        }
    }

    void NextDialogue()
    {
//        // �������ťʱ���ƶ�����һ�ζԻ�
//        currentDialogueIndex++;
//        if (currentDialogueIndex < dialogues.Length)
//        {
//            // ���¶Ի��ı��Ͱ�ť�ı�
//            dialogueText.text = dialogues[currentDialogueIndex];
//            nextButton.GetComponentInChildren<Text>().text = buttonLabels[currentDialogueIndex];
//        }
//        else
//        {
//            // ����Ѿ������һ�ζԻ�������backGate��Ϸ����
//            if (backGate != null)
//            {
//                backGate.SetActive(true);
//            }
//            // ���ҿ������ػ����ٶԻ���
//            gameObject.SetActive(false); // ���磬���ضԻ���
//        }

// �������ťʱ���ƶ�����һ�ζԻ�
    currentDialogueIndex++;
    if (currentDialogueIndex < dialogues.Length)
    {
        // ���¶Ի��ı��Ͱ�ť�ı�
        dialogueText.text = dialogues[currentDialogueIndex];
        nextButton.GetComponentInChildren<Text>().text = buttonLabels[currentDialogueIndex];
    }
    else
    {
        // ����Ѿ������һ�ζԻ�������backGate��Ϸ����
        if (backGate != null)
        {
            backGate.SetActive(true);
        }
        // ���ҿ������ػ����ٶԻ���
        gameObject.SetActive(false); // ���磬���ضԻ���

        // Check if the last dialogue has been reached
        if (currentDialogueIndex == dialogues.Length)
        {
            // Load the "BossScene" after the last dialogue
            SceneManager.LoadScene("BossScene");
        }
    }

    }
}
