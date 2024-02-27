using UnityEngine;

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

    void Update()
    {
        // 如果已经与灯笼交互且对话结束，显示选项
        if (hasInteracted && !FindObjectOfType<DialogManager>().IsDisplayingDialogue)
        {
            FindObjectOfType<DialogManager>().ShowOptionsAfterInteraction();
        }
    }

    void InteractWithLamp()
    {
        Debug.Log("Interacting with lamp...");
        hasInteracted = true;
        string[] dialogLinesAfterLamp = new string[] {
            "oh hey you found me! ",
            "Who are you??? ",
            "I am the Genie of the lamp! I am guessing that there’s a movie made about me... so I am assuming that you know me. ",
            "So I’ll skip introduction. Just so you know I can’t help you get out of this cave. ",
            "WHAT?? That’s bad news....  ",
            "yeah, yeah, uh, but what I can do is that I can help you destroy stuff? Like do you want to kill that guy who put you here? "
        };

        FindObjectOfType<DialogManager>().TriggerInitialDialog(dialogLinesAfterLamp);
    }
}
