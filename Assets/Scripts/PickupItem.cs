using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public string itemName = "objeto"; // Ej: "llave", "ganzúa"
    public Sprite itemSprite;

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            bool added = InventoryManager.instance.AddItem(itemSprite, itemName);
            if (added)
            {
                PickupUI.instance.HideMessage();
                Destroy(gameObject);
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



