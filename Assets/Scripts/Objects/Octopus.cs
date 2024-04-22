using UnityEngine;

namespace aprilJam
{
  public class Octopus : Obstacle
  {
    #region PARAMETERS
    [SerializeField] private Transform model;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float     speed;
    [SerializeField] private float     rotSpeed;

    private float   time;
    private Vector3 from;
    private Vector3 to;

    private bool       isRotating;
    private Quaternion rotFrom;
    private Quaternion rotTo;
    #endregion

    #region LIFECYCLE
    private void OnDrawGizmos()
    {
      if (model == null || startPoint == null || endPoint == null)
        return;

      Gizmos.DrawLine(startPoint.position, model.position);
      Gizmos.DrawLine(endPoint.position, model.position);
      Gizmos.color = Color.red;
      Gizmos.DrawLine(startPoint.position, endPoint.position);
    }

    private void Awake()
    {
      from       = startPoint.position;
      to         = endPoint.position;
      time       = 0f;
      isRotating = false;

      model.LookAt(to);
    }

    private void Update()
    {
      if (isRotating)
      {
        model.rotation = Quaternion.Lerp(rotFrom, rotTo, time);
        time          += rotSpeed * Time.deltaTime;

        if (time < 1f) return;

        time       = 0;
        isRotating = false;
      }

      model.position = Vector3.Lerp(from, to, time);
      time          += speed * Time.deltaTime;
      ChooseDirection();
    }
    #endregion

    #region METHODS
    private void ChooseDirection()
    {
      if ((model.position - to).magnitude > 0.1)
        return;

      time       = 0;
      (from, to) = (to, from);
      isRotating = true;
      rotFrom    = model.rotation;
      rotTo      = Quaternion.LookRotation(to - model.position);
    }
    #endregion
  }
}
