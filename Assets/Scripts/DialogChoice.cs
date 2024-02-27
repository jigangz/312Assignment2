using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class DialogChoice : MonoBehaviour
{
    public GameObject dialogPanel; // The dialog box panel
    public Text dialogText; // The text component that displays the dialog
    public GameObject optionsPanel;  // The panel containing option buttons
    public Button option1Button; // Option 1 button
    public Button option2Button; // Option 2 button
    public Button option3Button; // Option 3 button, newly added

    void Start()
    {
        dialogPanel.SetActive(false); // Initially hide the dialogPanel
        optionsPanel.SetActive(true); // Show the optionsPanel on start

        // Setup the buttons with their respective listeners
        option1Button.onClick.AddListener(delegate { ChooseOption(1); });
        option2Button.onClick.AddListener(delegate { ChooseOption(2); });
        option3Button.onClick.AddListener(delegate { ChooseOption(3); });

        // Set the text for each button
        option1Button.GetComponentInChildren<Text>().text = "Message Ja-fart & Apply for a job ";
        option2Button.GetComponentInChildren<Text>().text = "Don¡¯t message Ja-fart ";
        option3Button.GetComponentInChildren<Text>().text = "Don¡¯t go to school";
    }

    public void ChooseOption(int option)
    {
        // The dialogue box and options panel are already set as needed at start
        switch (option)
        {
            case 1:
                SceneManager.LoadScene("Act4"); // Load the scene associated with option 1
                break;
            case 2:
                SceneManager.LoadScene("GameOver"); // Load the scene associated with option 2
                break;
            case 3:
                SceneManager.LoadScene("GameOver"); // Load the scene associated with option 3
                break;
        }
    }

    // The rest of the code related to dialogues can be removed if it's not needed
}

