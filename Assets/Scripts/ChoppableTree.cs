using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ChoppableTree : MonoBehaviour
{
  public bool playerInRange;
  public bool canBeChopped;

  public float treeMaxHealth;
  public float treeHealth;

  private void Start() => treeHealth = treeMaxHealth;

  private void Update()
  {
    if (canBeChopped)
    {
      GlobalState.Instance.resourceHealth = treeHealth;
      GlobalState.Instance.resourceMaxHealth = treeMaxHealth; 
    }
  }

  public void GetHit() => StartCoroutine(hit());

  public IEnumerator hit()
  {
    yield return new WaitForSeconds(0.8f);
    treeHealth -= 1;
  }

  private void OnTriggerEnter( Collider other ) { if (other.CompareTag("Player")) playerInRange = true; }
  private void OnTriggerExit( Collider other ) { if (other.CompareTag("Player")) playerInRange = false; }
}
