using System.Collections.Generic;
using UnityEngine;

namespace aprilJam
{
  [RequireComponent(typeof(Collider))]
  public class InteractableObject : MonoBehaviour
  {
    #region PARAMETERS
    [SerializeField] protected List<string> collisionTags;
    #endregion

    #region COLLISIONS
    protected virtual void OnTriggerEnter(Collider _collision)
    {
      if (!IsSailor(_collision.transform.root.gameObject) && !IsAllowedTag(_collision.gameObject))
        return;

      ProcessTrigerCollision(_collision);
    }

    protected virtual void OnCollisionEnter(Collision _collision)
    {
      if (!IsSailor(_collision.gameObject) && !IsAllowedTag(_collision.gameObject))
        return;

      ProcessCollision(_collision);
    }
    #endregion

    #region METHODS
    protected bool IsSailor(GameObject _object)
    {
      return _object.CompareTag("Sailor");
    }

    protected bool IsAllowedTag(GameObject _object)
    {
      if (collisionTags == null || collisionTags.Count == 0)
        return false;

      foreach (var tag in collisionTags)
      {
        if (!_object.CompareTag(tag))
          return false;
      }

      return true;
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
