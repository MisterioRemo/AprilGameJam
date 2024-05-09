using System;
using System.Collections.Generic;
using System.Text;
using Zenject;

namespace aprilJam
{
  public class NoteCombination: IInitializable
    {
    #region PARAMETERS
    [Inject] private SailorMovement sailorMovement;

    public Dictionary<string, Action> Actions  { get; private set; }
    public int                        MaxLenth { get; private set; } = 5;
    #endregion

    #region IInitializable
    public void Initialize()
    {
      Actions = new Dictionary<string, Action>()
      {
        { NotesToKey(new List<Note>{ Note.Do, Note.Do }), sailorMovement.Move },
        { NotesToKey(new List<Note>{ Note.Do, Note.Fa }), sailorMovement.RotateBy15Clockwise },
        { NotesToKey(new List<Note>{ Note.Do, Note.Fa, Note.Fa }), sailorMovement.RotateBy90Clockwise },
        { NotesToKey(new List<Note>{ Note.Do, Note.Re }), sailorMovement.RotateBy15Anticlockwise },
        { NotesToKey(new List<Note>{ Note.Do, Note.Re, Note.Re }), sailorMovement.RotateBy90Anticlockwise },
        { NotesToKey(new List<Note>{ Note.Do, Note.Re, Note.Fa }), sailorMovement.TurnAround },
        { NotesToKey(new List<Note>{ Note.Re, Note.Do, Note.Fa }), sailorMovement.Dive },
        { NotesToKey(new List<Note>{ Note.Fa, Note.Do, Note.Re }), sailorMovement.Skip },
        // { NotesToKey(new List<Note>{ Note.Re, Note.Do, Note.Fa, Note.Re, Note.Fa }), sailorMovement.TakeControl }
      };
    }
    #endregion

    #region INTERFACE
    public string NotesToKey(List<Note> _notes)
    {
      var sb = new StringBuilder(MaxLenth);

      foreach (var note in _notes)
        sb.Append(note.ToString("D"));

      return sb.ToString();
    }
    #endregion
  }
}
