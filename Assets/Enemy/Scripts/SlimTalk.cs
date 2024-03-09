using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimTalk : MonoBehaviour
{
    public Button nextButton; // 用于播放文本的按钮
    public Text dialogueText; // 显示对话文本的UI元素
    public GameObject backGate; // 最后启用的游戏物体

    private string[] dialogues; // 存储所有对话文本的数组
    private string[] buttonLabels; // 按钮上显示的文本数组
    private int currentDialogueIndex = 0; // 当前显示的对话索引

    void Start()
    {
        // 初始化对话文本，这里可以替换为你的对话内容
        dialogues = new string[] {
            "*cough*...you...you must be the last victim of Genie.",
            "He is full of lies. We, slimes, are the souls of the humans Genie killed...",
            "As your power, you can definitely defeat him!",
            "The back gate shall now be opened for you."
        };

        // 初始化按钮文本，确保数组长度与dialogues相匹配
        buttonLabels = new string[] {
            "The victim?", // 对应第一段对话
            "What?", // 对应第二段对话
            "I just wanna go...", // 对应第二段对话
            "Thank you." // 对应最后一段对话
        };

        // 初始化时显示第一段对话和按钮文本
        if (dialogueText != null && dialogues.Length > 0)
        {
            dialogueText.text = dialogues[0];
        }
        if (nextButton != null && buttonLabels.Length > 0)
        {
            nextButton.GetComponentInChildren<Text>().text = buttonLabels[0];
            nextButton.onClick.AddListener(NextDialogue);
        }

        // 默认情况下，backGate不启用
        if (backGate != null)
        {
            backGate.SetActive(false);
        }
    }

    void NextDialogue()
    {
        // 当点击按钮时，移动到下一段对话
        currentDialogueIndex++;
        if (currentDialogueIndex < dialogues.Length)
        {
            // 更新对话文本和按钮文本
            dialogueText.text = dialogues[currentDialogueIndex];
            nextButton.GetComponentInChildren<Text>().text = buttonLabels[currentDialogueIndex];
        }
        else
        {
            // 如果已经是最后一段对话，启用backGate游戏对象
            if (backGate != null)
            {
                backGate.SetActive(true);
            }
            // 并且可能隐藏或销毁对话框
            gameObject.SetActive(false); // 例如，隐藏对话框
        }
    }
}
