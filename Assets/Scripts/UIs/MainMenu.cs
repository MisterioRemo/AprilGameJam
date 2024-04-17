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

    #region INTERFACE
    public void StartGame()
    {
      SceneManager.LoadScene("SampleScene");
    }

    public void ShowSettings()
    {
      MenuWindow.SetActive(false);
      SettingsWindow.SetActive(true);

      var eventSystem = EventSystem.current;
      eventSystem.SetSelectedGameObject(SelectedSettingsButton, new BaseEventData(eventSystem));
    }

    public void ReturnToMainMenu()
    {
      SettingsWindow.SetActive(false);
      MenuWindow.SetActive(true);

      var eventSystem = EventSystem.current;
      eventSystem.SetSelectedGameObject(SelectedReturnFromSettingsButton, new BaseEventData(eventSystem));
    }

    public void QuitGame()
    {
      Application.Quit();
    }
    #endregion
  }
}
