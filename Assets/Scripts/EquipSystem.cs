using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSystem : MonoBehaviour
{
  public static EquipSystem Instance { get; set; }

  public GameObject quickSlotsPanel;

  public List<GameObject> quickSlotsList = new List<GameObject>();

  public GameObject numbersHolder;

  public int selectedNumber = -1;
  public GameObject selectedItem;

  private void Awake()
  {
    if (Instance != null && Instance != this) Destroy(gameObject);
    else Instance = this;
  }

  private void Start() => PopulateSlotList();

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Alpha1)) SelectQuickSlot(1);
    if (Input.GetKeyDown(KeyCode.Alpha2)) SelectQuickSlot(2);
    if (Input.GetKeyDown(KeyCode.Alpha3)) SelectQuickSlot(3);
    if (Input.GetKeyDown(KeyCode.Alpha4)) SelectQuickSlot(4);
    if (Input.GetKeyDown(KeyCode.Alpha5)) SelectQuickSlot(5);
    if (Input.GetKeyDown(KeyCode.Alpha6)) SelectQuickSlot(6);
    if (Input.GetKeyDown(KeyCode.Alpha7)) SelectQuickSlot(7);
  }

  private void SelectQuickSlot(int slotNumber)
  {
    if (checkIfSlotIsFull(slotNumber))
    {
      if (selectedNumber != slotNumber)  // Si selecciono otra ranura de la que esta seleccionada, hago el proceso de seleccion de nueva ranura.
      {
        selectedNumber = slotNumber;
        if (selectedItem != null) selectedItem.gameObject.GetComponent<InventoryItem>().isSelected = false;
        selectedItem = getSelectedItem(slotNumber);
        selectedItem.GetComponent<InventoryItem>().isSelected = true;

        foreach (Transform child in numbersHolder.transform) child.transform.Find("Text").GetComponent<Text>().color = Color.white;

        Text toBeChanged = numbersHolder.transform.Find($"Number{slotNumber}").transform.Find("Text").GetComponent<Text>();
        toBeChanged.color = Color.green;
      }
      else  // Si selecciono la misma ranura que ya esta seleccionada, libero al jugador de item equipado.
      {
        selectedNumber = -1;
        if (selectedItem != null)
        {
          selectedItem.gameObject.GetComponent<InventoryItem>().isSelected = false;
          selectedItem = null;
        }
        foreach (Transform child in numbersHolder.transform) child.transform.Find("Text").GetComponent<Text>().color = Color.white;
      }
    }
  }

  private bool checkIfSlotIsFull(int slotNumber)
  {
    if (quickSlotsList[slotNumber - 1].transform.childCount > 0) return true;
    return false;
  }

  private GameObject getSelectedItem(int slotNumber ) => quickSlotsList[slotNumber - 1].transform.GetChild(0).gameObject;

  private void PopulateSlotList()
  {
    foreach (Transform child in quickSlotsPanel.transform) if (child.CompareTag("QuickSlot")) quickSlotsList.Add(child.gameObject);
  }

  public void AddToQuickSlots( GameObject itemToEquip )
  {
    // Find next free slot
    GameObject availableSlot = FindNextEmptySlot();
    // Set transform of our object
    itemToEquip.transform.SetParent(availableSlot.transform, false);

    InventorySystem.Instance.RecalculateList();
  }

  private GameObject FindNextEmptySlot()
  {
    foreach (GameObject slot in quickSlotsList) if (slot.transform.childCount == 0) return slot;
    return new GameObject();
  }

  public bool CheckIfFull()
  {
    int counter = 0;

    foreach (GameObject slot in quickSlotsList) if (slot.transform.childCount > 0) counter += 1;

    if (counter == 7) return true;
    else return false;
  }
}
