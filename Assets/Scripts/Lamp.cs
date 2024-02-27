using UnityEngine;

public class Lamp : MonoBehaviour
{
    private bool hasInteracted = false; // 确保交互只发生一次
    private bool isPlayerNear = false; // 检测玩家是否在灯笼附近

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 检测玩家标签
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            Debug.Log("Player entered lamp trigger zone.");
        }
    }

    void Update()
    {
        // 玩家靠近并按下空格键时进行互动
        if (isPlayerNear && Input.GetKeyDown(KeyCode.Space) && !hasInteracted)
        {
            InteractWithLamp();

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key pressed.");
        }

        // 如果已经与灯笼交互且对话结束，显示选项
        if (hasInteracted && !FindObjectOfType<DialogManager>().isDisplayingDialogue)
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
            "WHo are you??? ",
            "I am the Genie of the lamp! I am guessing that there’s a movie made about me... so I am assuming that you know me. ",
            "So i’ll skip introduction. Just so you know I can’t help you get out of this cave. ",
            "WHAT?? That’s a bad news....  ",
            "yeah, yeah, uh, but what I can do is that I can help you destroy stuff? Like do you want to kill that guy who put you here? "
        };

        FindObjectOfType<DialogManager>().TriggerInitialDialog(dialogLinesAfterLamp);
    }
}

