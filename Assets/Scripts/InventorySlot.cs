using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/* Sits on all InventorySlots. */

public class InventorySlot : MonoBehaviour {

    public Image icon;			// Reference to the Icon image

    Item item;  // Current item in the slot

    // Add item to the slot
    public void AddItem (Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        Debug.Log(icon.sprite.ToString());
    }

    // Clear the slot
    public void ClearSlot ()
    {
        item = null;

        icon.sprite = null;
    }


    // Called when the item is pressed
    public void UseItem ()
    {
        if (item != null)
        {
            item.Use();
        }
    }

}