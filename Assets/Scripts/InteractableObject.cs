using System.Linq;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
  public string ItemName;
  public bool playerInRange;

  // Programacion mia para no intentar almacenar objetos no almacenables, como los arboles, porque se genera error.
  // Podria ser que se arregle mas adelante en el tutorial.
  private string[] storableObjects = { "Stone", "Wood", "Stick", "Log" };

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Mouse0) && playerInRange && SelectionManager.Instance.onTarget 
                          && SelectionManager.Instance.selectedObject == gameObject && isItAStorableObject(ItemName))  // isItAStorableObject(ItemName) codigo mio.
    {
      if (!InventorySystem.Instance.CheckFull())
      {
        InventorySystem.Instance.AddToInventory(ItemName);
        Destroy(gameObject);
      }
      else Debug.Log("Inventory is full");
    }
  }

  // Programacion mia para no intentar almacenar objetos no almacenables, como los arboles, porque se genera error.
  // Podria ser que se arregle mas adelante en el tutorial.
  private bool isItAStorableObject(string itemName) => storableObjects.Contains(itemName);

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
