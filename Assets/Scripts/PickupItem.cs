using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public string itemName = "objeto";
    public Sprite itemSprite;
    public AudioClip pickupSound;
    private bool playerInRange = false;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            bool added = InventoryManager.instance.AddItem(itemSprite, itemName);
            if (added)
            {
                if (pickupSound != null)
                {
                    audioSource.PlayOneShot(pickupSound);
                }

                PickupUI.instance.HideMessage();

                Destroy(gameObject, pickupSound != null ? pickupSound.length : 0f);

            }
            else
            {
                PickupUI.instance.ShowMessage("Inventario lleno");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            PickupUI.instance.ShowMessage("Presiona E para recoger " + itemName);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            PickupUI.instance.HideMessage();
        }
    }
}



