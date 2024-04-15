using UnityEngine;

namespace aprilJam
{
  public class TransfigurationArea : InteractableObject
  {
    #region PARAMETERS
    private ParticleSystem[] systems;
    #endregion

    #region LIFECYCLE
    protected override void Awake()
    {
      base.Awake();
      systems = GetComponentsInChildren<ParticleSystem>();
    }
    #endregion

    #region METHODS
    protected override void ProcessTrigerCollision(Collider _collision)
    {
      var sailorSkin = _collision.GetComponent<SailorSkin>();
      sailorSkin.SetProfessionAttribute();
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
