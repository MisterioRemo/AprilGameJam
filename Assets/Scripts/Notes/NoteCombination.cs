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
    public Dictionary<string, Action> Actions  { get; private set; }
    public int                        MaxLenth { get; private set; } = 5;
    #endregion

    #region IInitializable
    public void Initialize()
    {
      Actions = new Dictionary<string, Action>()
      {
        { NotesToKey(new List<Note> { Note.Do, Note.Re, Note.Mi, Note.Fa }), Fun1 }
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

    #region CRUTCH
    public void Fun1()
    {
      // crutch for sailor methods
    }
    #endregion
  }
}
