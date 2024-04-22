using UnityEngine;

namespace aprilJam
{

  public class Obstacle : InteractableObject
  {
    #region PROPERTIES
    [field: SerializeField] public int DamageAmount { get; private set; }
    #endregion

    #region COLLISIONS
    protected override void ProcessCollision(Collision _collision)
    {
      Sailor sailor = _collision.gameObject.GetComponent<Sailor>();
      sailor.Hit(DamageAmount);
    }
    #endregion
  }
}
