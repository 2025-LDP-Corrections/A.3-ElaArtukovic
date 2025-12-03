using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CollectableInteractor : MonoBehaviour           //handle interactions when we hit of objects, picking up and dropping
{

    public InventoryManager inventoryManager;      //reference to the inventory manager
    public StarterAssetsInputs _inputs;
    public CollectableController theItem;                //reference to scriptable object


    // Update is called once per frame
    void Update()
    {
        if (_inputs.drop == true)           //if RMB is pressed then drop item
        {
            DropItem();       //gets removed from inventory
            _inputs.drop = false;             
        }

        if (_inputs.collect == true)          //if LMB is pressed then collect
        {
            CollectItem();      //gets added to inventory
            _inputs.collect = false;
        }
    }

    private void CollectItem()
    {
        if (theItem != null)                   //if an iten can be collected/not null, add the item to collect to the inventory using InvMan logic
        {
            inventoryManager.ItemAdded(theItem.objectSO);
            Destroy(theItem.gameObject);
            theItem = null;                       //reset it so more can be collected and it doesn't think the item i collected is still there
            
        }
    }

    private void DropItem()
    {
        inventoryManager.ItemRemoved();        //remove item from inv 
    }


    private void OnTriggerEnter(Collider other)        //if player collides with gameobjects
    {
        if (other.gameObject.tag == "Collectable")
        {
            theItem = other.GetComponent<CollectableController>();       //the item being reference to scriptable object from collectable controller
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            theItem = null;
        }
    }
}
