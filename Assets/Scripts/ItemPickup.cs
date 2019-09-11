using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        var wasPickedUp = Inventory.singleton.Add(item);

        Debug.Log("PickUp: " + item.name + " => " + (wasPickedUp ? Inventory.singleton.items.Count.ToString() : " <rejected>"));

        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
