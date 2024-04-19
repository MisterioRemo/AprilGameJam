using UnityEngine;
using UnityEngine.SceneManagement;

namespace aprilJam
{
  public class MainMenu : MonoBehaviour
  {
    #region PARAMETERS
    [SerializeField] private GameObject MenuWindow;
    [SerializeField] private GameObject SettingsWindow;
    #endregion

    #region INTERFACE
    public void StartGame()
    {
      SceneManager.LoadScene("PrologueCutscene");
    }

    public void ShowSettings()
    {
      MenuWindow.SetActive(false);
      SettingsWindow.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
      SettingsWindow.SetActive(false);
      MenuWindow.SetActive(true);
    }

    public void QuitGame()
    {
      Application.Quit();
    }
    #endregion
  }
}
