using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogController : MonoBehaviour
{
    public GameObject dialogPanel; // 对话框面板
    public Text dialogText; // 显示对话文本的UI组件
    public Image dialogueImage; // 显示对话图片的UI组件
    public Button nextButton; // “下一步”按钮
    public ScreenFade screenFade; // 屏幕淡入淡出控制
    public string[] dialogLines; // 存储对话内容的数组
    public Sprite[] dialogueSprites; // 存储每行对话对应的图片数组
    private int currentLineIndex; // 当前显示的对话行索引
    public string nextSceneName; // 想要加载的场景名称

    IEnumerator Start()
    {
        dialogueImage.color = Color.black;
        // 确保对话框和图片初始隐藏
        dialogPanel.SetActive(false);
        currentLineIndex = 0;

        
        yield return StartCoroutine(screenFade.FadeFromBlack());
        dialogueImage.color = Color.white;
        ShowDialog(true);
    }

    public void ShowDialog(bool show)
    {
        dialogPanel.SetActive(show); // 显示或隐藏对话框
        if (show && currentLineIndex < dialogLines.Length)
        {
            UpdateDialogText(dialogLines[currentLineIndex]); // 显示当前行的对话
            UpdateDialogueImage(currentLineIndex); // 显示对应的对话图片
        }
    }

    public void OnNextButton()
    {
        if (currentLineIndex < dialogLines.Length - 1)
        {
            currentLineIndex++; // 移动到下一行对话
            UpdateDialogText(dialogLines[currentLineIndex]);
            UpdateDialogueImage(currentLineIndex);
        }
        else
        {
            StartCoroutine(EndDialogSequence()); // 所有对话显示完毕，开始结束序列
        }
    }

    IEnumerator EndDialogSequence()
    {
        ShowDialog(false); // 隐藏对话框
        yield return StartCoroutine(screenFade.FadeToBlack()); // 淡入到黑色
        SceneManager.LoadScene(nextSceneName); // 使用变量中的场景名加载场景
    }

    void UpdateDialogText(string text)
    {
        dialogText.text = text; // 更新对话框文本
    }

    void UpdateDialogueImage(int index)
    {
        if (index < dialogueSprites.Length)
        {
            dialogueImage.sprite = dialogueSprites[index]; // 更新对话图片
        }
    }
}

