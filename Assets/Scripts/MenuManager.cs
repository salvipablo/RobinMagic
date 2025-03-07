using UnityEngine;

public class MenuManager : MonoBehaviour
{
  #region Properties
  public static MenuManager Instance { get; set; }

  public GameObject MenuCanvas;
  public GameObject UiCanvas;

  public GameObject Menu;
  public GameObject SettingsMenu;
  public GameObject SaveMenu;

  public bool IsMenuOpen;
  #endregion

  #region Methods
  private void Awake()
  {
    if (Instance != null && Instance != this) Destroy(gameObject);
    else Instance = this;
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.M) && !IsMenuOpen)
    {
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;

      UiCanvas.SetActive(false);
      MenuCanvas.SetActive(true);

      SelectionManager.Instance.DisableSelection();
      SelectionManager.Instance.GetComponent<SelectionManager>().enabled = false;

      IsMenuOpen = true;
    }
    else if (Input.GetKeyDown(KeyCode.M) && IsMenuOpen)
    {
      if (!CraftingSystem.Instance.isOpen && !InventorySystem.Instance.isOpen)
      {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
      }

      Menu.SetActive(true);
      SettingsMenu.SetActive(false);
      SaveMenu.SetActive(false);

      MenuCanvas.SetActive(false);
      UiCanvas.SetActive(true);

      SelectionManager.Instance.EnableSelection();
      SelectionManager.Instance.GetComponent<SelectionManager>().enabled = true;

      IsMenuOpen = false;
    }
  }
  #endregion
}
