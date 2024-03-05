using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogPanel;
    public Text dialogText;
    public GameObject optionsPanel;
    public Button option1Button;
    public Button option2Button;

    private Queue<string> sentences;
    public bool isDisplayingDialogue = false;

    void Start()
    {
        sentences = new Queue<string>();
        dialogPanel.SetActive(false);
        optionsPanel.SetActive(false);

        string[] initialDialogLines = new string[] {
            "Where am I...? I think it will be wise for me to find that lamp. I think it will become useful. ...",
            "Great! now you can use a pickaxe to break the rocks! Break the rocks to find a way out! "
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
        // ShowOptions is now removed from here
    }

    public void ShowOptionsAfterInteraction()
    {
        if (!isDisplayingDialogue)
        {
            ShowOptions();
        }
    }

    void ShowOptions()
    {
        optionsPanel.SetActive(true);
        option1Button.onClick.RemoveAllListeners();
        option2Button.onClick.RemoveAllListeners();

        option1Button.onClick.AddListener(delegate { ChooseOption(1); });
        option2Button.onClick.AddListener(delegate { ChooseOption(2); });

        option1Button.GetComponentInChildren<Text>().text = "Kill";
        option2Button.GetComponentInChildren<Text>().text = "Forgiveness";
    }

    public void ChooseOption(int option)
    {
        optionsPanel.SetActive(false);

        switch (option)
        {
            case 1:
                SceneManager.LoadScene("EnemyScene");
                break;
            case 2:
                SceneManager.LoadScene("Act5");
                break;
        }
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
