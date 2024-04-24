using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace aprilJam
{
  public class EpilogueScene : MonoBehaviour
  {
    #region PARAMETERS
    [SerializeField] private VideoPlayer     videoPlayer;
    [SerializeField] private List<VideoClip> happyVideo;
    [SerializeField] private List<VideoClip> sadVideo;
    [SerializeField] private VideoClip       lonelyVideo;
    #endregion

    #region LIFECYCLE
    private void Awake()
    {
      VideoClip video = null;

      switch (GameState.Instance.Ending)
      {
        case EndingType.Happy:
          video = happyVideo[GameState.Instance.DeathCount];
          break;
        case EndingType.Sad:
          video = sadVideo[GameState.Instance.DeathCount];
          break;
        case EndingType.Lonely:
          OnVideoEnded(null);
          // video = lonelyVideo;
          break;
        default:
          break;
      }

      videoPlayer.loopPointReached += OnVideoEnded;
      videoPlayer.clip              = video;
      videoPlayer.Play();
    }

    private void OnDestroy()
    {
      videoPlayer.loopPointReached -= OnVideoEnded;
    }
    #endregion

    #region CALLBACKS
    private void OnVideoEnded(VideoPlayer _player)
    {
      SceneManager.LoadScene("MainMenu");
    }
    #endregion
  }
}
