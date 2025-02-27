using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{
  #region Properties
  public static CraftingSystem Instance { get; set; }

  public GameObject CraftingScreenUi;
  public GameObject ToolsScreenUi, SurvivalScreenUI, RefineScreenUI, ConstructionScreenUI;
  public List<string> InventoryItemList = new List<string>();

  // Category Buttons.
  Button toolsBTN, survivalBTN, refineBTN, constructionBTN;

  // Crafting Buttons.
  Button craftAxeButton, craftPlankButton, craftFoundationButtton;

  // Requirement Text.
  Text axeReq1, axeReq2, plankReq1, foundationReq1;

  public bool isOpen;

  // All Blueprint
  public Blueprint AxeBLP = new Blueprint("Axe", 1, "Stone", "Stick", 3, 3, 2);
  public Blueprint PlankBLP = new Blueprint("Plank", 2, "Log", "-", 1, 0, 1);
  public Blueprint FoundationBLP = new Blueprint("Foundation", 1, "Plank", "-", 4, 0, 1);
  #endregion

  #region Methods
  private void Awake()
  {
    if (Instance != null && Instance != this) Destroy(gameObject);
    else Instance = this;
  }

  private void Start()
  {
    isOpen = false;

    /* -- Crafting System Buttons. -- */

      // Tools crate screen button.
      toolsBTN = CraftingScreenUi.transform.Find("ToolsButton").GetComponent<Button>();
      toolsBTN.onClick.AddListener(delegate { OpenCraftingScreen(ToolsScreenUi); });
    
      // Refine crate screen button.
      refineBTN = CraftingScreenUi.transform.Find("RefineButton").GetComponent<Button>();
      refineBTN.onClick.AddListener(delegate { OpenCraftingScreen(RefineScreenUI); });

      // Construction crate screen button.
      constructionBTN = CraftingScreenUi.transform.Find("ConstructionButton").GetComponent<Button>();
      constructionBTN.onClick.AddListener(delegate { OpenCraftingScreen(ConstructionScreenUI); });

    /* -- Crafting System Buttons. -- */


    /* -- Item Requirements. -- */

      // Axe Requirements.
      axeReq1 = ToolsScreenUi.transform.Find("Axe").transform.Find("Req1").GetComponent<Text>();
      axeReq2 = ToolsScreenUi.transform.Find("Axe").transform.Find("Req2").GetComponent<Text>();

      // Plank Requirements.
      plankReq1 = RefineScreenUI.transform.Find("Plank").transform.Find("Req1").GetComponent<Text>();

      // Foundation Requirements
      foundationReq1 = ConstructionScreenUI.transform.Find("Foundation").transform.Find("Req1").GetComponent<Text>();

    /* -- Item Requirements. -- */


    /* -- Item crafting buttons. -- */

      // Axe crafting button.
      craftAxeButton = ToolsScreenUi.transform.Find("Axe").transform.Find("Button").GetComponent<Button>();
      craftAxeButton.onClick.AddListener(delegate { CraftAnyItem(AxeBLP); });

      // Plank crafting button.
      craftPlankButton = RefineScreenUI.transform.Find("Plank").transform.Find("Button").GetComponent<Button>();
      craftPlankButton.onClick.AddListener(delegate { CraftAnyItem(PlankBLP); });

      // Foundation crafting button
      craftFoundationButtton = ConstructionScreenUI.transform.Find("Foundation").transform.Find("Button").GetComponent<Button>();
      craftFoundationButtton.onClick.AddListener(delegate { CraftAnyItem(FoundationBLP); });

    /* -- Item crafting buttons. -- */
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.C) && !isOpen && !ConstructionManager.Instance.inConstructionMode)
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

      CloseCraftingScreen();
      isOpen = false;

      SelectionManager.Instance.EnableSelection();
      SelectionManager.Instance.GetComponent<SelectionManager>().enabled = true;
    }
  }
  
  public void CloseCraftingScreen()
  {
    CraftingScreenUi.SetActive(false);
    ToolsScreenUi.SetActive(false);
    SurvivalScreenUI.SetActive(false);
    RefineScreenUI.SetActive(false);
    ConstructionScreenUI.SetActive(false);
  }

  private void OpenCraftingScreen(GameObject whatScreen)
  {
    CloseCraftingScreen();
    whatScreen.SetActive(true);
  }

  private void CraftAnyItem(Blueprint blueprintToCraft)
  {
    SoundManager.Instance.PlaySound(SoundManager.Instance.craftingSound);

    StartCoroutine(craftedDelayForSound(blueprintToCraft));

    InventorySystem.Instance.RemoveItems(blueprintToCraft.req1, blueprintToCraft.req1Amount);
    if (blueprintToCraft.numOfRequirements > 1) InventorySystem.Instance.RemoveItems(blueprintToCraft.req2, blueprintToCraft.req2Amount);

    StartCoroutine(calculate());
  }

  private IEnumerator craftedDelayForSound(Blueprint blueprintToCraft)
  {
    yield return new WaitForSeconds(0.2f);
    for (int i = 0; i < blueprintToCraft.numberOfItemToProduce; i++) InventorySystem.Instance.AddToInventory(blueprintToCraft.itemName);
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
    int log_count = 0;
    int plank_count = 0;

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
        case "Log":
          log_count++;
          break;
        case "Plank":
          plank_count++;
          break;
      }
    }

    //--- AXE ---//
    axeReq1.text = $"3 Stone [{stone_count}]";
    axeReq2.text = $"3 Stick [{stick_count}]";
    if (stone_count >= 3 && stick_count >= 3 && InventorySystem.Instance.CheckSlotsAvailable(1)) craftAxeButton.gameObject.SetActive(true);
    else craftAxeButton.gameObject.SetActive(false);

    //--- PlANK x2 ---//
    plankReq1.text = $"1 Log [{log_count}]";
    if (log_count >= 1 && InventorySystem.Instance.CheckSlotsAvailable(2)) craftPlankButton.gameObject.SetActive(true);
    else craftPlankButton.gameObject.SetActive(false);

    //--- Foundation x1 ---//
    foundationReq1.text = $"4 Plank [{plank_count}]";
    if (plank_count >= 4 && InventorySystem.Instance.CheckSlotsAvailable(1)) craftFoundationButtton.gameObject.SetActive(true);
    else craftFoundationButtton.gameObject.SetActive(false);
  }
  #endregion
}
