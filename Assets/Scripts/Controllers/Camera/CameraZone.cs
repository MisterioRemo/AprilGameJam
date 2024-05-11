using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace aprilJam
{
  [RequireComponent(typeof(CinemachineVirtualCamera))]
  public class CameraZone : MonoBehaviour
  {
    #region PARAMETERS
    private CinemachineVirtualCamera virtualCamera;
    #endregion

    #region LIFECYCLE
    private void Start()
    {
      virtualCamera = GetComponent<CinemachineVirtualCamera>();
      virtualCamera.enabled = false;
    }
    #endregion

    #region COLLISIONS
    private void OnTriggerEnter(Collider _collider)
    {
      if (_collider.transform.root.gameObject.CompareTag("Sailor"))
        virtualCamera.enabled = true;
    }

    private void OnTriggerExit(Collider _collider)
    {
      if (_collider.transform.root.gameObject.CompareTag("Sailor"))
        virtualCamera.enabled = false;
    }
    #endregion
  }
}
