using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
  public static SaveManager Instance { get; set; }
  public bool isSavingToJson;

  // Json Project Save Path.
  string jsonPathProject;

  // Json External/Real Save Path.
  string jsonPatPersistant;

  // Binary path.
  string binaryPath;

  string fileName = "SaveGame";

  public bool isLoading;

  public Canvas loadingScreen;

  private void Awake()
  {
    if (Instance != null && Instance != this) Destroy(gameObject);
    else
    {
      Instance = this;
      DontDestroyOnLoad(gameObject);
    }
  }

  private void Start()
  {
    jsonPathProject = Application.dataPath + Path.AltDirectorySeparatorChar;
    jsonPatPersistant = Application.persistentDataPath + Path.AltDirectorySeparatorChar;
    binaryPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar;
  }

  #region ||------ General section ------||
    #region ||------ Obtain and Set Info section ------||
    private PlayerData GetPlayerData()
    {
      float[] playerStats = new float[3];
      playerStats[0] = PlayerState.Instance.currentHealth;
      playerStats[1] = PlayerState.Instance.currentCalories;
      playerStats[2] = PlayerState.Instance.currentHydrationPercent;

      float[] playerPosAndRot = new float[6];
      playerPosAndRot[0] = PlayerState.Instance.playerBody.transform.position.x;
      playerPosAndRot[1] = PlayerState.Instance.playerBody.transform.position.y;
      playerPosAndRot[2] = PlayerState.Instance.playerBody.transform.position.z;

      playerPosAndRot[3] = PlayerState.Instance.playerBody.transform.rotation.x;
      playerPosAndRot[4] = PlayerState.Instance.playerBody.transform.rotation.y;
      playerPosAndRot[5] = PlayerState.Instance.playerBody.transform.rotation.z;

      string[] inventory = InventorySystem.Instance.itemList.ToArray();

      string[] quickSlots = GetQuickSlotsContent();

      return new PlayerData(playerStats, playerPosAndRot, inventory, quickSlots);
    }

    private string[] GetQuickSlotsContent()
    {
      List<string> temp = new List<string>();

      foreach (GameObject slot in EquipSystem.Instance.quickSlotsList)
      {
        if (slot.transform.childCount != 0)
        {
          string name = slot.transform.GetChild(0).name;
          string str2 = "(Clone)";
          string cleanName = name.Replace(str2, "");
          temp.Add(cleanName);
        }
      }

      return temp.ToArray();
    }

    private void SetPlayerData( PlayerData playerData )
    {
      PlayerState.Instance.currentHealth = playerData.playerStats[0];
      PlayerState.Instance.currentCalories = playerData.playerStats[1];
      PlayerState.Instance.currentHydrationPercent = playerData.playerStats[2];

      Vector3 loadedPosition;
      loadedPosition.x = playerData.playerPositionAndRotation[0];
      loadedPosition.y = playerData.playerPositionAndRotation[1];
      loadedPosition.z = playerData.playerPositionAndRotation[2];

      PlayerState.Instance.playerBody.transform.position = loadedPosition;

      Vector3 loadedRotation;
      loadedRotation.x = playerData.playerPositionAndRotation[3];
      loadedRotation.y = playerData.playerPositionAndRotation[4];
      loadedRotation.z = playerData.playerPositionAndRotation[5];

      PlayerState.Instance.playerBody.transform.rotation = Quaternion.Euler(loadedRotation);

      // Settings the inventory content.
      foreach (string item in playerData.inventoryContent) InventorySystem.Instance.AddToInventory(item);
      
      // Settings the quickSlots content.
      foreach (string item in playerData.quickSlotsContent)
      {
        GameObject availableSlot = EquipSystem.Instance.FindNextEmptySlot();
        GameObject itemToAdd = Instantiate(Resources.Load<GameObject>(item));
        itemToAdd.transform.SetParent(availableSlot.transform, false);
      }
    }

    private EnvironmentData GetEnvironmentData()
    {
      List<string> itemsPickedUp = InventorySystem.Instance.itemsPickedUp;
      return new EnvironmentData(itemsPickedUp);
    }

		private void SetEnvironmentData( EnvironmentData environmentData )
		{
			foreach (Transform itemType in EnvironmentManager.Instance.allItems.transform)
      {
        foreach (Transform item in itemType.transform)
        {
          if (environmentData.pickedUpItems.Contains(item.name))
          {
            Destroy(item.gameObject);
          }
        }
      }

      InventorySystem.Instance.itemsPickedUp = environmentData.pickedUpItems;
		}
  	#endregion

	  #region ||------ Saving section ------||
	  public void SaveGame(int slotNumber)
    {
      AllGameData allGameData = new AllGameData();
      allGameData.playerData = GetPlayerData();
      allGameData.environmentData = GetEnvironmentData();
      SavingTypeSwitch(allGameData, slotNumber);
    }

    public void SavingTypeSwitch(AllGameData allGameData, int slotNumber)
    {
      if (isSavingToJson) SaveGameDataToJsonFile(allGameData, slotNumber);
      else SaveGameDataToBinaryFile(allGameData, slotNumber);
    }
    #endregion

    #region ||------ Loading section ------||
      public AllGameData LoadingTypeSwitch(int slotNumber)
      {
        AllGameData allGameData;
        if (isSavingToJson) allGameData = LoadGameDataFromJsonFile(slotNumber);
        else allGameData = LoadGameDataFromBinaryFile(slotNumber);
        return allGameData;
      }

      public void LoadGame(int slotNumber)
      {
        // Player Data.
        SetPlayerData(LoadingTypeSwitch(slotNumber).playerData);

				// Environment Data
				SetEnvironmentData(LoadingTypeSwitch(slotNumber).environmentData);

				isLoading = false;

        DisableLoadingScreen();
			}

			public void StartLoadedGame(int slotNumber)
      {
        ActivateLoadingScreen();
        isLoading = true;
        SceneManager.LoadScene("GameScene");
        StartCoroutine(DelayedLoading(slotNumber));
      }

      private IEnumerator DelayedLoading(int slotNumber)
      {
        yield return new WaitForSeconds(1f);
        LoadGame(slotNumber);
      }

      public void ActivateLoadingScreen()
      {
        loadingScreen.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
      }

      public void DisableLoadingScreen() => loadingScreen.gameObject.SetActive(false);

      #endregion
  #endregion

  #region ||------ Encryption ------||
  public string EncryptionDecryption(string json)
  {
    string keyword = "1234567";
    string result = "";

    for (int i = 0; i < json.Length; i++) result += (char)(json[i] ^ keyword[i % keyword.Length]);

    return result;
  }
  #endregion

  #region ||------ To Bynary section ------||
  public void SaveGameDataToBinaryFile(AllGameData gameData, int slotNumber )
  {
    BinaryFormatter binaryFormatter = new BinaryFormatter();

    FileStream fileStream = new FileStream(binaryPath + fileName + "_" + slotNumber + ".bin", FileMode.Create);

    binaryFormatter.Serialize(fileStream, gameData);
    fileStream.Close();

    print("Data saved to " + binaryPath + fileName + "_" + slotNumber + ".bin");
  }

  public AllGameData LoadGameDataFromBinaryFile(int slotNumber)
  {
    if (File.Exists(binaryPath + fileName + "_" + slotNumber + ".bin"))
    {
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      FileStream fileStream = new FileStream(binaryPath + fileName + "_" + slotNumber + ".bin", FileMode.Open);

      AllGameData data = binaryFormatter.Deserialize(fileStream) as AllGameData;
      fileStream.Close();

      print("Data Loaded from" + binaryPath + fileName + "_" + slotNumber + ".bin");

      return data;
    }
    else return null;
  }
  #endregion

  #region ||------ To Json section ------||
  public void SaveGameDataToJsonFile(AllGameData gameData, int slotNumber)
  {
    string json = JsonUtility.ToJson(gameData);

    //string jsonEncrypted = EncryptionDecryption(json);

    using(StreamWriter writer = new StreamWriter(jsonPathProject + fileName + "_" + slotNumber + ".json"))
    {
      writer.Write(json);
      print("Saved game to Json file at:" + jsonPathProject + fileName + "_" + slotNumber + ".json");
    }
  }

  public AllGameData LoadGameDataFromJsonFile(int slotNumber)
  {
    using(StreamReader reader = new StreamReader(jsonPathProject + fileName + "_" + slotNumber + ".json"))
    {
      string json = reader.ReadToEnd();
      //string jsonDecrypted = EncryptionDecryption(json);
      AllGameData gameData = JsonUtility.FromJson<AllGameData>(json);
      return gameData;
    }
  }
  #endregion

  #region ||------ Settings section ------||

  #region ||------ Volume section ------||
  [System.Serializable]
    public class VolumeSettings
    {
      public float music;
      public float effects;
      public float master;
    }

    public void SaveVolumeSetting(float _music, float _effects, float _master)
    {
      VolumeSettings volumeSettings = new VolumeSettings()
      {
        music = _music,
        effects = _effects,
        master = _master
      };

      PlayerPrefs.SetString("Volume", JsonUtility.ToJson(volumeSettings));
      PlayerPrefs.Save();
    }

    public VolumeSettings LoadVolumeSettings() => JsonUtility.FromJson<VolumeSettings>(PlayerPrefs.GetString("Volume"));
  #endregion

  #endregion

  #region ||------ Utility ------||
  public bool DoesFileExists(int slotNumber)
  {
    if (isSavingToJson)
    {
      // SaveGame_1.json
      if (System.IO.File.Exists(jsonPathProject + fileName + "_" + slotNumber + ".json"))  return true;
      else return false;
    } 
    else
    {
      // SaveGame_1.bin
      if (System.IO.File.Exists(binaryPath + fileName + "_" + slotNumber + ".bin")) return true;
      else return false;
    }
  }

  public bool IsSlotEmpty( int slotNumber )
  {
    if (DoesFileExists(slotNumber)) return false;
    else return true;
  }

  public void Deselectbutton()
  {
    GameObject myEventSystem = GameObject.Find("EventSystem");
    myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
  }
  #endregion
}
