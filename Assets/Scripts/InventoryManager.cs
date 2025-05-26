using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public GameObject inventoryPanel;
    public InventorySlot[] slots;

    private void Awake()
    {
        instance = this;
        inventoryPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }

    public bool AddItem(Sprite itemSprite, string itemName)
    {
        foreach (InventorySlot slot in slots)
        {
            if (!slot.itemImage.enabled)
            {
                slot.SetItem(itemSprite, itemName);
                return true;
            }
        }

        Debug.Log("Inventario lleno");
        return false;
    }

    public bool HasItemByName(string name)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.itemName == name.ToLower())
            {
                return true;
            }
        }
        return false;
    }


}

