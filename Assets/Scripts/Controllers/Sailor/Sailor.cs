using System;
using UnityEngine;

namespace aprilJam
{
  public class Sailor : MonoBehaviour
  {
    #region PARAMETERS
    [SerializeField] private ParticleSystem boomEffect;
    [SerializeField] private ParticleSystem hitEffect;
    #endregion

    #region PROPERTIES
    [field: SerializeField]
    public int MaxHealth     { get; private set; } = 100;
    public int CurrentHealth { get; private set; }
    #endregion

    #region EVENTS
    public Action OnDeath;
    public Action<int> OnTakingDamage;
    #endregion

    #region LIFECYCLE
    private void Awake()
    {
      CurrentHealth = MaxHealth;
    }
    #endregion

    #region METHODS
    public void Hit(int _inputDamage)
    {
      if (_inputDamage == 0)
        return;

      CurrentHealth -= _inputDamage;
      OnTakingDamage?.Invoke(CurrentHealth);
      PlayEffect(_inputDamage < 15 ? boomEffect : hitEffect);

      if (CurrentHealth <= 0)
        OnDeath?.Invoke();
    }

    public void PlayEffect(ParticleSystem _effect)
    {
      if (!_effect.gameObject.activeSelf)
        _effect.gameObject.SetActive(true);

      _effect.Play();
    }
    #endregion
  }
}
