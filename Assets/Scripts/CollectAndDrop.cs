using UnityEngine;
using UnityEngine.InputSystem;

public class CollectAndDrop : MonoBehaviour
{
    public InventoryManager invManager;
    private CollectableItem itemTC;             //named it TC for TO COLLECT
    private bool inRange = false;            //need for player check 

    public void OnCollect(InputAction.CallbackContext context)          //set LMB for collecting and RMB for dropping
    {
        if (context.performed && inRange)             //if LMB is presed and the player is in range then collect item
        {
            CollectItem();
        }
    }

    public void OnDrop(InputAction.CallbackContext context)
    {
        if (context.performed)               //if RMB is pressed then drop item
        {
            DropItem();
        }
    }

    private void CollectItem()
    {
        if (itemTC != null)                   //if an iten can be collected/not null, add the item to collect to the inventory using InvMan logic
        {
            invManager.ItemAdded(itemTC);
            itemTC = null;                       //reset it so more can be collected and it doesn't think the item i collected is still there
            inRange = false;
        }
    }

    private void DropItem()
    {
        invManager.ItemRemoved();
    }

    private void OnTriggerEnter(Collider other)
    {
        CollectableItem collectable = other.GetComponent<CollectableItem>();           //get collectible item component from other object, if it has one then set TC to the collectible and make it in range
        if (collectable != null)
        {
            itemTC = collectable;
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CollectableItem collectable = other.GetComponent<CollectableItem>();            //if item leaving is same as one in range(TC == collectable) then clear it and set it no longer in range   //NOT WORKING BECAUSE NOT MONOBEHAVIOUR
        if (collectable == itemTC)
        {
            itemTC = null;
            inRange = false;
        }
    }


}
