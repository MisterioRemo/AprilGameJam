using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace aprilJam
{
  public class Log : Obstacle
  {
    #region PARAMETERS
    [SerializeField] private List<Mesh> meshes;

    private MeshFilter meshFilter;
    #endregion

    #region PROPERTIES
    public PathFollower    PathFollower { get; set; }
    public ObjectPool<Log> Pool         { get; set; }
    #endregion

    #region LIFECYCLE
    private void Awake()
    {
      meshFilter   = GetComponentInChildren<MeshFilter>();
      PathFollower = GetComponent<PathFollower>();
    }

    private void OnEnable()
    {
      ChangeMesh();
    }
    #endregion

    #region METHODS
    private void ChangeMesh(int _index = -1)
    {
      meshFilter.mesh = _index == -1
                          ? meshes[Random.Range(0, meshes.Count)]
                          : meshes[_index];
    }

    protected override void ProcessTrigerCollision(Collider _collision)
    {
      base.ProcessTrigerCollision(_collision);

      if (_collision.CompareTag("LogDrivingEnd"))
        Pool.Release(this);
    }
    #endregion
  }
}
