using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HydratationBar : MonoBehaviour
{
  private Slider slider;
  public Text HydratationCounter;

  private float currentHydratation, maxHydratation;

  void Awake()
  {
    slider = GetComponent<Slider>();
  }

  void Update()
  {
    currentHydratation = PlayerState.Instance.currentHydrationPercent;
    maxHydratation = PlayerState.Instance.maxHydrationPercent;
    
    float fillValue = currentHydratation / maxHydratation;
    slider.value = fillValue;

    HydratationCounter.text = $"{currentHydratation}%";
  }
}
