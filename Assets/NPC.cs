using System;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour
{
  #region Properties
  public bool playerInRange;
  public bool isTalkingWithPlayer;
  #endregion

  #region Methods
  private void OnTriggerEnter( Collider other )
  {
    if (other.CompareTag("Player")) playerInRange = true;
  }

  private void OnTriggerExit( Collider other )
  {
    if (other.CompareTag("Player")) playerInRange = false;
  }

  public void StartConversation()
  {
    isTalkingWithPlayer = true;

    DialogSystem.Instance.OpenDialogUI();
    DialogSystem.Instance.dialogText.text = "Hello there";
    DialogSystem.Instance.option1BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Bye";
    DialogSystem.Instance.option1BTN.onClick.AddListener(() =>
    {
      DialogSystem.Instance.CloseDialogUI();
      isTalkingWithPlayer = false;
    });
  }
  #endregion
}
