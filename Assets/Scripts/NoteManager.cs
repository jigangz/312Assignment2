using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private Text dialogText;
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            closeButton.onClick.AddListener(HideDialog);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowDialog(string text)
    {
        dialogText.text = text;
        dialogPanel.SetActive(true);
    }

    public void HideDialog()
    {
        dialogPanel.SetActive(false);
    }
}
