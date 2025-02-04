using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
  public static SelectionManager Instance {get; set; }

  public GameObject interaction_Info_UI;
  Text interaction_text;
  public bool onTarget;
  public bool borrar;

  public GameObject selectedObject;

  public Image centerDotImage;
  public Image handIcon;

  private void Awake()
  {
    if (Instance != null && Instance != this) Destroy(gameObject);
    else Instance = this;
  }
  private void Start()
  {
    interaction_text = interaction_Info_UI.GetComponent<Text>();
    onTarget = false;
  }

  void Update()
  {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit))
    {
      Transform selectionTransform = hit.transform;
      InteractableObject interactableObject = selectionTransform.GetComponent<InteractableObject>();

      if (interactableObject && interactableObject.playerInRange)
      {
        interaction_text.text = interactableObject.GetItemName();
        interaction_Info_UI.SetActive(true);
        onTarget = true;
        selectedObject = interactableObject.gameObject;

        if (interactableObject.CompareTag("pickable")) ShowIconView(handIcon);
        else ShowIconView(centerDotImage);
      }
      else
      {
        interaction_Info_UI.SetActive(false);
        onTarget = false;
        ShowIconView(centerDotImage);
      }
    }
    else
    {
      interaction_Info_UI.SetActive(false);
      onTarget = false;
      ShowIconView(centerDotImage);
    }
  }

  private void ShowIconView(Image icon)
  {
    centerDotImage.gameObject.SetActive(false);
    handIcon.gameObject.SetActive(false);

    icon.gameObject.SetActive(true);
  }

  public void DisableSelection()
  {
    handIcon.enabled = false;
    centerDotImage.enabled = false;
    interaction_Info_UI.SetActive(false);
    selectedObject = null;
  }

  public void EnableSelection()
  {
    handIcon.enabled = true;
    centerDotImage.enabled = true;
    interaction_Info_UI.SetActive(true);
  }
}
