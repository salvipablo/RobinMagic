using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ChoppableTree : MonoBehaviour
{
  public bool playerInRange;
  public bool canBeChopped;

  public float treeMaxHealth;
  public float treeHealth;

  public Animator animator;

  public float caloriesSpentChoppingWood = 20;

  private void Start()
  {
    treeHealth = treeMaxHealth;
    animator = transform.parent.transform.parent.GetComponent<Animator>();
  }

  private void Update()
  {
    if (canBeChopped)
    {
      GlobalState.Instance.resourceHealth = treeHealth;
      GlobalState.Instance.resourceMaxHealth = treeMaxHealth; 
    }
  }

  public void GetHit()
  {
    animator.SetTrigger("shake");

    treeHealth -= 1;

    PlayerState.Instance.currentCalories -= caloriesSpentChoppingWood;

    if (treeHealth <= 0) TreeIsDead();
  }

  private void TreeIsDead()
  {
    Vector3 treePosition = transform.position;

    Destroy(transform.parent.transform.parent.gameObject);

    canBeChopped = false;

    SelectionManager.Instance.selectedTree = null;
    SelectionManager.Instance.chopHolder.gameObject.SetActive(false);

    GameObject brokenTree = Instantiate(Resources.Load<GameObject>("ChoppedTree"), treePosition, Quaternion.Euler(0, 0, 0));
  }

  private void OnTriggerEnter( Collider other ) { if (other.CompareTag("Player")) playerInRange = true; }
  private void OnTriggerExit( Collider other ) { if (other.CompareTag("Player")) playerInRange = false; }
}
