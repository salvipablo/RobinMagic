using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EquipableItem : MonoBehaviour
{
  #region Properties
  public Animator animator;

  public bool swingWait = false;
  #endregion

  #region Methods
  private void Start()
  {
    animator = GetComponent<Animator>();
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(0) && !InventorySystem.Instance.isOpen && !CraftingSystem.Instance.isOpen &&
        !SelectionManager.Instance.handIsVisible && !swingWait && !ConstructionManager.Instance.inConstructionMode)
    {
      swingWait = true;

      StartCoroutine(SwingSoundDelay());

      animator.SetTrigger("Hit");

      StartCoroutine(NewSwingDelay());
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

  private IEnumerator NewSwingDelay()
  {
    yield return new WaitForSeconds(1f);
    swingWait = false;
  }
  #endregion
}
