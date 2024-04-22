using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace aprilJam
{
  public class HealthBar : MonoBehaviour
  {
    #region PARAMETERS
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float  speed;

    private float healthValue;
    private float originHealthValue;
    private float targetHealthValue;
    private float maxHealthValue;
    private float time;

    [Inject] private Sailor sailor;
    #endregion

    #region LIFECYCLE
    private void Start()
    {
      time                   = 0f;
      healthValue            = sailor.CurrentHealth;
      originHealthValue      = sailor.CurrentHealth;
      targetHealthValue      = sailor.CurrentHealth;
      maxHealthValue         = sailor.MaxHealth;
      healthSlider.value     = NormalizedHealth();
      sailor.OnTakingDamage += UpdateHealthValue;
    }

    private void LateUpdate()
    {
      if (healthValue > targetHealthValue)
      {
        healthValue        = Mathf.Lerp(originHealthValue, targetHealthValue, time);
        time              += speed * Time.deltaTime;
        healthSlider.value = NormalizedHealth();
      }
    }

    private void OnDestroy()
    {
      sailor.OnTakingDamage -= UpdateHealthValue;
    }
    #endregion

    #region METHODS
    private void UpdateHealthValue(int _currentHealth)
    {
      time              = 0f;
      targetHealthValue = _currentHealth;
      originHealthValue = healthValue;
    }

    private float NormalizedHealth()
    {
      return healthValue / maxHealthValue;
    }
    #endregion
  }
}
