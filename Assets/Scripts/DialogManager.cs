using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogPanel; // The dialog box panel
    public Text dialogText; // The text component that displays the dialog
    public GameObject optionsPanel;  // The panel containing option buttons
    public Button option1Button; // Option 1 button
    public Button option2Button; // Option 2 button

    private Queue<string> sentences; // Queue to store dialogue sentences
    private bool isDisplayingDialogue = false; // Flag to check if dialogue is currently being displayed


    void Start()
    {
        sentences = new Queue<string>();
        dialogPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void StartDialog(string[] dialogLines)
    {
        sentences.Clear();
        foreach (string line in dialogLines)
        {
            sentences.Enqueue(line);
        }

        dialogPanel.SetActive(true);
        isDisplayingDialogue = true; // Start displaying dialogue
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            StartCoroutine(ShowOptionsAfterDelay(1));  // Wait 1 second after dialogue ends before showing options
            isDisplayingDialogue = false;  // Stop displaying dialogue
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }

    IEnumerator ShowOptionsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ShowOptions();
    }

    void ShowOptions()
    {
        dialogPanel.SetActive(false); // Ensure the dialogue box is hidden when options are shown
        optionsPanel.SetActive(true);
        option1Button.onClick.RemoveAllListeners();
        option2Button.onClick.RemoveAllListeners();

        option1Button.onClick.AddListener(delegate { ChooseOption(1); });
        option2Button.onClick.AddListener(delegate { ChooseOption(2); });

        option1Button.GetComponentInChildren<Text>().text = "Choose Forgiveness";
        option2Button.GetComponentInChildren<Text>().text = "Choose Kill";
    }

    public void ChooseOption(int option)
    {
        dialogPanel.SetActive(false); // Ensure the dialogue box is hidden again
        optionsPanel.SetActive(false); // Hide the options panel

        switch (option)
        {
            case 1:
                SceneManager.LoadScene("Maze");
                break;
            case 2:
                SceneManager.LoadScene("EnemyScene");
                break;
        }
    }

    void Update()
    {
        // Check if the user has clicked the left mouse button or pressed the space bar, and ensure we are currently displaying dialogue
        if (isDisplayingDialogue && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            DisplayNextSentence();
        }
    }
}
