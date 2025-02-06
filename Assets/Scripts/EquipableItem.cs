using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EquipableItem : MonoBehaviour
{
  public Animator animator;

  private void Start()
  {
    animator = GetComponent<Animator>();
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(0) && !InventorySystem.Instance.isOpen && 
          !CraftingSystem.Instance.isOpen && !SelectionManager.Instance.handIsVisible)
    {
      GameObject selectedTree = SelectionManager.Instance.selectedTree;
      if (selectedTree != null) selectedTree.GetComponent<ChoppableTree>().GetHit();

      animator.SetTrigger("Hit");
    }
  }
}
