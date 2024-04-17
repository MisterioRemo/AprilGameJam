using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
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
        { NotesToKey(new List<Note>{ Note.Do, Note.Do }), sailorMovement.StartMovement },
          { NotesToKey(new List<Note>{ Note.Sol, Note.Si,Note.Si }), sailorMovement.StartRotations45},
          { NotesToKey(new List<Note>{ Note.Sol, Note.Si,Note.Si,Note.Si }), sailorMovement.StartRotations90},
          { NotesToKey(new List<Note>{ Note.Do, Note.Re,Note.Re }), sailorMovement.StartRotationsMinys45},
          { NotesToKey(new List<Note>{ Note.Do, Note.Re,Note.Re,Note.Re }), sailorMovement.StartRotationsMinys90},
          { NotesToKey(new List<Note>{ Note.Do, Note.Sol,Note.Mi,Note.Mi,Note.Mi }), sailorMovement.Dive},
          { NotesToKey(new List<Note>{ Note.Do, Note.Sol,Note.Do, Note.Do, Note.Do }), sailorMovement.Skip},
          { NotesToKey(new List<Note>{ Note.Do, Note.Sol,Note.Re, Note.Sol }), sailorMovement.isControls},
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
