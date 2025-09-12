using System.Collections.Generic;

[System.Serializable]
public class EnvironmentData
{
  public List<string> pickedUpItems;

  public EnvironmentData(List<string> pickedUpItems)
  {
    this.pickedUpItems = pickedUpItems;
  }
}