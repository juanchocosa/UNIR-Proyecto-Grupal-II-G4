using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI victoryMessage;
    public Button restartButton;
    public TextMeshProUGUI missingItemsMessage; // NUEVO

    private void Awake()
    {
        instance = this;

        victoryMessage.enabled = false;
        restartButton.gameObject.SetActive(false);
        missingItemsMessage.enabled = false;

        restartButton.onClick.AddListener(RestartGame);
    }

    public void ShowVictory()
    {
        victoryMessage.enabled = true;
        restartButton.gameObject.SetActive(true);
    }

    public void ShowMissingItems()
    {
        StopAllCoroutines();
        StartCoroutine(ShowTemporaryMessage("Se requiere de maletín y llave para la extracción", 3f));
    }

    private System.Collections.IEnumerator ShowTemporaryMessage(string message, float duration)
    {
        missingItemsMessage.text = message;
        missingItemsMessage.enabled = true;
        yield return new WaitForSeconds(duration);
        missingItemsMessage.enabled = false;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

