using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoiceLine : MonoBehaviour
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
            "Pick one door . ...",
             "Blue represents your kindness, while red awakens your desire for slaughter",
            //"Great! now you can use a pickaxe to break the rocks! Break the rocks to find a way out! "
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
        // ʹ���ַ���"Act5"��Ϊ������
        // SceneManager.LoadScene("Act6");
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

