using UnityEngine;

public class Lamp : MonoBehaviour
{
    private bool hasInteracted = false; // ??????????????????

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasInteracted) // ??????????????????????????
        {
            InteractWithLamp();
            Debug.Log("Player entered lamp trigger zone.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left lamp trigger zone."); // ??????????????????
        }
    }

    void Update()
    {
        // ??????????????????????????????????????
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

            "Oh hey, you must be the new master, I presume?",
            "Who are you?",
            "I?m Genie of the lamp, I?ll skip my introduction because I am pretty sure you know who I am. I heard that there is a movie made about me. ",
            "How did you know that there?s movie about you?",
            "Um...ahem...well there?s always a way. ",
            "Okay, so I know what you want. You want to escape the cave, right?",
            "And I want to get out of this lamp. So let?s make a deal. ",
            "You go through that either of those doors and find a scroll with a spell.",
            "I just need that spell to get out this lamp. Then I?ll help you get out of here!"
        };

        FindObjectOfType<DialogManager>().TriggerInitialDialog(dialogLinesAfterLamp);
    }
}
