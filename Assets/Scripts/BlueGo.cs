using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueGo : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Act5");
        }
    }
}