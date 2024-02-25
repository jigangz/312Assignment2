using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DialogController : MonoBehaviour
{
    public GameObject dialogPanel; // The dialog box panel
    public Text dialogText; // The UI component that displays the dialog text
    public Button nextButton; // The "Next" button

    private string[] dialogLines; // Array that stores the dialog content
    private int currentLineIndex;  // Index of the current line of dialog being displayed


    void Start()
    {
        dialogLines = new string[]{
            "First line¡£",
            "Second",
            "Last¡£"
        };
        currentLineIndex = 0;
        ShowDialog(true);
    }

    public void ShowDialog(bool show)
    {
        dialogPanel.SetActive(show); // Show or hide the dialog box
        if (show)
        {
            UpdateDialogText(dialogLines[currentLineIndex]); // Display the current line of dialog
        }
    }

    public void OnNextButton()
    {
        currentLineIndex++; // Move to the next line of dialog
        if (currentLineIndex < dialogLines.Length)
        {
            UpdateDialogText(dialogLines[currentLineIndex]);
        }
        else
        {
            ShowDialog(false); // All dialog has been displayed, hide the dialog box
            SceneManager.LoadScene("MainScene");
        }
    }

    void UpdateDialogText(string text)
    {
        dialogText.text = text; // Update the dialog box text
    }
}
