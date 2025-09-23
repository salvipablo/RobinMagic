using UnityEngine;

public class Village : MonoBehaviour
{
  #region Properties
  public Checkpoint reachVillage_Melina;
  #endregion

  #region Methods
  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player") ) reachVillage_Melina.isCompleted = true;
  }
  #endregion
}
