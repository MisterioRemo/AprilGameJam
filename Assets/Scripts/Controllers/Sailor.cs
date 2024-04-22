using System;
using UnityEngine;

namespace aprilJam
{
  public class Sailor : MonoBehaviour
  {
    [SerializeField] private int stamin = 100;

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

      if (CurrentHealth <= 0)
        OnDeath?.Invoke();
    }
    #endregion
  }
}
