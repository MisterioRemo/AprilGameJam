using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace aprilJam
{
  public class ButtonState : MonoBehaviour, ISelectHandler, IDeselectHandler
  {
    #region PARAMETERS
    [SerializeField] private ButtonPalette palette;

    private TextMeshProUGUI text;
    #endregion

    #region LIFECYCLE
    private void Awake()
    {
      text       = GetComponentInChildren<TextMeshProUGUI>();
      text.color = palette.normal;
    }
    #endregion

    #region METHODS
    public void OnSelect(BaseEventData eventData)
    {
      text.color = palette.active;
    }

    public void OnDeselect(BaseEventData eventData)
    {
      text.color = palette.normal;
    }

    public void OnPressed()
    {
      text.color = palette.pressed;
    }
    #endregion
  }
}
