using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
  public static PlayerState Instance { get; set; }
  
  //---- Player Health ----//
  public float currentHealth, maxHealth;

  //---- Player Calories ----//
  public float currentCalories, maxCalories;
  private float distanceTravelled = 0;
  private Vector3 lastPosition;
  public GameObject playerBody;

  //---- Player Hydration ----//
  public float currentHydrationPercent, maxHydrationPercent;
  public bool isHydrationActive;
  private Coroutine hydrationCoroutine;

  private void Awake()
  {
    if (Instance != null && Instance != this) Destroy(gameObject);
    else Instance = this;
  }

  void Start()
  {
    currentHealth = maxHealth;
    currentCalories = 3000;
    currentHydrationPercent = maxHydrationPercent;
    isHydrationActive = true;

    hydrationCoroutine = StartCoroutine(decreaseHydratation());
  }

  private IEnumerator decreaseHydratation()
  {
    while (isHydrationActive)
    {
      currentHydrationPercent -= 1;
      yield return new WaitForSeconds(1);
    }
  }

  void Update()
  {
    distanceTravelled += Vector3.Distance(playerBody.transform.position, lastPosition);
    lastPosition = playerBody.transform.position;

    if (distanceTravelled >= 5)
    {
      distanceTravelled = 0;
      currentCalories -= 10;
    }

    if (Input.GetKeyDown(KeyCode.N)) currentHealth -= 10;
    if (Input.GetKeyDown(KeyCode.F)) currentCalories += 550;

    /*
     * Estas sentencias son para simular que estoy haciendo algo en donde no me deshidrato
     */
    if (Input.GetKeyDown(KeyCode.O) && isHydrationActive)
    {
      isHydrationActive = false;
      if (hydrationCoroutine != null)
      {
        StopCoroutine(hydrationCoroutine);
        hydrationCoroutine = null;
      }
    }

    if (Input.GetKeyDown(KeyCode.P) && !isHydrationActive)
    {
      isHydrationActive = true;
      if (hydrationCoroutine == null) hydrationCoroutine = StartCoroutine(decreaseHydratation());
    }
    /*
     * Estas sentencias son para simular que estoy haciendo algo en donde no me deshidrato
    */
  }

  public void setHealth(float newHealth) => currentHealth = newHealth;
  public void setCalories(float newCalories) => currentCalories = newCalories;
  public void setHydration(float newHydration) => currentHydrationPercent = newHydration;
}
