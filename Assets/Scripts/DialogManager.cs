using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
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
            //"Where am I...? I think it will be wise for me to find that lamp. I think it will become useful. ...",
            "HELP ALAD-WIN FIND ME! ",
            "Use arrow keys to move and spacebar to interact with objects. Let's start with brandishing a pickaxe by WASD..."
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

