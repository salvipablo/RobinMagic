using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
  private Slider slider;
  public Text healthCounter;

  private float currentHealth, maxHealth;

  void Awake()
  {
    slider = GetComponent<Slider>();
  }

  void Update()
  {
    currentHealth = PlayerState.Instance.currentHealth;
    maxHealth = PlayerState.Instance.maxHealth;

    float fillValue = currentHealth / maxHealth;
    slider.value = fillValue;

    healthCounter.text = $"{currentHealth}/{maxHealth}";
  }
}
