using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{
  public static CraftingSystem Instance { get; set; }

  public GameObject CraftingScreenUi;
  public GameObject ToolsScreenUi;
  public List<string> InventoryItemList = new List<string>();

  // Category Buttons.
  Button toolsBTN;

  // Craft Buttons.
  Button craftAxeButton;

  // Requirement Text.
  Text axeReq1, axeReq2;

  public bool isOpen;

  // All Blueprint
  public Blueprint AxeBLP = new Blueprint("Axe", "Stone", "Stick", 3, 3, 2);

  private void Awake()
  {
    if (Instance != null && Instance != this) Destroy(gameObject);
    else Instance = this;
  }

  private void Start()
  {
    isOpen = false;

    toolsBTN = CraftingScreenUi.transform.Find("ToolsButton").GetComponent<Button>();
    toolsBTN.onClick.AddListener(delegate { OpenToolsScreen(); });

    // Axe.
    axeReq1 = ToolsScreenUi.transform.Find("Axe").transform.Find("Req1").GetComponent<Text>();
    axeReq2 = ToolsScreenUi.transform.Find("Axe").transform.Find("Req2").GetComponent<Text>();
    craftAxeButton = ToolsScreenUi.transform.Find("Axe").transform.Find("Button").GetComponent<Button>();
    craftAxeButton.onClick.AddListener(delegate { CraftAnyItem(AxeBLP); });
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.C) && !isOpen)
    {
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;

      CraftingScreenUi.SetActive(true);
      isOpen = true;

      SelectionManager.Instance.DisableSelection();
      SelectionManager.Instance.GetComponent<SelectionManager>().enabled = false; 
    }
    else if (Input.GetKeyDown(KeyCode.C) && isOpen)
    {
      if (!InventorySystem.Instance.isOpen) Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;

      CraftingScreenUi.SetActive(false);
      ToolsScreenUi.SetActive(false);
      isOpen = false;

      SelectionManager.Instance.EnableSelection();
      SelectionManager.Instance.GetComponent<SelectionManager>().enabled = true;
    }
  }

  private void OpenToolsScreen()
  {
    CraftingScreenUi.SetActive(false);
    ToolsScreenUi.SetActive(true);
  }

  private void CraftAnyItem(Blueprint blueprintToCraft)
  {
    InventorySystem.Instance.AddToInventory(blueprintToCraft.itemName);

    InventorySystem.Instance.RemoveItems(blueprintToCraft.req1, blueprintToCraft.req1Amount);
    if (blueprintToCraft.numOfRequirements > 1) InventorySystem.Instance.RemoveItems(blueprintToCraft.req2, blueprintToCraft.req2Amount);

    StartCoroutine(calculate());
  }

  public IEnumerator calculate()
  {
    yield return 0;
    InventorySystem.Instance.RecalculateList();
    RefreshNeededItems();
  }

  public void RefreshNeededItems()
  {
    int stone_count = 0;
    int stick_count = 0;

    InventoryItemList = InventorySystem.Instance.itemList;

    foreach (string itemName in InventoryItemList)
    {
      switch (itemName)
      {
        case "Stone":
          stone_count++;
          break;
        case "Stick":
          stick_count++;
          break;
      }
    }

    //--- AXE ---//
    axeReq1.text = $"3 Stone [{stone_count}]";
    axeReq2.text = $"3 Stick [{stick_count}]";
    if (stone_count >= 3 && stick_count >= 3) craftAxeButton.gameObject.SetActive(true);
    else craftAxeButton.gameObject.SetActive(false);
  }
}
