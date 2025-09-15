using UnityEngine;

[System.Serializable]
public class Quest
{
  #region Properties
  [Header("Bools")]
  public bool accepted;
  public bool declined;
  public bool initialDialogCompleted;
  public bool isCompleted;
  public bool hasNoRequierements;

  [Header("Quest Info")]
  public QuestInfo info;
  #endregion
}
