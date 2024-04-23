using System;
using System.Collections.Generic;
using UnityEngine;

namespace aprilJam
{
  [CreateAssetMenu(fileName = "NotePrefabs", menuName = "aprilJam/NotePrefabs")]
  public class NotePrefabs : ScriptableObject
  {
    [Serializable]
    public struct NotePrefab
    {
      public Note note;
      public GameObject prefab;
    }

    public List<NotePrefab> Value;
  }
}
