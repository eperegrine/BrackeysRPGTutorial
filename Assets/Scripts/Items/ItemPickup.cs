
using System;
using UnityEngine;

public class ItemPickup : Interactable {

    public Item item;

    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    private void Pickup()
    {
        if (Inventory.instance.Add(item))
        {
            Destroy(gameObject);
        }
    }
}
