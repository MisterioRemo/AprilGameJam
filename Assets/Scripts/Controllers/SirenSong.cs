using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static UnityEngine.InputSystem.InputAction;

namespace aprilJam
{
  public class SirenSong : MonoBehaviour
  {
    #region PARAMETERS
    [Inject] private AprilJamInputActions inputActions;
    [Inject] private NoteCombination      noteCombination;

    private List<Note>  pressedNotes;
    private NotesEffect notesEffect;
    #endregion

    #region EVENTS
    public event Action<List<Note>> OnSinging;
    #endregion

    [Inject]
    public void Init(NotesEffect _notesEffect)
    {
      notesEffect = _notesEffect;
    }

    #region LIFECYCLE
    private void Start()
    {
      pressedNotes          = new List<Note>();
      pressedNotes.Capacity = noteCombination.MaxLenth;

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
      ApplyCombination();
    }

    private void ApplyCombination()
    {
      if (noteCombination.Actions.TryGetValue(noteCombination.NotesToKey(pressedNotes),
                                              out Action action))
      {
        action();
        OnSinging.Invoke(pressedNotes);
      }

      notesEffect.ResetAll();
      pressedNotes.Clear();
    }
    #endregion

    #region METHODS
    private bool AddNote(Note _note)
    {
      if (pressedNotes.Count == noteCombination.MaxLenth)
      {
        ApplyCombination();
        return false;
      }

      pressedNotes.Add(_note);
      notesEffect.PlayEffect(_note);
      return true;
    }
    #endregion
  }
}
