using UnityEngine;
using TMPro;

public class PickupUI : MonoBehaviour
{
    public static PickupUI instance;
    public TextMeshProUGUI messageText;

    private void Awake()
    {
        instance = this;
        messageText.enabled = false;
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
        messageText.enabled = true;
    }

    public void HideMessage()
    {
        messageText.text = "";
        messageText.enabled = false;
    }
}


