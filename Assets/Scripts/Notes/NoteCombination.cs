using System;
using System.Collections.Generic;
using System.Text;
using Zenject;

namespace aprilJam
{
  public class NoteCombination: IInitializable
    {
    #region PARAMETERS
    [Inject] private Movement sailorMovement;

    public Dictionary<string, Action> Actions  { get; private set; }
    public int                        MaxLenth { get; private set; } = 5;
    #endregion

    #region IInitializable
    public void Initialize()
    {
      Actions = new Dictionary<string, Action>()
      {
        { NotesToKey(new List<Note>{ Note.Do, Note.Do }), sailorMovement.Move },
        { NotesToKey(new List<Note>{ Note.Do, Note.Fa }), sailorMovement.StartRotations15 },
        { NotesToKey(new List<Note>{ Note.Do, Note.Fa, Note.Fa }), sailorMovement.StartRotations90 },
        { NotesToKey(new List<Note>{ Note.Do, Note.Re }), sailorMovement.StartRotationsMinus15 },
        { NotesToKey(new List<Note>{ Note.Do, Note.Re, Note.Re }), sailorMovement.StartRotationsMinus90 },
        { NotesToKey(new List<Note>{ Note.Do, Note.Re, Note.Fa }), sailorMovement.TurnAround },
        { NotesToKey(new List<Note>{ Note.Re, Note.Do, Note.Fa }), sailorMovement.Dive },
        { NotesToKey(new List<Note>{ Note.Fa, Note.Do, Note.Re }), sailorMovement.Skip },
        { NotesToKey(new List<Note>{ Note.Re, Note.Do, Note.Fa, Note.Re, Note.Fa }), sailorMovement.isControls },
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
