using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  #region Methods
  public void NewGame() => SceneManager.LoadScene("GameScene");

  public void ExitGame()
  {
    Debug.Log("Quit Game");
    Application.Quit();
  }
  #endregion
}
