using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
  #region Properties
  public bool playerInRange;
  public bool isTalkingWithPlayer;

  private TextMeshProUGUI npcDialogText;

  private Button optionButton1;
  private TextMeshProUGUI optionButton1Text;

  private Button optionButton2;
  private TextMeshProUGUI optionButton2Text;

  public List<Quest> quests;
  public Quest currentActiveQuest = null;
  public int activeQuestIndex = 0;
  public bool firstTimeInteraction = true;
  public int currentDialog;
  #endregion

  #region Methods
  private void Start()
  {
    npcDialogText = DialogSystem.Instance.dialogText;

    optionButton1 = DialogSystem.Instance.option1BTN;
    optionButton1Text = DialogSystem.Instance.option1BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();

    optionButton2 = DialogSystem.Instance.option2BTN;
    optionButton2Text = DialogSystem.Instance.option2BTN.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player")) playerInRange = true;
  }

  private void OnTriggerExit(Collider other)
  {
    if (other.CompareTag("Player")) playerInRange = false;
  }

  public void StartConversation()
  {
    isTalkingWithPlayer = true;

    LookAtPlayer();

    if (firstTimeInteraction)
    {
      firstTimeInteraction = false;
      currentActiveQuest = quests[activeQuestIndex];
      StartQuestInitialDialog();
      currentDialog = 0;
    }
    else
    {
      if (currentActiveQuest.declined)
      {
        DialogSystem.Instance.OpenDialogUI();

        npcDialogText.text = currentActiveQuest.info.comebackAfterDecline;

        SoundManager.Instance.PlayVoiceOvers(currentActiveQuest.info.comebackAfterDeclineClip);

        optionButton1Text.text = currentActiveQuest.info.acceptOption;
        optionButton1.onClick.RemoveAllListeners();
        optionButton1.onClick.AddListener(() =>
        {
          AcceptedQuest();
        });

        optionButton2.gameObject.SetActive(true);
        optionButton2Text.text = currentActiveQuest.info.declineOption;
        optionButton2.onClick.RemoveAllListeners();
        optionButton2.onClick.AddListener(() =>
        {
          DeclinedQuest();
        });
      }

      if (currentActiveQuest.accepted && !currentActiveQuest.isCompleted)
      {
        if (AreQuestRequirementsCompleted()) 
        {
          SubmitRequiredItems();

          DialogSystem.Instance.OpenDialogUI();

          npcDialogText.text = currentActiveQuest.info.comebackCompleted;

          SoundManager.Instance.PlayVoiceOvers(currentActiveQuest.info.comebackCompletedClip);

          optionButton1Text.text = "[Take Award]";
          optionButton1.onClick.RemoveAllListeners();
          optionButton1.onClick.AddListener(() =>
          {
            ReceiveRewardAndCompleteQuest();
          });
        }
        else
        {
          DialogSystem.Instance.OpenDialogUI();
          npcDialogText.text = currentActiveQuest.info.comebackInProgress;

          SoundManager.Instance.PlayVoiceOvers(currentActiveQuest.info.comebackInProgressClip);

          optionButton1Text.text = "[Close]";
          optionButton1.onClick.RemoveAllListeners();
          optionButton1.onClick.AddListener(() =>
          {
            DialogSystem.Instance.CloseDialogUI();
            isTalkingWithPlayer = false;
          });
        }
      }

      if (currentActiveQuest.isCompleted)
      {
        DialogSystem.Instance.OpenDialogUI();

        npcDialogText.text = currentActiveQuest.info.finalWords;

        SoundManager.Instance.PlayVoiceOvers(currentActiveQuest.info.finalWordsClip);

        optionButton1Text.text = "[Close]";
        optionButton1.onClick?.RemoveAllListeners();
        optionButton1.onClick.AddListener(() =>
        {
          DialogSystem.Instance.CloseDialogUI();
          isTalkingWithPlayer = false;
        });
      }

      if (!currentActiveQuest.initialDialogCompleted)
      {
        StartQuestInitialDialog();
      }
    }
  }

  private void SubmitRequiredItems()
  {
    string firstRequiredItem = currentActiveQuest.info.firstRequirmentItem;
    int firstRequiredAmount = currentActiveQuest.info.firstRequirementAmount;
    if (firstRequiredItem != "") InventorySystem.Instance.RemoveItems(firstRequiredItem, firstRequiredAmount);

    string secondRequiredItem = currentActiveQuest.info.secondRequirmentItem;
    int secondRequiredAmount = currentActiveQuest.info.secondRequirementAmount;
    if (firstRequiredItem != "") InventorySystem.Instance.RemoveItems(secondRequiredItem, secondRequiredAmount);
  }

  private bool AreQuestRequirementsCompleted()
  {
    string firstRequiredItem = currentActiveQuest.info.firstRequirmentItem;
    int firstRequiredAmount = currentActiveQuest.info.firstRequirementAmount;

    int firstItemCounter = 0;

    foreach (string item in InventorySystem.Instance.itemList) if (item == firstRequiredItem) firstItemCounter++;

    string secondRequiredItem = currentActiveQuest.info.secondRequirmentItem;
    int secondRequiredAmount = currentActiveQuest.info.secondRequirementAmount;

    int secondItemCounter = 0;

    foreach (string item in InventorySystem.Instance.itemList) if (item == secondRequiredItem) secondItemCounter++;

    SetQuestHasCheckpoints(currentActiveQuest);

    bool allCheckPointsCompleted = false;

    if (currentActiveQuest.info.hasCheckpoints)
    {
      foreach (Checkpoint cp in currentActiveQuest.info.checkpoints)
      {
        if (!cp.isCompleted)
        {
          allCheckPointsCompleted = false;
          break;
        }

        allCheckPointsCompleted = true;
      }
    }

    if (firstItemCounter >= firstRequiredAmount && secondItemCounter >= secondRequiredAmount)
    {
      if (currentActiveQuest.info.hasCheckpoints)
      {
        if (allCheckPointsCompleted) return true;
        else return false;
      }
      else return true;
    }
    else return false;
  }

  private void SetQuestHasCheckpoints(Quest activeQuest)
  {
    if (activeQuest.info.checkpoints.Count > 0) activeQuest.info.hasCheckpoints = true;
    else activeQuest.info.hasCheckpoints = false;
  }

  private void StartQuestInitialDialog()
  {
    DialogSystem.Instance.OpenDialogUI();

    npcDialogText.text = currentActiveQuest.info.initialDialog[currentDialog];

    SoundManager.Instance.PlayVoiceOvers(currentActiveQuest.info.initialDialogClips[currentDialog]);

    optionButton1Text.text = "Next";
    optionButton1.onClick.RemoveAllListeners();
    optionButton1.onClick.AddListener(() =>
    {
      currentDialog++;
      CheckIfDialogDone();
    });

    optionButton2.gameObject.SetActive(false);
  }

  private void CheckIfDialogDone()
  {
    if (currentDialog == currentActiveQuest.info.initialDialog.Count - 1)
    {
      npcDialogText.text = currentActiveQuest.info.initialDialog[currentDialog];

      SoundManager.Instance.PlayVoiceOvers(currentActiveQuest.info.initialDialogClips[currentDialog]);

      currentActiveQuest.initialDialogCompleted = true;

      optionButton1Text.text = currentActiveQuest.info.acceptOption;
      optionButton1.onClick.RemoveAllListeners();
      optionButton1.onClick.AddListener(() =>
      {
        AcceptedQuest();
      });

      optionButton2.gameObject.SetActive(true);
      optionButton2Text.text = currentActiveQuest.info.declineOption;
      optionButton2.onClick.RemoveAllListeners();
      optionButton2.onClick.AddListener(() =>
      {
        DeclinedQuest();
      });
    }
    else
    {
      npcDialogText.text = currentActiveQuest.info.initialDialog[currentDialog];

      SoundManager.Instance.PlayVoiceOvers(currentActiveQuest.info.initialDialogClips[currentDialog]);

      optionButton1Text.text = "Next";
      optionButton1.onClick.RemoveAllListeners();
      optionButton1.onClick.AddListener(() =>
      {
        currentDialog++;
        CheckIfDialogDone();
      });
    }
  }

  private void DeclinedQuest()
  {
    currentActiveQuest.declined = true;

    npcDialogText.text = currentActiveQuest.info.declineAnswer;

    SoundManager.Instance.PlayVoiceOvers(currentActiveQuest.info.declineAnswerClip);

    optionButton1Text.text = "[Close]";
    optionButton1.onClick.RemoveAllListeners();
    optionButton1.onClick.AddListener(() =>
    {
      DialogSystem.Instance.CloseDialogUI();
      isTalkingWithPlayer = false;
    });
    optionButton2.gameObject.SetActive(false);
  }

  private void AcceptedQuest()
  {
    QuestManager.Instance.AddActiveQuest(currentActiveQuest);

    currentActiveQuest.accepted = true;
    currentActiveQuest.declined = false;

    if (currentActiveQuest.hasNoRequierements)
    {
      npcDialogText.text = currentActiveQuest.info.comebackCompleted;

      SoundManager.Instance.PlayVoiceOvers(currentActiveQuest.info.comebackCompletedClip);

      optionButton1Text.text = "[Take Reward]";
      optionButton1.onClick.RemoveAllListeners();
      optionButton1.onClick.AddListener(() =>
      {
        ReceiveRewardAndCompleteQuest();
      });
    }
    else
    {
      npcDialogText.text = currentActiveQuest.info.acceptAnswer;

      SoundManager.Instance.PlayVoiceOvers(currentActiveQuest.info.acceptAnswerClip);

      optionButton1Text.text = "[Close]";
      optionButton1.onClick.RemoveAllListeners();
      optionButton1.onClick.AddListener(() =>
      {
        DialogSystem.Instance.CloseDialogUI();
        isTalkingWithPlayer = false;
      });
      optionButton2.gameObject.SetActive(false);
    }
  }

  private void ReceiveRewardAndCompleteQuest()
  {
    QuestManager.Instance.MarkQuestCompleted(currentActiveQuest);

    currentActiveQuest.isCompleted = true;

    int coinsRecieved = currentActiveQuest.info.coinReward;
    print("You recieved " + coinsRecieved + " gold coins");

    if (currentActiveQuest.info.rewardItem1 != "") InventorySystem.Instance.AddToInventory(currentActiveQuest.info.rewardItem1);
    if (currentActiveQuest.info.rewardItem2 != "") InventorySystem.Instance.AddToInventory(currentActiveQuest.info.rewardItem2);

    activeQuestIndex++;

    if (activeQuestIndex < quests.Count)
    {
      currentActiveQuest = quests[activeQuestIndex];
      currentDialog = 0;
      DialogSystem.Instance.CloseDialogUI();
      isTalkingWithPlayer = false;
    }
    else
    {
      DialogSystem.Instance.CloseDialogUI();
      isTalkingWithPlayer = false;
      print("No more quests");
    }
  }

  public void LookAtPlayer()
  {
    Transform player = PlayerState.Instance.playerBody.transform;
    Vector3 direction = player.position - transform.position;
    transform.rotation = Quaternion.LookRotation(direction);

    float yRotation = transform.eulerAngles.y;
    transform.rotation = Quaternion.Euler(0, yRotation, 0);
  }
  #endregion
}
