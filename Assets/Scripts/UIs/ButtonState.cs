using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace aprilJam
{
  public class ButtonState : MonoBehaviour, ISelectHandler, IDeselectHandler
  {
    #region PARAMETERS
    [SerializeField] private ButtonPalette   palette;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private bool            isSelected;

    [Inject] private AudioManager audioCtrl;
    #endregion

    #region LIFECYCLE
    private void OnEnable()
    {
      if (isSelected)
      {
        SetSelectedButton();
        OnSelect(null);
      }
    }

    public void OnDisable()
    {
      text.color = palette.normal;
    }
    #endregion

    #region METHODS
    private void SetSelectedButton()
    {
      EventSystem.current.SetSelectedGameObject(null);
      EventSystem.current.SetSelectedGameObject(gameObject);
    }
    #endregion

    #region INTERFACE
    public void OnSelect(BaseEventData eventData)
    {
      text.color = palette.active;
      audioCtrl.PlaySFX("Button");
    }

    public void OnDeselect(BaseEventData eventData)
    {
      text.color = palette.normal;
    }

    public void OnPressed()
    {
      text.color = palette.pressed;
      audioCtrl.PlaySFX("ButtonPressed");
    }
    #endregion
  }
}
