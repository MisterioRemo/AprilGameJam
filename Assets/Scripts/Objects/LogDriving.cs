using PathCreation;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace aprilJam
{
  public class LogDriving : MonoBehaviour
  {
    #region PARAMETERS
    [SerializeField] private Log               logPrefab;
    [SerializeField] private List<PathCreator> pathCreators;
    [SerializeField] private int               logPerSec;
    [SerializeField] private int               poolCapacity;

    private ObjectPool<Log> pool;
    #endregion

    #region LIFECYCLE
    private void Awake()
    {
      pool = new ObjectPool<Log>(CreateLog, OnTakingLogFromPool, OnReturnLogToPool, OnDestroyLog, true, poolCapacity, poolCapacity);
      InvokeRepeating("SpawnLog", 0f, logPerSec);
    }
    #endregion

    #region METHODS
    private void SpawnLog()
    {
      pool.Get();
    }

    private Log CreateLog()
    {
      Log log  = Instantiate(logPrefab);
      log.Pool = pool;

      return log;
    }

    private void OnTakingLogFromPool(Log _log)
    {
      _log.PathFollower.PathCreator       = pathCreators[Random.Range(0, pathCreators.Count)];
      _log.PathFollower.DistanceTravelled = 0f;
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
