using UnityEngine;

namespace aprilJam
{
  [RequireComponent(typeof(Collider))]
  public class InteractableObject : MonoBehaviour
  {
    #region COLLISIONS
    protected virtual void OnTriggerEnter(Collider _collision)
    {
      if (!IsSailor(_collision.transform.root.gameObject))
        return;

      ProcessTrigerCollision(_collision);
    }

    protected virtual void OnCollisionEnter(Collision _collision)
    {
      if (!IsSailor(_collision.gameObject))
        return;

      ProcessCollision(_collision);
    }
    #endregion

    #region METHODS
    private bool IsSailor(GameObject _object)
    {
      return _object.CompareTag("Sailor");
    }

    protected virtual void ProcessTrigerCollision(Collider _collision)
    {
      // Empty
    }

    protected virtual void ProcessCollision(Collision _collision)
    {
      // Empty
    }
    #endregion
  }
}
