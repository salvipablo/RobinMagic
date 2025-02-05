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
      animator.SetTrigger("Hit");
    }
  }
}
