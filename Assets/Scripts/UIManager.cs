using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI victoryMessage;
    public Button restartButton;
    public TextMeshProUGUI missingItemsMessage;
    public AudioClip winSound;
    private AudioSource audioSource;


    private void Awake()
    {
        instance = this;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
        victoryMessage.enabled = false;
        restartButton.gameObject.SetActive(false);
        missingItemsMessage.enabled = false;

        restartButton.onClick.AddListener(RestartGame);
    }

    public void ShowVictory()
    {
        victoryMessage.enabled = true;
        restartButton.gameObject.SetActive(true);
        if (winSound != null)
        {
            audioSource.PlayOneShot(winSound);
        }
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

