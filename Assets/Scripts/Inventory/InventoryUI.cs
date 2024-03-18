using UnityEngine;

/* This object updates the inventory UI. */

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;	// The parent object of all the items
    public GameObject inventoryUI;	// The entire UI

    Inventory inventory;	// Our current inventory

    InventorySlot[] slots;	// List of all the slots

    void Start () {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;	// Subscribe to the onItemChanged callback

        // Populate our slots array
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }
    

    // Update the inventory UI by:
    //		- Adding items
    //		- Clearing empty slots
    // This is called using a delegate on the Inventory.
    void UpdateUI ()
    {
        Debug.Log("updating ui");
        // Loop through all the slots
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)	// If there is an item to add
            {
                Debug.Log("adding item to UI: " + inventory.items[i].name);
                slots[i].AddItem(inventory.items[i]);	// Add it
            } else
            {
                // Otherwise clear the slot
                slots[i].ClearSlot();
            }
        }
    }
}