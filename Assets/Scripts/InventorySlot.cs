using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image itemImage;
    public string itemName; // <- nuevo campo

    public void SetItem(Sprite sprite, string name)
    {
        itemImage.sprite = sprite;
        itemImage.enabled = true;
        itemName = name.ToLower(); // Guardamos el nombre del objeto
    }

    public void ClearSlot()
    {
        itemImage.sprite = null;
        itemImage.enabled = false;
        itemName = "";
    }
}
