using System;
using UnityEngine;

namespace aprilJam
{
  public class Sailor : MonoBehaviour
  {
    #region PARAMETERS
    [SerializeField] private ParticleSystem boomEffect;
    [SerializeField] private int            stamin = 100;
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
      CurrentHealth -= _inputDamage;
      OnTakingDamage?.Invoke(CurrentHealth);
      PlayBoomEffect();

      if (CurrentHealth <= 0)
        OnDeath?.Invoke();
    }

    public void PlayBoomEffect()
    {
      boomEffect.Play();
    }
    #endregion
  }
}
