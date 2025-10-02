using System;
using UnityEngine;

public class Campfire : MonoBehaviour
{
  #region Properties
  public bool playerInRange;

  public bool isCooking;
  public float cookingTimer;

  public CookableFood foodBeingCooked;
  public string readyFood;

  public GameObject fire;
  #endregion

  #region Methods
  private void Update()
  {
    float distance = Vector3.Distance(PlayerState.Instance.playerBody.transform.position, transform.position);

    if (distance < 10f) playerInRange = true;
    else playerInRange = false;

    if (isCooking)
    {
      cookingTimer -= Time.deltaTime;
      fire.SetActive(true);
    }
    else fire.SetActive(false);

    if (cookingTimer <= 0 && isCooking)
    {
      isCooking = false;
      readyFood = GetCookedFood(foodBeingCooked);
    }
  }

  private string GetCookedFood(CookableFood food) => food.cookedFoodName;

  public void StartCooking(InventoryItem food)
  {
    foodBeingCooked = ConvertIntoCookable(food);

    isCooking = true;

    cookingTimer = TimeToCookFood(foodBeingCooked);
  }

  private CookableFood ConvertIntoCookable( InventoryItem food )
  {
    foreach (CookableFood cookable in CampfireUIManager.Instance.cookingData.validFoods)
    {
      if (cookable.foodName == food.thisName) return cookable;
    }

    return new CookableFood();
  }

  private float TimeToCookFood(CookableFood food) => food.timeCook;

  public void OpenUI()
  {
    CampfireUIManager.Instance.OpenUI();
    CampfireUIManager.Instance.selectedCampfire = this;

    print(readyFood);
    if (readyFood != "")
    {
      GameObject rf = Instantiate(Resources.Load<GameObject>(readyFood),
        CampfireUIManager.Instance.foodSlot.transform.position,
        CampfireUIManager.Instance.foodSlot.transform.rotation
      );

      rf.transform.SetParent(CampfireUIManager.Instance.foodSlot.transform);

      readyFood = "";
    }
  }
  #endregion
}
