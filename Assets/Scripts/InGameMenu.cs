using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
  #region Methods
  public void BackToMainMenu() => SceneManager.LoadScene("MainMenu");
  #endregion
}
