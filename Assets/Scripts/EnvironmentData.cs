using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnvironmentData
{
  #region Properties
  public List<string> pickedUpItems;

  public List<TreeData> treeData;

  public List<string> animals;

  public List<StorageData> storage;
  #endregion

  #region Methods
  public EnvironmentData(List<string> pickedUpItems, List<TreeData> treeData, List<string> animals, List<StorageData> storage)
  {
    this.pickedUpItems = pickedUpItems;
    this.treeData = treeData;
    this.animals = animals;
    this.storage = storage;
  }
  #endregion
}

[System.Serializable]
public class StorageData
{
  #region Properties
  public List<string> items;
  public Vector3 position;
  public Vector3 rotation;
  #endregion

  #region Methods
  #endregion
}

[System.Serializable]
public class TreeData
{
  #region Properties
  public string name;
  public Vector3 position;
  public Vector3 rotation;
  #endregion

  #region Methods
  #endregion
}