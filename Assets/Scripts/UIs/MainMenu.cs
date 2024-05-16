using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace aprilJam
{
  public class MainMenu : MonoBehaviour
  {
    #region PARAMETERS
    [SerializeField] private GameObject menuWindow;
    [SerializeField] private GameObject settingsWindow;
    [SerializeField] private GameObject creditsWindow;
    [SerializeField] private GameObject menuCamera;
    [SerializeField] private float      cameraSpeed = 1f;

    private Quaternion cameraMenuRot;
    private Quaternion cameraCreditsRot;
    private bool       isCreditsInFocus = false;
    #endregion

    #region LIFECYCLE
    private void Awake()
    {
      if (menuCamera)
      {
        cameraMenuRot    = menuCamera.transform.rotation;
        cameraCreditsRot = new Quaternion(0.0776f, 0.7192f, -0.0814f, 0.6856f);
      }
    }
    #endregion

    #region INTERFACE
    public void StartGame()
    {
      GameState.Instance.Reset();
      SceneManager.LoadScene("PrologueCutscene");
    }

    public void ShowSettings()
    {
      menuWindow.SetActive(false);
      settingsWindow.SetActive(true);
    }

    public void ShowCredits()
    {
      if (menuCamera == null)
        return;

      isCreditsInFocus = true;
      creditsWindow.SetActive(true);
      StartCoroutine(RotateCamera(cameraMenuRot, cameraCreditsRot));
    }

    public void ReturnToMainMenu()
    {
      if (settingsWindow != null)
        settingsWindow.SetActive(false);
      menuWindow.SetActive(true);

      if (creditsWindow != null && creditsWindow.activeSelf)
      {
        isCreditsInFocus = false;
        StartCoroutine(RotateCamera(cameraCreditsRot, cameraMenuRot));
      }
    }

    public void QuitGame()
    {
      Application.Quit();
    }
    #endregion

    #region METHODS
    private IEnumerator RotateCamera(Quaternion from, Quaternion _to)
    {
      float time = 0f;

      while (time <= 1f)
      {
        menuCamera.transform.rotation = Quaternion.Lerp(from, _to, time);
        time += cameraSpeed * Time.deltaTime;

        yield return new WaitForEndOfFrame();
      }

      OnCoroutineRotateCameraEnded();
    }

    private void OnCoroutineRotateCameraEnded()
    {
      if (isCreditsInFocus)
        menuWindow.SetActive(false);
      else
        creditsWindow.SetActive(false);
    }
    #endregion
  }
}
