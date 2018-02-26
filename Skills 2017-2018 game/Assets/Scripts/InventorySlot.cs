using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public Item item;

    public Image icon;
    public Text text;
    public int maxSlotCount = 20;
    public int currentSlotCount = 1;
    public Sprite TempWood;

    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance;
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        text.text = currentSlotCount.ToString();
    }

    public void RemoveItem(int num)
    {
        currentSlotCount -= num;
        if(currentSlotCount <= 0)
        {
            for(int i = 0; i < num; i++)
            {
                inventory.Remove(item);
            }
            item = null;
            icon.sprite = TempWood;
            icon.gameObject.SetActive(false);
            text.gameObject.SetActive(false);
            text.text = "";
            currentSlotCount = 1;
        }
        else
        {
            text.text = currentSlotCount.ToString();
        }
    }
}
