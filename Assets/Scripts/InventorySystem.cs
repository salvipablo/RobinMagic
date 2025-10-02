using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
  #region Properties
  public static InventorySystem Instance { get; set; }
  public GameObject inventoryScreenUI;
  public bool isOpen;
  public GameObject ItemInfoUi;
  
  public List<GameObject> slotList = new List<GameObject>();
  public List<string> itemList = new List<string>();
  private GameObject itemToAdd;
  private GameObject whatSlotToEquip;

  public GameObject pickupAlert;
  public Text pickupName; 
  public Image pickupImage;

  public List<string> itemsPickedUp;
  #endregion

  #region Methods
  private void Awake()
  {
    if (Instance != null && Instance != this) Destroy(gameObject);
    else Instance = this;
  }

  void Start()
  {
    isOpen = false;
    PopulateSlotList();
    Cursor.visible = false;
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.I) && !isOpen && !ConstructionManager.Instance.inConstructionMode)
    {
      OpenUI();
    }
    else if (Input.GetKeyDown(KeyCode.I) && isOpen)
    {
      CloseUI();
    }
  }

  public void OpenUI()
  {
    inventoryScreenUI.SetActive(true);

    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;

    SelectionManager.Instance.DisableSelection();
    SelectionManager.Instance.GetComponent<SelectionManager>().enabled = false;

    isOpen = true;
  }

  public void CloseUI()
  {
    inventoryScreenUI.SetActive(false);
    
    if (!CraftingSystem.Instance.isOpen && !StorageManager.Instance.storageUIOpen && !CampfireUIManager.Instance.isUiOpen)
    {
      Cursor.lockState = CursorLockMode.Locked;

      Cursor.visible = false;

      SelectionManager.Instance.EnableSelection();
      SelectionManager.Instance.GetComponent<SelectionManager>().enabled = true;
    }

    isOpen = false;
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
    //if (SaveManager.Instance.isLoading == false) SoundManager.Instance.PlaySound(SoundManager.Instance.pickupItemSound);

    whatSlotToEquip = FindNextEmptySlot();
    itemToAdd = (GameObject)Instantiate(Resources.Load<GameObject>(itemName), whatSlotToEquip.transform.position, whatSlotToEquip.transform.rotation);
    itemToAdd.transform.SetParent(whatSlotToEquip.transform);
    itemList.Add(itemName);

    TriggerPickupPopUp(itemName, itemToAdd.GetComponent<Image>().sprite);

    RecalculateList();
    CraftingSystem.Instance.RefreshNeededItems();

    QuestManager.Instance.RefreshTrackerList();
  }

  private void TriggerPickupPopUp(string itemName, Sprite itemSprite)
  {
    pickupAlert.SetActive(true);
    pickupName.text = itemName;
    pickupImage.sprite = itemSprite;
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

  public bool CheckSlotsAvailable( int emptyMeeded)
  {
    int emptySlots = 0;
    foreach(GameObject slot in slotList) if (slot.transform.childCount <= 0) emptySlots++;
    if (emptySlots >= emptyMeeded) return true;
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
          DestroyImmediate(slotList[i].transform.GetChild(0).gameObject);
          counter--;
        }
      }
    }

    RecalculateList();
    CraftingSystem.Instance.RefreshNeededItems();

    QuestManager.Instance.RefreshTrackerList();
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

  public int CheckItemAmount(string name)
  {
    int amount = 0;
    foreach (string item in itemList) if (item == name) amount++;
    return amount;
  }
  #endregion
}
