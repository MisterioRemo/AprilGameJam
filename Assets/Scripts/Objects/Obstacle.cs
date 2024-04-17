using UnityEngine;

namespace aprilJam
{

  public class Obstacle : InteractableObject
  {
    #region PARAMETERS
    [field: SerializeField] public int DamageAmount { get; private set; }
    #endregion

    #region COLLISIONS
    protected override void ProcessCollision(Collision _collision)
    {
      Debug.Log($"Apply Damage {DamageAmount}");
      //Sailor sailor = _collision.gameObject.GetComponent<Sailor>();
      //sailor.ApplyDamage(DamageAmount);
    }
    #endregion
  }
}
