using Cinemachine;
using System.Collections;
using UnityEngine;

namespace aprilJam
{
  [RequireComponent(typeof(CinemachineVirtualCamera))]
  public class CameraZoomIn : MonoBehaviour
  {
    #region PARAMETERS
    private CinemachineVirtualCamera virtualCamera;
    #endregion

    #region LIFECYCLE
    private void Start()
    {
      virtualCamera         = GetComponent<CinemachineVirtualCamera>();
      virtualCamera.enabled = false;

      TransfigurationArea.OnSailorTransformation += OnSailorTransformationCallback;
    }

    private void OnDestroy()
    {
      TransfigurationArea.OnSailorTransformation -= OnSailorTransformationCallback;
    }
    #endregion

    #region METHODS
    private void OnSailorTransformationCallback()
    {
      StartCoroutine(ZoomInAndOut());
    }

    private IEnumerator ZoomInAndOut()
    {
      virtualCamera.enabled = true;
      yield return new WaitForSeconds(5f);
      virtualCamera.enabled = false;
    }
    #endregion
  }
}
