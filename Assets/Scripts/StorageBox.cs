using System.Collections.Generic;
using UnityEngine;

public class StorageBox : MonoBehaviour
{
  #region Properties
  public bool playerInRange;

  public List<string> items;

  public enum BoxType
  {
    smallBox,
    bigBox
  }

  public BoxType thisBoxType;
  #endregion

  #region Methods
  private void Update()
  {
    float distance = Vector3.Distance(PlayerState.Instance.playerBody.transform.position, transform.position);

    if (distance < 10f) playerInRange = true;
    else playerInRange = false;
  }
  #endregion
}
