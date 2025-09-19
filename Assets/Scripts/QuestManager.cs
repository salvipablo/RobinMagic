using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
  #region Properties
  public static QuestManager Instance { get; set; }

  public List<Quest> allActiveQuests;
  public List<Quest> allCompletedQuests;
  public List<Quest> allTrackedQuests;

  [Header("QuestMenu")]
  public GameObject questMenu;
  public bool isQuestMenuOpen;

  public GameObject activeQuestPrefab;
  public GameObject completedQuestPrefab;

  public GameObject questMenuContent;

  [Header("QuestTracker")]
  public GameObject questTrackerContent;
  public GameObject trackerRowPrefab;
  #endregion

  #region Methods
  private void Awake()
  {
    if (Instance != null && Instance != this) Destroy(gameObject);
    else Instance = this;
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Q) && !isQuestMenuOpen && !ConstructionManager.Instance.inConstructionMode)
    {
      questMenu.SetActive(true);

      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;

      SelectionManager.Instance.DisableSelection();
      SelectionManager.Instance.GetComponent<SelectionManager>().enabled = false;

      isQuestMenuOpen = true;
    }
    else if (Input.GetKeyDown(KeyCode.Q) && isQuestMenuOpen)
    {
      questMenu.SetActive(false);

      if (!CraftingSystem.Instance.isOpen || !InventorySystem.Instance.isOpen)
      {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SelectionManager.Instance.EnableSelection();
        SelectionManager.Instance.GetComponent<SelectionManager>().enabled = true;
      }

      isQuestMenuOpen = false;
    }
  }

  public void AddActiveQuest(Quest quest)
  {
    allActiveQuests.Add(quest);
    TrackQuest(quest);
    RefreshQuestList();
  }

  public void MarkQuestCompleted(Quest quest)
  {
    allActiveQuests.Remove(quest);
    allCompletedQuests.Add(quest);
    UnTrackQuest(quest);
    RefreshQuestList();
  }

  public void RefreshQuestList()
  {
    foreach (Transform child in questMenuContent.transform) Destroy(child.gameObject);

    foreach (Quest activeQuest in allActiveQuests)
    {
      GameObject questPrefab = Instantiate(activeQuestPrefab, Vector3.zero, Quaternion.identity);
      questPrefab.transform.SetParent(questMenuContent.transform, false);

      QuestRow qRow = questPrefab.GetComponent<QuestRow>();

      qRow.thisQuest = activeQuest;

      qRow.questName.text = activeQuest.questName;
      qRow.questGiver.text = activeQuest.questGiver;

      qRow.isActive = true;
      qRow.isTracking = true;

      qRow.coinAmount.text = $"{activeQuest.info.coinReward}";

      //qRow.firstReward.sprite = "";
      qRow.firstRewardAmount.text = "";

      //qRow.secondReward.sprite = "";
      qRow.secondRewardAmount.text = "";
    }

    foreach (Quest completedQuest in allCompletedQuests)
    {
      GameObject questPrefab = Instantiate(completedQuestPrefab, Vector3.zero, Quaternion.identity);
      questPrefab.transform.SetParent(questMenuContent.transform, false);

      QuestRow qRow = questPrefab.GetComponent<QuestRow>();

      qRow.questName.text = completedQuest.questName;
      qRow.questGiver.text = completedQuest.questGiver;

      qRow.isActive = true;
      qRow.isTracking = true;

      qRow.coinAmount.text = $"{completedQuest.info.coinReward}";

      //qRow.firstReward.sprite = "";
      qRow.firstRewardAmount.text = "";

      //qRow.secondReward.sprite = "";
      qRow.secondRewardAmount.text = "";
    }

  }

  public void TrackQuest(Quest quest)
  {
    allTrackedQuests.Add(quest);
    RefreshTrackerList();
  }

  public void UnTrackQuest(Quest quest)
  {
    allTrackedQuests.Remove(quest);
    RefreshTrackerList();
  }

  public void RefreshTrackerList()
  {
    foreach (Transform child in questTrackerContent.transform) Destroy(child.gameObject);

    foreach (Quest trackedQuest in allTrackedQuests)
    {
      GameObject trackerPrefab = Instantiate(trackerRowPrefab, Vector3.zero, Quaternion.identity);
      trackerPrefab.transform.SetParent(questTrackerContent.transform, false);

      TrackerRow tRow = trackerPrefab.GetComponent<TrackerRow>();

      tRow.questName.text = trackedQuest.questName;
      tRow.questDescription.text = trackedQuest.questDescription;

      if (trackedQuest.info.secondRequirmentItem != "") // if we have 2 requirements
      {
        tRow.questRequierements.text = $"{trackedQuest.info.firstRequirmentItem}" + $"{InventorySystem.Instance.CheckItemAmount(trackedQuest.info.firstRequirmentItem)}/" + $"{trackedQuest.info.firstRequirementAmount}\n" +
       $"{trackedQuest.info.secondRequirmentItem}" + $"{InventorySystem.Instance.CheckItemAmount(trackedQuest.info.secondRequirmentItem)}/" + $"{trackedQuest.info.secondRequirementAmount}\n";
      }
      else // if we have only one
      {
        tRow.questRequierements.text = $"{trackedQuest.info.firstRequirmentItem} {InventorySystem.Instance.CheckItemAmount(trackedQuest.info.firstRequirmentItem)}/{trackedQuest.info.firstRequirementAmount}";
      }
    }
  }
  #endregion
}
