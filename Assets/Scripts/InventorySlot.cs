using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image itemImage;

    public void SetItem(Sprite sprite)
    {
        itemImage.sprite = sprite;
        itemImage.enabled = true;
    }
}
