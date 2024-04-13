using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace aprilJam
{
  public class PrologueScene : MonoBehaviour
  {
    private enum PrologueStage : byte
    {
      NotStarted,
      FirstIntro,
      UserInput,
      SecondIntro
    }

    #region PARAMETERS
    [SerializeField] private VideoPlayer     videoPlayer;
    [SerializeField] private List<VideoClip> videos;
    [SerializeField] private string          gameSceneName;

    private IEnumerator<VideoClip> videoEnumerator;
    private PrologueStage          stage;
    #endregion

    #region LIFECYCLE
    private void Awake()
    {
      stage                         = PrologueStage.NotStarted;
      videoEnumerator               = videos.GetEnumerator();
      videoPlayer.loopPointReached += OnVideoEnded;
    }

    private void Start()
    {
      StartVideo(PrologueStage.FirstIntro);
    }

    private void OnDestroy()
    {
      videoPlayer.loopPointReached -= OnVideoEnded;
    }
    #endregion

    #region METHODS
    private void OnVideoEnded(VideoPlayer _player)
    {
      if (stage == PrologueStage.FirstIntro)
      {
        stage = PrologueStage.UserInput;
        StopVideo();
        WaitForUserInput();
      }
      else if (stage == PrologueStage.SecondIntro)
      {
        StopVideo();
        SceneManager.LoadScene(gameSceneName);
      }
    }

    private bool StartVideo(PrologueStage _newStage)
    {
      if (videoEnumerator.MoveNext())
      {
        stage            = _newStage;
        videoPlayer.clip = videoEnumerator.Current;
        videoPlayer.Play();

        return true;
      }

      return false;
    }

    private void StopVideo()
    {
      videoPlayer.Stop();
      videoPlayer.clip = null;
    }

    private void WaitForUserInput()
    {
      Debug.Log("wait");
      StartVideo(PrologueStage.SecondIntro);
    }
    #endregion
  }
}
