using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayNightSystem : MonoBehaviour
{
  #region Properties
  public Light directionalLight;

  public float dayDurationInSeconds = 24.0f;
  public int currentHour;
  private float currentTimeOfDay = 0.35f;

  public List<SkyboxTimeMapping> timeMappings;

  public float blendedValue = 0.0f;

  bool lockNextDayTrigger = false;

  public TextMeshProUGUI timeUI;
  #endregion

  #region Methods
  private void Update()
  {
    currentTimeOfDay += Time.deltaTime / dayDurationInSeconds;
    currentTimeOfDay %= 1;

    currentHour = Mathf.FloorToInt(currentTimeOfDay * 24);

    timeUI.text = $"{currentHour}:00";

    directionalLight.transform.rotation = Quaternion.Euler(new Vector3((currentTimeOfDay * 360) - 90, 170, 0));

    UpdateSkybox();
  }

  private void UpdateSkybox()
  {
    Material currentSkybox = null;

    foreach(SkyboxTimeMapping mapping in timeMappings)
    {
      if (currentHour == mapping.hour)
      {
        currentSkybox = mapping.skyboxMaterial;

        if (currentSkybox.shader != null)
        {
          if (currentSkybox.shader.name == "Custom/SkyboxTransition")
          {
            blendedValue += Time.deltaTime;
            blendedValue = Mathf.Clamp01(blendedValue);

            currentSkybox.SetFloat("_TransitionFactor", blendedValue);
          }
          else
          {
            blendedValue = 0;
          }
        }

        break;
      }
    }

    if (currentHour == 0 && !lockNextDayTrigger)
    {
      TimeManager.Instance.TriggerNextDay();
      lockNextDayTrigger = true;
    }

    if(currentHour != 0) lockNextDayTrigger = false;

    if (currentSkybox != null) RenderSettings.skybox = currentSkybox;
  }
  #endregion
}

[System.Serializable]
public class SkyboxTimeMapping
{
  public string phaseName;
  public int hour;
  public Material skyboxMaterial;
}