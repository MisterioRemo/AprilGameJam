using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using static UnityEngine.InputSystem.InputAction;

namespace aprilJam
{
  public class Game: IInitializable, IDisposable
  {
    #region PARAMETERS
    [Inject] private AprilJamInputActions inputActions;
    [Inject] private SirenSong            sirenSong;
    [Inject] private Sailor               sailor;

    private GameObject combinationWindow;
    private GameObject menuWindow;
    #endregion

    public Game(List<GameObject> _uiWindows)
    {
      combinationWindow = _uiWindows[0];
      menuWindow        = _uiWindows[1];
    }

    #region LIFECYCLE
    public void Initialize()
    {
      inputActions.Player.Combination.started += ShowCombinationWindow;
      inputActions.Player.Menu.started        += ShowMenuWindow;
      inputActions.Menu.Exit.started          += ReturnToGame;
      sailor.OnDeath                          += OnSailorDeath;

      ShowCombinationWindow();
    }

    public void Dispose()
    {
      inputActions.Player.Combination.started -= ShowCombinationWindow;
      inputActions.Player.Menu.started        -= ShowMenuWindow;
      inputActions.Menu.Exit.started          -= ReturnToGame;
      sailor.OnDeath                          -= OnSailorDeath;
    }
    #endregion

    #region INPUT ACTIONS CALLBACKS
    public void ShowCombinationWindow(CallbackContext _context)
    {
      ShowCombinationWindow();
    }

    private void ShowMenuWindow(CallbackContext _context)
    {
      ShowMenuWindow();
    }

    public void ReturnToGame(CallbackContext _context)
    {
      ReturnToGame();
    }
    #endregion

    #region METHODS
    private void SwithInputAction(bool _toMenu)
    {
      if (_toMenu)
      {
        inputActions.Player.Disable();
        inputActions.Menu.Enable();
      }
      else
      {
        inputActions.Player.Enable();
        inputActions.Menu.Disable();
      }
    }

    private void OnSailorDeath()
    {
      GameState.Instance.DeathCount++;

      if (GameState.Instance.DeathCount == GameState.Instance.MaxLifeCount)
        LoadEndingScene(EndingType.Lonely);
      else
        LoadPrologueScene();
    }
    #endregion

    #region INTERFACE
    public void LoadEndingScene(EndingType _type)
    {
      GameState.Instance.Ending = _type;
      SceneManager.LoadScene("EpilogueCutscene");
    }

    public void LoadPrologueScene()
    {
      SceneManager.LoadScene("PrologueCutscene");
    }

    public void ShowCombinationWindow()
    {
      SwithInputAction(true);
      combinationWindow.SetActive(true);
    }

    public void ShowMenuWindow()
    {
      SwithInputAction(true);
      menuWindow.SetActive(true);
    }

    public void ReturnToGame()
    {
      SwithInputAction(false);
      combinationWindow.SetActive(false);
      menuWindow.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
      SceneManager.LoadScene("MainMenu");
    }

    public string GetSceneName()
    {
      return SceneManager.GetActiveScene().name;
    }
    #endregion
  }
}
