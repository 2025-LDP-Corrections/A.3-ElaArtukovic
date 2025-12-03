using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public CollectableItem typeItem;     //type item is reference to scriptable object in collectable item
    public int quantity;

    public InventoryItem(CollectableItem typeSO, int quantity)
    {
        this.typeItem = typeSO;                //the type item is equal to type scriptable object
        this.quantity = quantity;
    }
}