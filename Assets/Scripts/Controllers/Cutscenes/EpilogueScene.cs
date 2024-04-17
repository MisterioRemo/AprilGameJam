using UnityEngine;
using UnityEngine.Video;

namespace aprilJam
{
  public class EpilogueScene : MonoBehaviour
  {
    #region PARAMETERS
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private VideoClip   happyVideo;
    [SerializeField] private VideoClip   sadVideo;
    [SerializeField] private VideoClip   lonelyVideo;
    #endregion

    #region LIFECYCLE
    private void Awake()
    {
      VideoClip video = null;

      switch (GameState.Instance.Ending)
      {
        case EndingType.Happy:
          video = happyVideo;
          break;
        case EndingType.Sad:
          video = sadVideo;
          break;
        case EndingType.Lonely:
          video = lonelyVideo;
          break;
        default:
          break;
      }

      videoPlayer.clip = video;
      videoPlayer.Prepare();
    }
    #endregion
  }
}
