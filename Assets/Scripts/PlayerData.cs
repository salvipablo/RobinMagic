[System.Serializable]
public class PlayerData
{
  public float[] playerStats;  // [0] - Health, [1] - Calories, [2] - Hydratation
  public float[] playerPositionAndRotation;  // postiion x,y,z and rotation x,y,z
  public string[] inventoryContent;
  public string[] quickSlotsContent;

  public PlayerData(float[] playerStats, float[] playerPositionAndRotation, string[] inventoryContent, string[] quickSlotsContent)
  {
    this.playerStats = playerStats;
    this.playerPositionAndRotation = playerPositionAndRotation;
    this.inventoryContent = inventoryContent;
    this.quickSlotsContent = quickSlotsContent;
  }
}
