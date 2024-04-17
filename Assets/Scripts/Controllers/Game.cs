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
    [Inject] private Sailor               sailor;

    [SerializeField] private GameObject combinationWindow;
    #endregion

    #region LIFECYCLE
    private void Start()
    {
      inputActions.Player.Combination.started += ShowCombinationWindow;
      inputActions.Menu.Exit.started          += ReturnToGame;
      sailor.OnDeath                          += LoadEndingScene;
      sailor.GetComponent<Movement>().StartMovement(); // TEMP!!!!!!!!!!!!
      ShowCombinationWindow();
    }

    private void OnDestroy()
    {
      inputActions.Player.Combination.started -= ShowCombinationWindow;
      inputActions.Menu.Exit.started          -= ReturnToGame;
      sailor.OnDeath                          -= LoadEndingScene;
    }
    #endregion

    #region INPUT ACTIONS CALLBACKS
    public void ShowCombinationWindow(CallbackContext _context)
    {
      ShowCombinationWindow();
    }

    public void ReturnToGame(CallbackContext _context)
    {
      ReturnToGame();
    }
    #endregion

    #region INTERFACE
    public void ShowCombinationWindow()
    {
      inputActions.Player.Disable();
      inputActions.Menu.Enable();
      combinationWindow.SetActive(true);
    }

    public void ReturnToGame()
    {
      inputActions.Player.Enable();
      inputActions.Menu.Disable();
      combinationWindow.SetActive(false);
    }

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
