using PathCreation;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace aprilJam
{
  public class LogDriving : MonoBehaviour
  {
    #region PARAMETERS
    [SerializeField] private Log               logPrefab;
    [SerializeField] private List<PathCreator> pathCreators;
    [SerializeField] private float             spawnRate;
    [SerializeField] private int               poolCapacity;

    private ObjectPool<Log> pool;
    private int             nextPathIndex = 0;

    [Inject] DiContainer diContainer;
    #endregion

    #region LIFECYCLE
    private void Awake()
    {
      pool = new ObjectPool<Log>(CreateLog, OnTakingLogFromPool, OnReturnLogToPool, OnDestroyLog, true, poolCapacity, poolCapacity);
      InvokeRepeating("SpawnLog", 0f, spawnRate);
    }
    #endregion

    #region METHODS
    private void SpawnLog()
    {
      pool.Get();
    }

    private Log CreateLog()
    {
      Log log  = diContainer.InstantiatePrefab(logPrefab).GetComponent<Log>();
      log.Pool = pool;

      return log;
    }

    private void OnTakingLogFromPool(Log _log)
    {
      _log.PathFollower.PathCreator       = pathCreators[nextPathIndex % pathCreators.Count];
      _log.PathFollower.DistanceTravelled = 0f;
      nextPathIndex++;
      _log.gameObject.SetActive(true);
    }

    private void OnReturnLogToPool(Log _log)
    {
      _log.gameObject.SetActive(false);
    }

    private void OnDestroyLog(Log _log)
    {
      Destroy(_log.gameObject);
    }
    #endregion
  }
}
