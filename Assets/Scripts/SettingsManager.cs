using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static SaveManager;

public class SettiingsManager : MonoBehaviour
{
  #region Properties
  public static SettiingsManager Instance { get; set; }

  public Slider masterSlider;
  public GameObject masterValue;
  public Slider musicSlider;
  public GameObject musicValue;
  public Slider effectsSlider;
  public GameObject effectsValue;

  public Button backBTN;
  #endregion

  #region Methods
  private void Awake()
  {
    if (Instance != null && Instance != this) Destroy(gameObject);
    else Instance = this;
  }

  private void Start()
  {
    backBTN.onClick.AddListener(() =>
    {
      SaveManager.Instance.SaveVolumeSetting(musicSlider.value, effectsSlider.value, masterSlider.value);
    });

    StartCoroutine(LoadAndApplySettings());
  }

  private void Update()
  {
    masterValue.GetComponent<TextMeshProUGUI>().text = $"{masterSlider.value}";
    musicValue.GetComponent<TextMeshProUGUI>().text = $"{musicSlider.value}";
    effectsValue.GetComponent<TextMeshProUGUI>().text = $"{effectsSlider.value}";
  }

  private IEnumerator LoadAndApplySettings()
  {
    LoadAndSetVolume();
    yield return new WaitForSeconds(0.1f);
  }

  private void LoadAndSetVolume()
  {
    VolumeSettings volumeSettings = SaveManager.Instance.LoadVolumeSettings();

    masterSlider.value = volumeSettings.master;
    musicSlider.value = volumeSettings.music;
    effectsSlider.value = volumeSettings.effects;
  }
  #endregion
}
