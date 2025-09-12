using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
  #region Methods
  public void NewGame() => SceneManager.LoadScene("GameScene");

  public void ExitGame() => Application.Quit();
  #endregion
}
