using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform itemSlots;

    public Sprite TempWood;

    private bool itemAdded = false;

    Inventory inventory;

    public InventorySlot[] slots;

	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;

        slots = itemSlots.GetComponentsInChildren<InventorySlot>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateUI(Item item)
    {
        itemAdded = false;
        for (int i = 0; i < slots.Length; i++)
        {
            if (!itemAdded)
            {
                if (slots[i].icon.sprite != TempWood)
                {
                    if (slots[i].icon.sprite.name == item.icon.name)
                    {
                        if (slots[i].currentSlotCount < slots[i].maxSlotCount)
                        {
                            slots[i].currentSlotCount++;
                            slots[i].AddItem(item);
                            itemAdded = true;
                        }
                    }
                }
                else if (i < inventory.items.Count)
                {
                    slots[i].AddItem(item);
                    itemAdded = true;
                }
            }
        }
    }

    public bool ItemAddedToInventory()
    {
        return itemAdded;
    }
}
