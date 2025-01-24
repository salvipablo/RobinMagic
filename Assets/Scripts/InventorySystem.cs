using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
  public static InventorySystem Instance { get; set; }
  public GameObject inventoryScreenUI;
  public bool isOpen;
  
  public List<GameObject> slotList = new List<GameObject>();
  public List<string> itemList = new List<string>();
  private GameObject itemToAdd;
  private GameObject whatSlotToEquip;

  private void Awake()
  {
    if (Instance != null && Instance != this) Destroy(gameObject);
    else Instance = this;
  }

  void Start()
  {
    isOpen = false;
    PopulateSlotList();
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.I) && !isOpen)
    {
      Cursor.lockState = CursorLockMode.None;
      inventoryScreenUI.SetActive(true);
      isOpen = true;
    }
    else if (Input.GetKeyDown(KeyCode.I) && isOpen)
    {
      if (!CraftingSystem.Instance.isOpen) Cursor.lockState = CursorLockMode.Locked;
      inventoryScreenUI.SetActive(false);
      isOpen = false;
    }
  }

  private void PopulateSlotList()
  {
    foreach (Transform child in inventoryScreenUI.transform)
    {
      if (child.CompareTag("Slot"))
      {
        slotList.Add(child.gameObject);
      }
    }
  }

  public void AddToInventory(string itemName)
  {
    whatSlotToEquip = FindNextEmptySlot();
    itemToAdd = (GameObject)Instantiate(Resources.Load<GameObject>(itemName), whatSlotToEquip.transform.position, whatSlotToEquip.transform.rotation);
    itemToAdd.transform.SetParent(whatSlotToEquip.transform);
    itemList.Add(itemName);
  }

  private GameObject FindNextEmptySlot()
  {
    foreach(GameObject slot in slotList)
    {
      if(slot.transform.childCount == 0)
      {
        return slot;
      }
    }
    return new GameObject();
  }

  public bool CheckFull()
  {
    int counter = 0;
    foreach(GameObject slot in slotList) if (slot.transform.childCount > 0) counter++;
    if (counter == 21) return true;
    return false;
  }

  public void RemoveItems(string nameToRemove, int amountToRemove)
  {
    int counter = amountToRemove;

    for (int i = slotList.Count - 1; i >= 0; i--)
    {
      if (slotList[i].transform.childCount > 0)
      {
        if (slotList[i].transform.GetChild(0).name == nameToRemove + "(Clone)" && counter != 0)
        {
          Destroy(slotList[i].transform.GetChild(0).gameObject);
          counter--;
        }
      }
    }
  }

  public void RecalculateList()
  {
    itemList.Clear();

    foreach (GameObject slot in slotList)
    {
      if (slot.transform.childCount > 0)
      {
        string name = slot.transform.GetChild(0).name.Replace("(Clone)", "").Trim();
        itemList.Add(name);
      }
    }
  }
}
