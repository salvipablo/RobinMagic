using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
  #region Properties
  public static TimeManager Instance { get; set; }
  public int dayInGame = 1;

  public TextMeshProUGUI dayUI;
  #endregion

  #region Methods
  private void Awake()
  {
    if (Instance != null && Instance != this) Destroy(gameObject);
    else Instance = this;
  }

  private void Start() => dayUI.text = $"Day: {dayInGame}";

  public void TriggerNextDay()
  {
    dayInGame += 1;
    dayUI.text = $"Day: {dayInGame}";
  }
  #endregion
}
