using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace aprilJam
{
  public class LogLine : MonoBehaviour
  {
    #region PROPERTIES
    public Image[] Images { get; private set; }
    #endregion

    #region LIFECYCLE
    private void Awake()
    {
      Images = GetComponentsInChildren<Image>();
    }
    #endregion
  }
}
