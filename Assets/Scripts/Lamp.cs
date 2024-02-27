using UnityEngine;

public class Lamp : MonoBehaviour
{
    private bool hasInteracted = false; // ȷ������ֻ����һ��

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasInteracted) // �����ұ�ǩ��ȷ��δ������
        {
            InteractWithLamp();
            Debug.Log("Player entered lamp trigger zone.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left lamp trigger zone."); // ����뿪ʱ��¼��־
        }
    }

    void Update()
    {
        // ����Ѿ�����������ҶԻ���������ʾѡ��
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
            "I am the Genie of the lamp! I am guessing that there��s a movie made about me... so I am assuming that you know me. ",
            "So I��ll skip introduction. Just so you know I can��t help you get out of this cave. ",
            "WHAT?? That��s bad news....  ",
            "yeah, yeah, uh, but what I can do is that I can help you destroy stuff? Like do you want to kill that guy who put you here? "
        };

        FindObjectOfType<DialogManager>().TriggerInitialDialog(dialogLinesAfterLamp);
    }
}
