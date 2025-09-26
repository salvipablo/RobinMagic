using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
  #region Propeties
  public static EnvironmentManager Instance { get; set; }
	public GameObject allItems;
  public GameObject allTrees;
  public GameObject allAnimals;
  public GameObject allPlaceables;
  #endregion

  #region Methods
  private void Awake()
	{
		if (Instance != null && Instance != this) Destroy(gameObject);
		else Instance = this;
	}
  #endregion
}
