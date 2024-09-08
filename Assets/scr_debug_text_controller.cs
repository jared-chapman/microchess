using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI textElement;

    void Start()
    {
        // Set the initial text value
        textElement.text = "Welcome to the game!";
    }

    public void UpdateText(string newText)
    {
        // Update the text dynamically
        textElement.text = newText;
    }
}