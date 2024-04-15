using System;
using System.Collections.Generic;
using UnityEngine;

namespace aprilJam
{
  [CreateAssetMenu(fileName = "NotesColorPreset", menuName = "aprilJam/NotesColor")]
  public class NotesColor : ScriptableObject
  {
    [Serializable]
    public struct NoteColor
    {
      public Note  note;
      public Color color;
    }

    public List<NoteColor> Value;
  }
}
