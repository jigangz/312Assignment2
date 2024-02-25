using UnityEngine;

public class LanternScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            string[] dialogLines = new string[] {
                "Hello, adventurer!",
                "Do you wish to proceed?",
                "HAHA What is your wish" };
            
            FindObjectOfType<DialogManager>().StartDialog(dialogLines);
        }
    }
}

