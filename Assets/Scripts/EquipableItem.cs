using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EquipableItem : MonoBehaviour
{
  #region Properties
  public Animator animator;
  #endregion

  #region Methods
  private void Start()
  {
    animator = GetComponent<Animator>();
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(0) && !InventorySystem.Instance.isOpen && !CraftingSystem.Instance.isOpen &&
        !SelectionManager.Instance.handIsVisible && !ConstructionManager.Instance.inConstructionMode)
    {
      StartCoroutine(SwingSoundDelay());
      animator.SetTrigger("Hit");
    }
  }

  public void GetHit()
  {
    GameObject selectedTree = SelectionManager.Instance.selectedTree;
    if (selectedTree != null)
    {
      SoundManager.Instance.PlaySound(SoundManager.Instance.chopSound);
      selectedTree.GetComponent<ChoppableTree>().GetHit();
    }
  }

  private IEnumerator SwingSoundDelay()
  {
    yield return new WaitForSeconds(0.3f);
    SoundManager.Instance.PlaySound(SoundManager.Instance.toolSwingSound);
  }
  #endregion
}
