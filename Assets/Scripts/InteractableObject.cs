using System.Linq;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
  public string ItemName;
  public bool playerInRange;

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Mouse0) && playerInRange && SelectionManager.Instance.onTarget && SelectionManager.Instance.selectedObject == gameObject)
    {
      if (InventorySystem.Instance.CheckSlotsAvailable(1))
      {
        InventorySystem.Instance.AddToInventory(ItemName);

        InventorySystem.Instance.itemsPickedUp.Add(gameObject.name);

        Destroy(gameObject);
      }
      else Debug.Log("Inventory is full");
    }
  }

  public string GetItemName()
  {
    return ItemName;
  }

  private void OnTriggerEnter( Collider other )
  {
    if ( other.CompareTag("Player") )
    {
      playerInRange = true;
    }
  }

  private void OnTriggerExit( Collider other )
  {
    if (other.CompareTag("Player"))
    {
      playerInRange = false;
    }
  }
}
