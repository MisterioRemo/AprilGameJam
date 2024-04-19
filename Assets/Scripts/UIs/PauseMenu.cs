using UnityEngine;
using Zenject;

namespace aprilJam
{
  public class PauseMenu : MainMenu
  {
    #region PARAMETERS
    [Inject] private Game gameCtrl;

    [SerializeField] private GameObject SelectedMenuButton;
    #endregion

    private void OnEnable()
    {
      SetSelectedButton(SelectedMenuButton);
    }

    #region INTERFACE
    public void Continue()
    {
      gameCtrl.ReturnToGame();
    }

    public void ReturnToMainMenuScene()
    {
      gameCtrl.ReturnToMainMenu();
    }
    #endregion
  }
}
