using System;
using UnityEngine;

namespace aprilJam
{
  public class TransfigurationArea : InteractableObject
  {
    #region PARAMETERS
    private ParticleSystem[] systems;
    #endregion

    #region EVENTS
    public static Action OnSailorTransformation;
    #endregion

    #region LIFECYCLE
    private void Awake()
    {
      systems = GetComponentsInChildren<ParticleSystem>();
    }
    #endregion

    #region METHODS
    protected override void ProcessTrigerCollision(Collider _collision)
    {
      var sailorSkin = _collision.transform.root.GetComponentInChildren<SailorSkin>();

      if (!sailorSkin.IsProfessionVisible)
      {
        sailorSkin.SetProfessionAttribute();
        OnSailorTransformation?.Invoke();
      }

      StopAllParticleSystem();
    }

    private void StopAllParticleSystem()
    {
      foreach (var sys in systems)
        sys.Stop();

      Destroy(gameObject, 6f);
    }
    #endregion
  }
}
