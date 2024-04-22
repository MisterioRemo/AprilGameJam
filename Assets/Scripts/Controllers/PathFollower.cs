using PathCreation;
using UnityEngine;

namespace aprilJam
{
  public class PathFollower : MonoBehaviour
  {
    #region PARAMETERS
    [SerializeField] private Vector2              speedRange;
    [SerializeField] private EndOfPathInstruction endOfPathInstruction;
    [SerializeField] private PathCreator          pathCreator;

    private float speed;
    #endregion

    #region PROPERTIES
    public PathCreator PathCreator { get => pathCreator;
                                     set { if (pathCreator != null)
                                             pathCreator.pathUpdated -= OnPathChanged;

                                           pathCreator              = value;
                                           pathCreator.pathUpdated += OnPathChanged;
                                         }
                                   }
    public float DistanceTravelled { get; set; }
    #endregion

    #region LIFECYCLE
    private void Start()
    {
      speed = Random.Range(speedRange.x, speedRange.y);

      if (pathCreator != null)
        pathCreator.pathUpdated += OnPathChanged;
    }

    private void OnDestroy()
    {
      if (pathCreator != null)
        pathCreator.pathUpdated -= OnPathChanged;
    }

    private void Update()
    {
      if (PathCreator == null)
        return;

      DistanceTravelled += speed * Time.deltaTime;
      transform.position = PathCreator.path.GetPointAtDistance(DistanceTravelled, endOfPathInstruction);
      transform.rotation = PathCreator.path.GetRotationAtDistance(DistanceTravelled, endOfPathInstruction);
    }
    #endregion

    #region METHODS
    // If the path changes during the game, update the distance travelled so that the follower's position on the new path
    // is as close as possible to its position on the old path
    private void OnPathChanged()
    {
      DistanceTravelled = PathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }
    #endregion
  }
}
