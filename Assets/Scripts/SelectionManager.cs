using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
  #region Properties
  public static SelectionManager Instance {get; set; }

  public GameObject interaction_Info_UI;
  Text interaction_text;
  public bool onTarget;
  public bool borrar;

  public GameObject selectedObject;

  public Image centerDotImage;
  public Image handIcon;

  public bool handIsVisible;

  public GameObject selectedTree;
  public GameObject chopHolder;
  #endregion

  #region Methods
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

      NPC npc = selectionTransform.GetComponent<NPC>();
      if (npc && npc.playerInRange)
      {
        interaction_text.text = "Talk";
        interaction_Info_UI.SetActive(true);

        if (Input.GetMouseButtonDown(0) && !npc.isTalkingWithPlayer) npc.StartConversation();

        if (DialogSystem.Instance.dialogUIActive)
        {
          interaction_Info_UI.SetActive(false);
          centerDotImage.gameObject.SetActive(false);
        }
      }
      else
      {
        interaction_text.text = "";
        interaction_Info_UI.SetActive(false);
      }

      Animal animal = selectionTransform.GetComponent<Animal>();
      if (animal && animal.playerInRange)
      {
        interaction_text.text = animal.animalName;
        interaction_Info_UI.SetActive(true);

        if (Input.GetMouseButtonDown(0) && EquipSystem.Instance.IsHoldingWeapon()) StartCoroutine(DealDamageTo(animal, 0.6f, EquipSystem.Instance.GetWeaponDamage()));
      }
      else
      {
        interaction_text.text = "";
        interaction_Info_UI.SetActive(false);
      }

      ChoppableTree choppableTree = selectionTransform.GetComponent<ChoppableTree>();
      if (choppableTree && choppableTree.playerInRange)
      {
        choppableTree.canBeChopped = true;
        selectedTree = choppableTree.gameObject;
        chopHolder.gameObject.SetActive(true);
      }
      else
      {
        if (selectedTree != null)
        {
          selectedTree.gameObject.GetComponent<ChoppableTree>().canBeChopped = false;
          selectedTree = null;
          chopHolder.gameObject.SetActive(false);
        }
      }

      if (interactableObject && interactableObject.playerInRange)
      {
        interaction_text.text = interactableObject.GetItemName();
        interaction_Info_UI.SetActive(true);
        onTarget = true;
        selectedObject = interactableObject.gameObject;

        if (interactableObject.CompareTag("pickable"))
        {
          ShowIconView(handIcon);
          handIsVisible = true;
        }
        else
        {
          ShowIconView(centerDotImage);
          handIsVisible = false;
        }
      }
      else
      {
        onTarget = false;
        //interaction_Info_UI.SetActive(false);
        ShowIconView(centerDotImage);
        handIsVisible = false;
      }
    }
    else
    {
      interaction_Info_UI.SetActive(false);
      onTarget = false;
      ShowIconView(centerDotImage);
      handIsVisible = false;
    }
  }

  private IEnumerator DealDamageTo(Animal animal, float delay, int damage)
  {
    yield return new WaitForSeconds(delay);

    animal.TakeDamage(damage);
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
  #endregion
}
