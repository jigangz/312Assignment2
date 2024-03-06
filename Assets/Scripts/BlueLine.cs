using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlueLine : MonoBehaviour
{
    public GameObject dialogPanel;
    public Text dialogText;

    private Queue<string> sentences;
    public bool isDisplayingDialogue = false;

    void Start()
    {
        sentences = new Queue<string>();
        dialogPanel.SetActive(false);

        string[] initialDialogLines = new string[] {
            "Why you come back?",
            "Oh, so you saw these notes.",
            "Great!Now let's try the real game! "
        };

        TriggerInitialDialog(initialDialogLines);
    }

    public void TriggerInitialDialog(string[] dialogLines)
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
        // 使用字符串"Act5"作为场景名
         SceneManager.LoadScene("BossScene");
    }


    void Update()
    {
        if (isDisplayingDialogue && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            DisplayNextSentence();
        }
    }
    public bool IsDisplayingDialogue
    {
        get { return isDisplayingDialogue; }
    }
}
