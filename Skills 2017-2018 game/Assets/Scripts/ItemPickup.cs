using UnityEngine;

public class ItemPickup : Interactable {

    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        bool itemPickedUp = Inventory.instance.Add(item);
        InventoryUI uiManager = FindObjectOfType<InventoryUI>();
        if (itemPickedUp)
        {
            uiManager.UpdateUI(item);
            if(uiManager.ItemAddedToInventory())
            {
                Destroy(gameObject);
            }
            else
            {
                Inventory.instance.Remove(item);
            }
        }        
    }

}
