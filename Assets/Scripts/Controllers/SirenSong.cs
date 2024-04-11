using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static UnityEngine.InputSystem.InputAction;

namespace aprilJam
{
  public class SirenSong : MonoBehaviour
  {
    #region CONSTANTS
    const int MAX_NOTE_COUNT = 3;
    #endregion

    #region PARAMETERS
    [Inject] private AprilJamInputActions inputActions;

    private List<Note> noteCombination;
    #endregion

    #region LIFECYCLE
    private void Awake()
    {
      noteCombination          = new List<Note>();
      noteCombination.Capacity = MAX_NOTE_COUNT;
    }

    private void Start()
    {
      inputActions.Player.Do.started  += PlayedNoteDo;
      inputActions.Player.Re.started  += PlayedNoteRe;
      inputActions.Player.Mi.started  += PlayedNoteMi;
      inputActions.Player.Fa.started  += PlayedNoteFa;
      inputActions.Player.Sol.started += PlayedNoteSol;
      inputActions.Player.La.started  += PlayedNoteLa;
      inputActions.Player.Si.started  += PlayedNoteSi;

      inputActions.Player.Confirm.started += ApplyCombination;
    }

    private void OnDestroy()
    {
      inputActions.Player.Do.started  -= PlayedNoteDo;
      inputActions.Player.Re.started  -= PlayedNoteRe;
      inputActions.Player.Mi.started  -= PlayedNoteMi;
      inputActions.Player.Fa.started  -= PlayedNoteFa;
      inputActions.Player.Sol.started -= PlayedNoteSol;
      inputActions.Player.La.started  -= PlayedNoteLa;
      inputActions.Player.Si.started  -= PlayedNoteSi;

      inputActions.Player.Confirm.started -= ApplyCombination;
    }
    #endregion

    #region INPUT ACTIONS CALLBACKS
    private void PlayedNoteDo(CallbackContext _context)
    {
      AddNote(Note.Do);
    }

    private void PlayedNoteRe(CallbackContext _context)
    {
      AddNote(Note.Re);
    }

    private void PlayedNoteMi(CallbackContext _context)
    {
      AddNote(Note.Mi);
    }

    private void PlayedNoteFa(CallbackContext _context)
    {
      AddNote(Note.Fa);
    }

    private void PlayedNoteSol(CallbackContext _context)
    {
      AddNote(Note.Sol);
    }

    private void PlayedNoteLa(CallbackContext _context)
    {
      AddNote(Note.La);
    }

    private void PlayedNoteSi(CallbackContext _context)
    {
      AddNote(Note.Si);
    }

    private void ApplyCombination(CallbackContext _context)
    {
      //todo: calculate combination effect and sent it to sailor
      noteCombination.Clear();
    }
    #endregion

    #region METHODS
    private bool AddNote(Note _note)
    {
      if (noteCombination.Count == MAX_NOTE_COUNT)
        return false;

      noteCombination.Add(_note);
      return true;
    }
    #endregion
  }
}
