using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour
{
  #region Properties
  public List<LootPossibility> possibleLoot;
  public List<LootRecieved> finalLoot;

  public bool wasLootCalculated;
  #endregion

  #region Methods
  #endregion
}

[System.Serializable]
public class LootPossibility
{
  #region Properties
  public GameObject item;
  public int amountMin;
  public int amountMax;
  #endregion
}

[System.Serializable]
public class LootRecieved
{
  #region Properties
  public GameObject item;
  public int amount;
  #endregion
}
