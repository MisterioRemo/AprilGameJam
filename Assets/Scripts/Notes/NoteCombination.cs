using System.Collections.Generic;
using System.Text;
using Zenject;

namespace aprilJam
{
  public class NoteCombination: IInitializable
    {
    #region PARAMETERS
    [Inject] private SailorMovement sailorMovement;

    public Dictionary<string, CombinationProperties> Properties { get; private set; }
    public int                                       MaxLenth   { get; private set; } = 5;
    #endregion

    #region IInitializable
    public void Initialize()
    {
      Properties = new Dictionary<string, CombinationProperties>()
      {
        { NotesToKey(new List<Note>{ Note.Do, Note.Do }),          new CombinationProperties(sailorMovement.Move,                    "Song1") },
        { NotesToKey(new List<Note>{ Note.Do, Note.Fa }),          new CombinationProperties(sailorMovement.RotateBy15Clockwise,     "Song0") },
        { NotesToKey(new List<Note>{ Note.Do, Note.Fa, Note.Fa }), new CombinationProperties(sailorMovement.RotateBy90Clockwise,     "Song6") },
        { NotesToKey(new List<Note>{ Note.Do, Note.Re }),          new CombinationProperties(sailorMovement.RotateBy15Anticlockwise, "Song0") },
        { NotesToKey(new List<Note>{ Note.Do, Note.Re, Note.Re }), new CombinationProperties(sailorMovement.RotateBy90Anticlockwise, "Song5") },
        { NotesToKey(new List<Note>{ Note.Do, Note.Re, Note.Fa }), new CombinationProperties(sailorMovement.TurnAround,              "Song7") },
        { NotesToKey(new List<Note>{ Note.Re, Note.Do, Note.Fa }), new CombinationProperties(sailorMovement.Dive,                    "Song2") },
        { NotesToKey(new List<Note>{ Note.Fa, Note.Do, Note.Re }), new CombinationProperties(sailorMovement.Skip,                    "Song4") },
        // { NotesToKey(new List<Note>{ Note.Re, Note.Do, Note.Fa, Note.Re, Note.Fa }), new CombinationProperties(sailorMovement.TakeControl, "Song3") }
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
