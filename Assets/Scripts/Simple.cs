using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Simple : MonoBehaviour
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
            "The cave is collapsing, we need to hurry and get out!",
         
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
