using UnityEngine;
using Zenject;

namespace aprilJam
{
  public class PauseMenu : MainMenu
  {
    #region PARAMETERS
    [Inject] private Game gameCtrl;
    #endregion

    #region LIFECYCLE
    private void OnDisable()
    {
      ReturnToMainMenu();
    }
    #endregion

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
