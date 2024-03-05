using UnityEngine;
using UnityEngine.SceneManagement; // 导入场景管理的命名空间
public class Lamp : MonoBehaviour
{
    private bool hasInteracted = false; // 确保交互只发生一次

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasInteracted) // 检测玩家标签，确保未曾交互
        {
            InteractWithLamp();
            Debug.Log("Player entered lamp trigger zone.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left lamp trigger zone."); // 玩家离开时记录日志
        }
    }

    void InteractWithLamp()
    {
        Debug.Log("Interacting with lamp...");
        hasInteracted = true;
        string[] dialogLinesAfterLamp = new string[] {
            "Oh hey, you found me!",
            "Who are you???",
            "I am the Genie of the lamp! I am guessing that there’s a movie made about me... so I am assuming that you know me.",
            "So I’ll skip introduction. Just so you know, I can’t help you get out of this cave.",
            "WHAT?? That’s bad news....",
            "Yeah, yeah, uh, but what I can do is that I can help you destroy stuff? Like, do you want to kill that guy who put you here? Your Choice"

        };

        // 直接触发对话而不是展示选项
        FindObjectOfType<DialogManager>().TriggerInitialDialog(dialogLinesAfterLamp);
    }
    void Update()
    {
        // 检查对话是否结束，且之前已经发生了交互
        if (hasInteracted && !FindObjectOfType<DialogManager>().IsDisplayingDialogue)
        {
            // 加载指定的场景
            SceneManager.LoadScene("ChoiceGen");
        }
    }
}
