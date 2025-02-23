using UnityEngine;

public class Blueprint
{
  public string itemName;
  public string req1;
  public string req2;
  public int req1Amount;
  public int req2Amount;
  public int numOfRequirements;
  public int numberOfItemToProduce;

  public Blueprint(string itemName, int producedItems, string req1, string req2, int req1Amount, int req2Amount, int numOfRequirements)
  {
    this.itemName = itemName;
    this.numberOfItemToProduce = producedItems;
    this.req1 = req1;
    this.req2 = req2;
    this.req1Amount = req1Amount;
    this.req2Amount = req2Amount;
    this.numOfRequirements = numOfRequirements;
  }
}
