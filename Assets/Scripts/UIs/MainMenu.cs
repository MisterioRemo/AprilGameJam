using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace aprilJam
{
  public class MainMenu : MonoBehaviour
  {
    #region PARAMETERS
    [SerializeField] private GameObject MenuWindow;
    [SerializeField] private GameObject SettingsWindow;

    [SerializeField] private GameObject SelectedReturnFromSettingsButton;
    [SerializeField] private GameObject SelectedSettingsButton;
    #endregion

    #region METHODS
    protected void SetSelectedButton(GameObject _button)
    {
      EventSystem.current.SetSelectedGameObject(null);
      EventSystem.current.SetSelectedGameObject(_button);
    }
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
      SetSelectedButton(SelectedSettingsButton);
    }

    public void ReturnToMainMenu()
    {
      SettingsWindow.SetActive(false);
      MenuWindow.SetActive(true);
      SetSelectedButton(SelectedReturnFromSettingsButton);
    }

    public void QuitGame()
    {
      Application.Quit();
    }
    #endregion
  }
}
