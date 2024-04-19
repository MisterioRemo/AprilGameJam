using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace aprilJam
{
  public class KeyToNote
  {
    // Нужно следить на актуальным состоянием вручную,
    // сщщтветствует настройкам AprilJamInputActions.Player
    static public Dictionary<Key, Note> Map = new Dictionary<Key, Note>()
    {
      { Key.W, Note.Do },
      { Key.A, Note.Re },
      { Key.S, Note.Mi },
      { Key.D, Note.Fa },
      { Key.Y, Note.Sol },
      { Key.O, Note.Sol },
      { Key.G, Note.La },
      { Key.K, Note.La },
      { Key.J, Note.Si },
      { Key.Semicolon, Note.Si }
    };
  }
}
