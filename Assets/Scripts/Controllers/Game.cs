using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using static UnityEngine.InputSystem.InputAction;

namespace aprilJam
{
  public class Game : MonoBehaviour
  {
    #region PARAMETERS
    [Inject] private AprilJamInputActions inputActions;
    [Inject] private SirenSong            sirenSong;

    [SerializeField] private GameObject combinationWindow;
    #endregion

    #region LIFECYCLE
    private void Start()
    {
      inputActions.Player.Combination.started += ShowCombinationWindow;
      inputActions.Menu.Exit.started          += ReturnToGame;
    }

    private void OnDestroy()
    {
      inputActions.Player.Combination.started -= ShowCombinationWindow;
      inputActions.Menu.Exit.started          -= ReturnToGame;
    }
    #endregion

    #region INPUT ACTIONS CALLBACKS
    public void ShowCombinationWindow(CallbackContext _context)
    {
      inputActions.Player.Disable();
      inputActions.Menu.Enable();
      combinationWindow.SetActive(true);
    }

    public void ReturnToGame(CallbackContext _context)
    {
      inputActions.Player.Enable();
      inputActions.Menu.Disable();
      combinationWindow.SetActive(false);
    }
    #endregion

    #region INTERFACE
    public void LoadEndingScene(EndingType _type)
    {
      GameState.Instance.Ending = _type;
      SceneManager.LoadScene("EpilogueCutscene");
    }

    public void ReloadScene()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion
  }
}
