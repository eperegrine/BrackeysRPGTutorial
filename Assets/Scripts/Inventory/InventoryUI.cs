using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventory inv;
    InventorySlot[] slots;

	// Use this for initialization
	void Start () {
        inv = Inventory.instance;
        inv.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
	}

    void UpdateUI ()
    {
        print("UPDATING UI");

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inv.items.Count)
            {
                slots[i].AddItem(inv.items[i]);
            } else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
