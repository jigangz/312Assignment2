using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleDialogManager : MonoBehaviour
{
    public GameObject dialogPanel;
    public Text dialogText;

    private Queue<string> sentences;
    private bool isDisplayingDialogue = false;

    void Start()
    {
        sentences = new Queue<string>();
        dialogPanel.SetActive(false);

        string[] initialDialogLines = {
           // "whoaaaaaaa what is that sound??? oh my it seems like the cave is caving in more!!!",
           // "hey... I think that rumble might have caused this maze-like structure in the cave. Keep breaking the rocks to find the way to the next level!",
           // "I¡¯ll just take some rest in the lamp. But hey, you can use the lamp to break the rocks if that helps you with anything! "

             "Okay this seems like a mazz.",
            "There must be some way out,Maybe I can try to braek these rock to see if there any thing under.",
           // "I¡¯ll just take some rest in the lamp. But hey, you can use the lamp to break the rocks if that helps you with anything! "
        };

        StartDialog(initialDialogLines);
    }

    public void StartDialog(string[] dialogLines)
    {
        sentences.Clear();
        foreach (string line in dialogLines)
        {
            sentences.Enqueue(line);
        }

        dialogPanel.SetActive(true);
        isDisplayingDialogue = true;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }

    void EndDialogue()
    {
        isDisplayingDialogue = false;
        dialogPanel.SetActive(false);
    }

    void Update()
    {
        if (isDisplayingDialogue && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            DisplayNextSentence();
        }
    }
}
